using Duality;
using Duality.Editor;
using Soulstone.Duality.Plugins.Atlas.State;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soulstone.Duality.Plugins.Atlas.Testing
{
    [EditorHintCategory(CategoryNames.Testing)]
    public class StateComponent : global::Duality.Component, ICmpInitializable, ICmpSerializeListener
    {
        public World AtlasScene
        {
            get => State.World.Current;

            set => State.World.Current = value;
        }

        public void OnActivate()
        {
            if (Scene == null) return;

            var A = new State.EntityComponent();
            var B = new State.EntityComponent();
            var C = new State.EntityComponent();

            var a = new State.Entity("a");
            var b = new State.Entity("b");
            var c = new State.Entity("c");

            a.AddComponent(A);
            b.AddComponent(B);
            c.AddComponent(C);

            AtlasScene.AddObject(a);
            AtlasScene.AddObject(b);
            AtlasScene.AddObject(c);

            b.Parent = a;
        }

        public void OnDeactivate()
        {
            AtlasScene?.Clear();
        }

        public void OnLoaded()
        {
            AtlasScene?.SetupData();
        }

        public void OnSaved(){}
        public void OnSaving(){}
    }
}
