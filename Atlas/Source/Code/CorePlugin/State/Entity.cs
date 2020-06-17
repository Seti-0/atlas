using Duality;
using Duality.Editor;
using Duality.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Soulstone.Duality.Plugins.Atlas.State
{
    public class Entity : IDisposable
    {
        public Guid ID { get; set; } = Guid.NewGuid();

        private string _name;
        private Entity _parent;
        private List<EntityComponent> _components = new List<EntityComponent>();

        [DontSerialize] private EventHandler<EventArgs> _componentAdded, _componentRemoved, 
            _parentChanged, _childAdded, _childRemoved;

        [DontSerialize] private World _scene;
        [DontSerialize] private List<Entity> _children = new List<Entity>();
        [DontSerialize] private Dictionary<Type, EntityComponent> _componentMap = new Dictionary<Type, EntityComponent>();

        public event EventHandler<EventArgs> ComponentAdded
        {
            add => _componentAdded += value;
            remove => _componentAdded -= value;
        }

        public event EventHandler<EventArgs> ComponentRemoved
        {
            add => _componentRemoved += value;
            remove => _componentRemoved-= value;
        }

        public event EventHandler<EventArgs> ParentChanged
        {
            add => _parentChanged += value;
            remove => _parentChanged -= value;
        }

        public event EventHandler<EventArgs> ChildAdded
        {
            add => _childAdded += value;
            remove => _childAdded -= value;
        }

        public event EventHandler<EventArgs> ChildRemoved
        {
            add => _childRemoved += value;
            remove => _childRemoved -= value;
        }

        public string Name
        {
            get => _name ?? "null";
            set => _name = value;
        }

        [EditorHintFlags(MemberFlags.Invisible)]
        public string FullName
        {
            get
            {
                if (_parent == null)
                    return Name;

                return $"{_parent.FullName}/{Name}";
            }
        }

        public IReadOnlyList<EntityComponent> Components
        {
            get => _components;
        }

        public IReadOnlyList<Entity> Children
        {
            get => _children;
        }

        public Entity Parent
        {
            get => _parent;
            set => SetParent(value);
        }

        public World Scene
        {
            get => _scene;
            internal set => _scene = value;
        }

        public Entity(){}

        public Entity(string name)
        {
            Name = name;
        }

        public void Dispose()
        {
            Parent = null;

            var toRemove = Children.ToArray();
            foreach (var child in toRemove)
                child.Dispose();


        }

        public void SetupData(World scene)
        {
            if (_components == null)
                _components = new List<EntityComponent>();

            _componentMap = _components.ToDictionary(x => x.GetType());

            Scene = scene;

            foreach (var component in _components)
                component.SetupData(scene, this);

            SetParent(_parent, force: true);
        }

        private void SetParent(Entity parent, bool force = false)
        {
            if (parent != null && (parent == this || parent.IsDescendentOf(this)))
            {
                Logs.Game.WriteWarning($"Tried to set descendent {parent.FullName}" +
                    $"as parent of {parent.FullName}");
            }

            if (_parent != parent || force)
            {
                _parent?.RemoveChild(this);
                _parent = parent;
                _parent?.AddChild(this);

                OnParentChanged(new EventArgs());
            }
        }

        protected virtual void OnParentChanged(EventArgs e)
        {
            _parentChanged?.Invoke(this, e);
        }

        protected virtual void OnComponentAdded(EventArgs e)
        {
            _componentAdded?.Invoke(this, e);
        }

        protected virtual void OnComponentRemoved(EventArgs e)
        {
            _componentRemoved?.Invoke(this, e);
        }

        protected virtual void OnChildAdded(EventArgs e)
        {
            _childAdded?.Invoke(this, e);
        }

        protected virtual void OnChildRemoved(EventArgs e)
        {
            _childRemoved?.Invoke(this, e);
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        public override string ToString()
        {
            return FullName;
        }

        public string ToLongString()
        {
            return $"{FullName} ({ID})";
        }

        private bool IsDescendentOf(Entity obj)
        {
            if (_parent == null)
                return false;

            return obj == _parent || _parent.IsDescendentOf(obj);
        }

        public void AddComponent(EntityComponent component)
        {
            if (component == null) throw new ArgumentNullException(nameof(component));

            component.Detach();
            RemoveComponent(component.GetType());

            _components.Add(component);
            _componentMap.Add(component.GetType(), component);
            component.Entity = this;
            component.Scene = Scene;

            OnComponentAdded(new EventArgs());
        }

        public EntityComponent AddComponent(Type t)
        {
            if (t == null) throw new ArgumentNullException(nameof(t));

            EntityComponent component = t.GetTypeInfo().CreateInstanceOf() as EntityComponent;
            AddComponent(component);
            return component;
        }

        public T AddComponent<T>() where T : class
        {
            return AddComponent(typeof(T)) as T;
        }

        public EntityComponent RemoveComponent(Type t)
        {
            EntityComponent component = null;

            if (_componentMap.TryGetValue(t, out component))
            {
                _componentMap.Remove(t);
                component.Entity = null;
                component.Scene = null;
            }

            _components.RemoveAll(x => x.GetType() == t);

            OnComponentRemoved(new EventArgs());

            return component;
        }

        public T RemoveComponent<T>() where T : class
        {
            return RemoveComponent(typeof(T)) as T;
        }

        public void ClearComponents()
        {
            _components.Clear();
            _componentMap.Clear();

            OnComponentRemoved(new EventArgs());
        }

        public IEnumerable<EntityComponent> GetComponents(Type t)
        {
            if (t == null) throw new ArgumentNullException(nameof(t));

            var info = t.GetTypeInfo();

            foreach (var component in _components)
                if (info.IsAssignableFrom(component.GetType().GetTypeInfo()))
                    yield return component;
        }

        public IEnumerable<T> GetComponents<T>()
        {
            return GetComponents(typeof(T)).Cast<T>();
        }

        public EntityComponent GetComponent(Type t)
        {
            if (!_componentMap.TryGetValue(t, out var component))
                component = null;

            return component;
        }

        public T GetComponent<T>() where T : class
        {
            if (!_componentMap.TryGetValue(typeof(T), out var component))
                component = null;

            return component as T;
        }

        private void AddChild(Entity child)
        {
            _children.Add(child);
            OnChildAdded(new EventArgs());
        }

        private void RemoveChild(Entity child)
        {
            _children.Remove(child);
            OnChildRemoved(new EventArgs());
        }
    }
}
