using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Duality;
using Duality.Editor;

using Soulstone.Duality.Plugins.Atlas.Interface;

namespace Soulstone.Duality.Plugins.Atlas.Testing
{
    [EditorHintCategory(CategoryNames.Testing)]
    public class TestClientComponent : Component, ICmpClientComponent
    {
        public bool RemoteActive { get; private set; }

        public Vector3 Value { get; private set; }

        public void OnRemoteActivate()
        {
            RemoteActive = true;
            AtlasApp.TestLog.Write($"Remote activate at {GameObj?.FullName}");
        }

        public void OnRemoteDeactivate()
        {
            RemoteActive = false;
            AtlasApp.TestLog.Write($"Remote deactivate at {GameObj?.FullName}");
            Dispose();
        }

        public void Update(object newValue)
        {
            AtlasApp.TestLog.Write($"Update at {GameObj?.FullName}");
            AtlasApp.TestLog.Write($"Value: {newValue}");

            if (newValue is Vector3 newVector)
                Value = newVector;

            else AtlasApp.TestLog.WriteWarning($"Unrecognised object at {GameObj?.FullName}");
        }
    }
}
