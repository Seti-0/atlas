using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Duality;

using Soulstone.Duality.Plugins.Atlas.Interface;

namespace Soulstone.Duality.Plugins.Atlas.Components
{
    public abstract class ClientComponent<T> : Component, ICmpClientComponent
    {    
        public virtual void OnRemoteActivate(){}

        public virtual void OnRemoteDeactivate()
        {
            Dispose();
        }

        void ICmpClientComponent.Update(object newValue)
        {
            if (newValue is T t)
                OnUpdate(t);
        }

        public abstract void OnUpdate(T newValue);
    }
}
