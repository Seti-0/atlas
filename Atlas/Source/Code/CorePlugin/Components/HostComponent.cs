using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Duality;
using Soulstone.Duality.Plugins.Atlas.Interface;

namespace Soulstone.Duality.Plugins.Atlas.Components
{
    public abstract class HostComponent<T> : Component, ICmpHostComponent, ICmpInitializable
    {
        public abstract Type GetClientComponentType();

        public virtual void OnActivate()
        {
            if (Scene != null)
            {
                SyncManager.PushComponentActivation(this);
            }
            else
            {
                AtlasApp.SyncLog.WriteError($"Unable to send deactivation from {GameObj.FullName}:" +
                    $" component is disconnected from scene");
            }
        }

        public virtual void OnDeactivate()
        {
            if (Scene != null)
            {
                SyncManager.PushComponentDeactivation(this);
            }
            else
            {
                AtlasApp.SyncLog.WriteError($"Unable to send deactivation from {GameObj.FullName}:" +
                    $" component is disconnected from scene");
            }
        }

        public void SendUpdate()
        {
            if (Scene != null)
            {
                OnSendUpdate();
                SyncManager.PushData(this);
            }
            else
            {
                AtlasApp.SyncLog.WriteError($"Unable to send update from {GameObj.FullName}:" +
                    $" component is disconnected from scene");
            }
        }

        protected virtual void OnSendUpdate(){}

        object ICmpHostComponent.GetValue()
        {
            return GetValue();
        }

        protected abstract T GetValue();
    }
}
