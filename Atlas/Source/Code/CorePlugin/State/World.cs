using Duality;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soulstone.Duality.Plugins.Atlas.State
{
    public class World
    {
        private static World current = new World();

        public static event EventHandler<EventArgs> Entered, Leaving;

        public static World Current
        {
            get => current;

            set
            {
                Leaving?.Invoke(null, new EventArgs());

                current = value ?? new World();

                Entered?.Invoke(null, new EventArgs());
            }
        }

        private List<Entity> _gameObjects = new List<Entity>();
        [DontSerialize] private HashSet<Entity> _objSet = new HashSet<Entity>();

        [DontSerialize] private EventHandler<EventArgs> _objectAdded, _objectRemoved,
            _componentAdded, _componentRemoved, _parentChanged;

        public IEnumerable<Entity> AllObjects => _gameObjects;

        public IEnumerable<Entity> RootObjects
        {
            get
            {
                foreach (var obj in _gameObjects)
                    if (obj.Parent == null)
                        yield return obj;
            }
        }

        public event EventHandler<EventArgs> ObjectAdded
        {
            add => _objectAdded += value;
            remove => _objectAdded -= value;
        }

        public event EventHandler<EventArgs> ObjectRemoved
        {
            add => _objectRemoved += value;
            remove => _objectRemoved -= value;
        }

        public event EventHandler<EventArgs> ParentChanged
        {
            add => _parentChanged += value;
            remove => _parentChanged -= value;
        }

        public event EventHandler<EventArgs> ComponentAdded
        {
            add => _componentAdded += value;
            remove => _componentAdded -= value;
        }

        public event EventHandler<EventArgs> ComponentRemoved
        {
            add => _componentRemoved += value;
            remove => _componentRemoved -= value;
        }

        protected void OnObjectAdded(EventArgs e)
        {
            _objectAdded?.Invoke(this, e);
        }

        protected void OnObjectRemoved(EventArgs e)
        {
            _objectRemoved?.Invoke(this, e);
        }

        protected void OnComponentAdded(EventArgs e)
        {
            _componentAdded?.Invoke(this, e);
        }

        protected void OnComponentRemoved(EventArgs e)
        {
            _componentRemoved?.Invoke(this, e);
        }

        protected void OnParentChanged(EventArgs e)
        {
            _parentChanged?.Invoke(this, e);
        }

        public void SetupData()
        {
            if (_gameObjects == null)
                _gameObjects = new List<Entity>();

            _objSet = new HashSet<Entity>(_gameObjects);
            _gameObjects = new List<Entity>(_objSet);

            foreach (var obj in _gameObjects)
                obj.SetupData(this);
        }

        public void AddObject(Entity obj)
        {
            if (obj == null) 
                throw new ArgumentNullException(nameof(obj));

            if (_objSet.Contains(obj))
                return;

            obj.ParentChanged += Obj_ParentChanged;
            obj.ComponentAdded += Obj_ComponentAdded;
            obj.ComponentRemoved += Obj_ComponentRemoved;

            _gameObjects.Add(obj);
            _objSet.Add(obj);

            obj.Scene = this;

            OnObjectAdded(new EventArgs());
        }

        private void Obj_ComponentRemoved(object sender, EventArgs e)
        {
            OnComponentRemoved(e);
        }

        private void Obj_ComponentAdded(object sender, EventArgs e)
        {
            OnComponentAdded(e);
        }

        private void Obj_ParentChanged(object sender, EventArgs e)
        {
            OnParentChanged(e);
        }

        public void RemoveObject(Entity obj)
        {
            if (obj == null) 
                throw new ArgumentNullException(nameof(obj));

            if(_objSet.Remove(obj))
            {
                _gameObjects.Remove(obj);
                obj.Scene = null;

                obj.ComponentAdded -= Obj_ComponentAdded;
                obj.ComponentRemoved -= Obj_ComponentRemoved;
                obj.ParentChanged -= Obj_ParentChanged;

                OnObjectRemoved(new EventArgs());
            }
        }

        public void Clear()
        {
            var toRemove = _gameObjects.ToArray();
            foreach (var obj in toRemove)
            {
                RemoveObject(obj);
            }
        }

        public IEnumerable<Entity> FindObjects(string name)
        {
            return _gameObjects.Where(x => x.Name == name);
        }

        public IEnumerable<EntityComponent> FindComponents(Type t)
        {
            if (t == null) throw new ArgumentNullException(nameof(t));
            return _gameObjects.SelectMany(x => x.GetComponents(t));
        }
        
        public IEnumerable<T> FindComponents<T>()
        {
            return FindComponents(typeof(T)).Cast<T>();
        }

        public Entity FindObject(string name)
        {
            foreach (var obj in _gameObjects)
                if (obj.Name == name)
                    return obj;

            return null;

        }

        public EntityComponent FindComponent(Type t)
        {
            foreach (var obj in _gameObjects)
            {
                var component = obj.GetComponent(t);
                if (component != null) return component;
            }

            return null;
        }

        public T FindComponent<T>() where T : class
        {
            return FindComponent(typeof(T)) as T;
        }
    }
}
