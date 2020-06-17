using Duality;
using Duality.Editor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soulstone.Duality.Plugins.Atlas.State
{
    public class EntityComponent
    {
        [DontSerialize] private Entity _parent;
        [DontSerialize] private World _scene;

        [EditorHintFlags(MemberFlags.Invisible)]
        public Entity Entity
        {
            get => _parent;
            internal set => _parent = value;
        }

        [EditorHintFlags(MemberFlags.Invisible)]
        public World Scene
        {
            get => _scene;
            internal set => _scene = value;
        }

        public void Detach()
        {
            if (_parent == null) return;
            _parent.RemoveComponent(GetType());
        }

        public void SetupData(World scene, Entity parent)
        {
            Scene = scene;
            Entity = parent;
        }

        public override string ToString()
        {
            return GetType().Name;
        }

        public string ToLongString()
        {
            if (_parent == null)
                return ToString();

            else return $"{ToString()} ({_parent.FullName})";
        }
    }
}
