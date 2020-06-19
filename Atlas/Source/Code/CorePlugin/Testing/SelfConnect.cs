using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Duality;
using Duality.Editor;

using Soulstone.Duality.Plugins.Atlas.Network;
using Soulstone.Duality.Plugins.Atlas.Interface;
using System.Net.Http.Headers;

namespace Soulstone.Duality.Plugins.Atlas.Testing
{
    [EditorHintCategory(CategoryNames.Testing)]
    public class SelfConnect : Component, ICmpInitializable, ICmpClientComponent, ICmpHostComponent
    {
        public enum PushType
        {
            All, Update
        }

        public PushType PushMethod { get; set; } = PushType.All;

        public string ServerName { get; set; } = "SelfConnect Server";

        public string ClientName { get; set; } = "SelfConnect Client";

        public ushort Port { get; set; } = 8889;

        public string IP { get; set; } = "127.0.0.1";

        private float _value;

        public float Value
        {
            get => _value;

            set
            {
                _value = value;

                if (PushMethod == PushType.All)
                    SyncManager.PushAll();
                else
                    SyncManager.PushData(this);
            }
        }

        public void OnActivate()
        {
            if (DualityApp.ExecContext != DualityApp.ExecutionContext.Game)
                return;

            if (AtlasApp.Server == null || AtlasApp.Client == null)
            {
                AtlasLogs.Tests.WriteWarning("Atlas app not initialized");
                return;
            }

            SetupListeners();

            if (AtlasApp.Server.Idle)
                AtlasApp.Server.Host("SelfConnect Server", 8889);

            if (AtlasApp.Client.Idle)
            {
                if (IPAddress.TryParse(IP, out var result))
                {
                    AtlasApp.Client.Join(ClientName, new IPEndPoint(result, Port));
                }
                else
                {
                    AtlasLogs.Tests.WriteWarning($"Failed to parse ip: {IP}");
                }
            }

            SyncManager.PushComponentActivation(this);
        }

        private void ClearListeners()
        {
            if (AtlasApp.Client != null)
            {
                AtlasApp.Client.Joined -= Client_Joined;
            }
        }

        private void SetupListeners()
        {
            ClearListeners();

            if (AtlasApp.Client != null)
            {
                AtlasApp.Client.Joined += Client_Joined;
            }
        }

        private void Client_Joined(object sender, ServerJoinedEventArgs e)
        {
            AtlasLogs.Tests.Write($"Joined {e.Server.Name} ({e.Server.EndPoint})!");
        }

        public void OnDeactivate()
        {
            SyncManager.PushComponentDeactivation(this);

            ClearListeners();

            if (DualityApp.ExecContext != DualityApp.ExecutionContext.Game)
                return;

            AtlasApp.Client?.Quit();
            AtlasApp.Server?.Quit();
        }

        public void OnRemoteDeactivate()
        {
             AtlasLogs.Tests.Write("Remote deactivation");
        }

        public void Update(object newValue)
        {
            AtlasLogs.Tests.Write($"Recieved value: {newValue}");
        }

        public Type GetClientComponentType()
        {
            return typeof(SelfConnect);
        }

        public object GetValue()
        {
            return _value;
        }

        public void OnRemoteActivate()
        {
            
        }
    }
}
