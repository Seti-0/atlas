using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using Duality;
using Duality.Resources;

using Soulstone.Duality.Plugins.Atlas.Components;
using Soulstone.Duality.Plugins.Atlas.Interface;
using Soulstone.Duality.Plugins.BlueInput.Selection;

namespace Soulstone.Duality.Plugins.Atlas.Sync
{
    internal static class SceneHelper
    {
        public const char PathSeparator = '/';

        public static void FullSync(string[] paths, Type[] types, object[] data)
        {
            var set = new HashSet<string>(paths);

            foreach (var item in Scene.Current.FindComponents<ICmpClientComponent>())
            {
                var component = item as Component;

                var path = GetPath(component.GameObj);
                if (!set.Contains(path))
                    component.DisposeLater();
            }

            int n = paths.Length;
            for (int i = 0; i < n; i++)
            {
                var component = EnsureExistence(paths[i], types[i]) as ICmpClientComponent;
                component.OnRemoteActivate();
                component.Update(data[i]);
            }
        }

        public static void Activate(string[] paths, Type[] types)
        {
            for (int i = 0; i < paths.Length; i++)
            {
                Activate(paths[i], types[i]);
            }
        }

        public static void Activate(string path, Type type)
        {
            var component = EnsureExistence(path, type) as ICmpClientComponent;
            component.OnRemoteActivate();
        }

        public static void Deactivate(string[] paths, Type[] types)
        {
            for (int i = 0; i < paths.Length; i++)
                Deactivate(paths[i], types[i]);
        }

        public static void DeactivateAll()
        {
            foreach (var component in Scene.Current.FindComponents<ICmpClientComponent>())
                component.OnRemoteDeactivate();
        }

        public static void Deactivate(string path, Type type)
        {
            if (TryFindComponent(path, type, out var component))
            {
                component.OnRemoteDeactivate();
            }
            else
            {
                AtlasLogs.Sync.WriteWarning($"Could not find client component for " +
                    $"deactivation: {type.Name}, {path}");
            }
        }

        public static void Update(string[] paths, Type[] types, object[] data)
        {
            for (int i = 0; i < paths.Length; i++)
            {
                Update(paths[i], types[i], data[i]);
            }
        }

        public static void Update(string path, Type type, object data)
        {
            if (TryFindComponent(path, type, out var component))
            {
                component.Update(data);
            }
            else
            {
                AtlasLogs.Sync.WriteWarning($"Could not find client component for " +
                    $"deactivation: {type.Name}, {path}");
            }
        }

        public static void ChangeName(string path, string newName)
        {
            if (TryFindGameObject(path, out var obj))
            {
                obj.Name = newName;
            }
            else
            {
                AtlasLogs.Sync.WriteWarning($"Could not find object for change of name: {path}");
                AtlasLogs.Sync.Write($"Desired new name: {newName}");
            }
        }

        public static void ChangeParent(string objPath, string newParentPath)
        {
            if (!TryFindGameObject(objPath, out var target))
            {
                AtlasLogs.Sync.WriteWarning($"Could not find object for change of parent: {objPath}");
                return;
            }

            GameObject newParent = null;

            if (newParentPath != null)
            {
                newParent = EnsureExistence(newParentPath);

                if (newParent == target || newParent.IsChildOf(target))
                {
                    AtlasLogs.Sync.WriteWarning($"Attempted to create circular parent relationship");
                    AtlasLogs.Sync.Write($"Target: {target.FullName}, New Parent: {newParent.FullName}");
                    return;
                }
            }

            target.Parent = newParent;
        }

        public static void Delete(string path)
        {
            if (TryFindGameObject(path, out var obj))
            {
                foreach (var item in obj.GetComponentsDeep<ICmpClientComponent>())
                    item.OnRemoteDeactivate();

                obj.DisposeLater();
            }
            else
            {
                AtlasLogs.Sync.WriteWarning($"Could not find object to delete: {path}");
            }
        }

        public static bool AffectsSync(GameObject obj)
        {
            return obj.GetComponentsDeep<ICmpHostComponent>().Any();
        }

        public static string GetPath(string name, GameObject obj)
        {
            if (obj == null || name == null)
                return null;

            if (obj.Parent == null)
                return name;

            return $"{GetPath(obj.Parent)}{PathSeparator}{name}";
        }

        public static string GetPath(GameObject obj, GameObject parent)
        {
            if (obj == null)
                return null;

            if (parent == null)
                return obj.Name;

            return $"{GetPath(parent)}{PathSeparator}{obj.Name}";
        }

        public static string GetPath(GameObject obj)
        {
            if (obj == null)
                return null;

            else
            {
                var parentPath = GetPath(obj.Parent);

                if (parentPath == null)
                    return obj.Name;

                else return $"{parentPath}{PathSeparator}{obj.Name}";
            }
        }

        private static GameObject EnsureExistence(string path)
        {
            var elements = path.Split(PathSeparator);
            if (elements.Length == 0) return null;

            var scene = Scene.Current;
            var current = scene.FindGameObject(elements[0]);

            if (current == null)
            {
                current = new GameObject(elements[0]);
                scene.AddObject(current);
            }

            for (int i = 1; i < elements.Length; i++)
            {
                var next = current.GetChildByName(elements[i]);

                if (next == null)
                {
                    next = new GameObject(elements[i]);
                    scene.AddObject(next);
                    next.Parent = current;
                }

                current = next;
            }

            return current;
        }

        private static Component EnsureExistence(string path, Type type)
        {
            var current = EnsureExistence(path);

            var component = current.GetComponent(type);

            if (component == null)
                component = current.AddComponent(type);

            return component;
        }

        private static GameObject FindGameObject(string path)
        {
            var elements = path.Split(PathSeparator);
            if (elements.Length == 0) return null;

            var scene = Scene.Current;
            var current = scene.FindGameObject(elements[0]);

            if (current == null)
                return null;

            for (int i = 1; i < elements.Length; i++)
            {
                current = current.GetChildByName(elements[i]);

                if (current == null)
                    break;
            }

            return current;
        }

        private static Component FindComponent(string path, Type type)
        {
            return FindGameObject(path)?.GetComponent(type);
        }

        private static bool TryFindComponent(string path, Type t, out ICmpClientComponent component)
        {
            component = FindComponent(path, t) as ICmpClientComponent;
            return component != null;
        }

        private static bool TryFindGameObject(string path, out GameObject obj)
        {
            obj = FindGameObject(path);
            return obj != null;
        }
    }
}
