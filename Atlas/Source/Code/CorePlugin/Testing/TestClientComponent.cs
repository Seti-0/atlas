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
            AtlasLogs.Tests.Write($"Remote activate at {GameObj?.FullName}");
        }

        public void OnRemoteDeactivate()
        {
            RemoteActive = false;
            AtlasLogs.Tests.Write($"Remote deactivate at {GameObj?.FullName}");
            Dispose();
        }

        public void Update(object newValue)
        {
            AtlasLogs.Tests.Write($"Update at {GameObj?.FullName}");
            AtlasLogs.Tests.Write($"Value: {newValue}");

            if (newValue is Vector3 newVector)
                Value = newVector;

            else AtlasLogs.Tests.WriteWarning($"Unrecognised object at {GameObj?.FullName}");
        }
    }
}
