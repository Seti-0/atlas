using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Duality;
using Duality.Editor;
using Soulstone.Duality.Plugins.Atlas.Components;

namespace Soulstone.Duality.Plugins.Atlas.Testing
{
    [EditorHintCategory(CategoryNames.Testing)]
    public class TestHostComponent : HostComponent<Vector3>, ICmpUpdatable
    {
        private Vector3 _value;

        [DontSerialize] private Dictionary<Guid, string> _names = new Dictionary<Guid, string>();

        public Vector3 Value
        {
            get => _value;

            set
            {
                _value = value;
                SendUpdate();
            }
        }

        public override Type GetClientComponentType()
        {
            return typeof(TestClientComponent);
        }

        public override void OnActivate()
        {
            AtlasLogs.Tests.Write($"Sending activation from {GameObj.FullName}");
            base.OnActivate();
        }

        public override void OnDeactivate()
        {
            AtlasLogs.Tests.Write($"Sending deactivation from {GameObj.FullName}");
            base.OnDeactivate();
        }

        protected override void OnSendUpdate()
        {
            AtlasLogs.Tests.Write($"Sending value from {GameObj.FullName}");
            base.OnSendUpdate();
        }

        public void OnUpdate()
        {
            var obj = GameObj;

            CheckObject(obj);

            obj = obj.Parent;

            while (obj != null && obj.GetComponent<TestHostComponent>() == null)
            {
                CheckObject(obj);
                obj = obj.Parent;
            }
        }

        private void CheckObject(GameObject obj)
        {
            var newName = obj?.Name;

            if (!_names.ContainsKey(obj.Id))
                _names.Add(obj.Id, newName);

            else
            {
                var oldName = _names[obj.Id];

                if (newName != oldName)
                {
                    _names[obj.Id] = newName;
                    if (newName != null && oldName != null)
                    {
                        SyncManager.PushGameObjectName(obj, oldName, newName);
                    }
                }
            }
        }

        protected override Vector3 GetValue()
        {
            return _value;
        }
    }
}
