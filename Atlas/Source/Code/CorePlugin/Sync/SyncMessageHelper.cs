using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using Duality;
using Duality.Resources;

using Soulstone.Duality.Plugins.Atlas.Interface;
using Soulstone.Duality.Plugins.Atlas.Network;
using Soulstone.Duality.Plugins.BlueInput.Selection;

namespace Soulstone.Duality.Plugins.Atlas.Sync
{
    internal enum MessageType
    {
        ObjectNameChanged,
        ObjectParentChanged,

        ComponentActivation,
        ComponentDeactivation,
        ComponentData,

        ComponentActivationCollection,
        ComponentDeactivationCollection,

        SyncRequest,
        FullSync
    }

    internal class SyncMessage 
    {
        public MessageType MessageType;
    }

    internal class SyncComponentSingle : SyncMessage
    {
        public string Path;
        public string TypeHint;
    }

    internal class SyncComponentCollection : SyncMessage
    {
        public string[] Paths;
        public string[] TypeHints;
    }

    internal class SyncGameObjectSingle : SyncMessage
    {
        public string Path;
    }

    internal class SyncRename : SyncGameObjectSingle
    {
        public string NewName;
    }

    internal class SyncParentChanged : SyncGameObjectSingle
    {
        public string NewParentPath;
    }

    internal class SyncDataSingle : SyncComponentSingle
    {
        public object Data;
    }

    internal class SyncDataCollection : SyncComponentCollection
    {
        public object[] Data;
    }

    internal class SyncMessageHelper
    {
        public static SyncMessage GetSyncRequestMessage()
        {
            return new SyncMessage();
        }

        public static SyncMessage GetParentChangedMessage(GameObject obj, GameObject oldParent, GameObject newParent)
        {
            return new SyncParentChanged
            {
                NewParentPath = SceneHelper.GetPath(newParent),
                Path = SceneHelper.GetPath(obj, oldParent)
            };
        }

        public static SyncMessage GetRenameMessage(GameObject obj, string oldName, string newName)
        {
            return new SyncRename
            {
                NewName = newName,
                Path = SceneHelper.GetPath(oldName, obj)
            };
        }

        private static void GetComponentInfo(ICmpHostComponent item, out string path, out string typeId)
        {
            var clientType = item.GetClientComponentType();
            var component = item as Component;

            path = SceneHelper.GetPath(component.GameObj);
            typeId = ReflectionHelper.GetTypeId(clientType);
        }

        private static void GetData(ICmpHostComponent item, out string path, out string typeId, out object data)
        {
            GetComponentInfo(item, out path, out typeId);
            data = item.GetValue();
        }

        public static SyncMessage GetComponentMessage(ICmpHostComponent item)
        {
            GetComponentInfo(item, out string path, out string typeId);

            return new SyncComponentSingle()
            {
                Path = path,
                TypeHint = typeId
            };
        }

        public static SyncMessage GetComponentMessage(IEnumerable<ICmpHostComponent> items)
        {
            var list = items.ToList();
            int n = list.Count;

            var result = new SyncComponentCollection
            {
                Paths = new string[n],
                TypeHints = new string[n]
            };

            for (int i = 0; i < n; i++)
            {
                GetComponentInfo(list[i],
                    out result.Paths[i], out result.TypeHints[i]);
            }

            return result;
        }

        public static SyncMessage GetDataMessage(ICmpHostComponent item)
        {
            GetData(item, out string path, out string typeId, out object data);

            return new SyncDataSingle()
            {
                Data = data,
                Path = path,
                TypeHint = typeId
            };
        }

        public static SyncMessage GetDataMessage(IEnumerable<ICmpHostComponent> items)
        {
            var list = items.ToList();
            int n = list.Count;

            var result = new SyncDataCollection
            {
                Data = new object[n],
                Paths = new string[n],
                TypeHints = new string[n]
            };

            for (int i = 0; i < n; i++)
            {
                GetData(list[i],
                    out result.Paths[i], out result.TypeHints[i], out result.Data[i]);
            }

            return result;
        }

        private static bool TryResolve(string id, out Type type)
        {
            if (id == null)
            {
                type = null;
                return false;
            }

            type = ReflectionHelper.ResolveType(id);

            if (type == null)
            {
                Logs.Game.WriteWarning($"Unable to resolve type hint: {id}");
                return false;
            }

            return true;
        }

        public static bool TryReadComponentMessage(SyncComponentSingle message, out Type type)
        {
            if (message.Path == null)
            {
                type = null;
                return false;
            }

            TryResolve(message.TypeHint, out type);
            return type != null;
        }

        public static bool TryReadDataMessage(SyncDataSingle message, out Type type)
        {
            return TryReadComponentMessage(message, out type);
        }


        public static bool TryReadDataMessage(SyncDataCollection message, out Type[] types)
        {
            if (TryReadDataMessage(message, out types))
            {
                return message.Data != null && message.Data.Length == message.Paths.Length;
            }

            return false;
        }

        public static bool TryReadComponentMessage(SyncComponentCollection message, out Type[] types)
        {
            types = null;

            if (message.Paths == null || message.TypeHints == null)
                return false;

            if (message.Paths.Length != message.TypeHints.Length)
                return false;

            int n = message.Paths.Length;

            for (int i = 0; i < n; i++)
                if (message.Paths[i] == null)
                    return false;

            types = new Type[n];

            for (int i = 0; i < n; i++)
            {
                TryResolve(message.TypeHints[i], out types[i]);
                if (types[i] == null) return false;
            }

            return true;
        }

        public static bool CheckGameObjectMessage(SyncRename message)
        {
            return message.Path != null;
        }

        public static bool CheckGameObjectMessage(SyncParentChanged message)
        {
            return message.NewParentPath != null && message.Path != null;
        }
    }
}
