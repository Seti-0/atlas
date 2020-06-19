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
    public class SimpleConnect : Component, ICmpInitializable
    {
        public enum ConnectionType
        {
            Server, Client, Both
        }

        public bool SendFullSync
        {
            get => false;

            set
            {
                if (AtlasApp.Server.Connected)
                    SyncManager.PushAll();
            }
        }

        public ConnectionType Connection { get; set; } = ConnectionType.Both;

        public string ServerName { get; set; } = "Simple Server";

        public string ClientName { get; set; } = "Simple Client";

        public ushort Port { get; set; } = 8889;

        public string IP { get; set; } = "127.0.0.1";
        public void OnActivate()
        {
            if (DualityApp.ExecContext != DualityApp.ExecutionContext.Game)
                return;

            if (AtlasApp.Server == null || AtlasApp.Client == null)
            {
                Logs.Game.WriteWarning("Atlas app not initialized");
                return;
            }

            switch (Connection)
            {
                case ConnectionType.Both:
                    SetupServer();
                    SetupClient();
                    break;

                case ConnectionType.Client:
                    SetupClient();
                    break;

                case ConnectionType.Server:
                    SetupServer();
                    break;
            }
        }

        private void SetupServer()
        {
            if (AtlasApp.Server == null)
                return;

            ShutdownServer();

            if (AtlasApp.Server.Idle)
                AtlasApp.Server.Host(ServerName, 8889);

            AtlasApp.Server.Joined += Server_Joined;
        }

        private void Server_Joined(object sender, ClientJoinedEventArgs e)
        {
            Logs.Game.Write($"{e.Client.Name} has joined the server!");
            SyncManager.PushAll(e.Client);
        }

        private void ShutdownServer()
        {
            if (AtlasApp.Server == null)
                return;

            AtlasApp.Server.Quit();
            AtlasApp.Server.Joined -= Server_Joined;
        }

        private void SetupClient()
        {
            if (AtlasApp.Client == null)
                return;

            ShutdownClient();

            if (AtlasApp.Client.Idle)
            {
                if (IPAddress.TryParse(IP, out var result))
                {
                    AtlasApp.Client.Join(ClientName, new IPEndPoint(result, Port));
                    AtlasApp.Client.Joined += Client_Joined;
                }
                else
                {
                    Logs.Game.WriteWarning($"Failed to parse ip: {IP}");
                }
            }
        }

        private void Client_Joined(object sender, ServerJoinedEventArgs e)
        {
            Logs.Game.Write($"Joined {e.Server.Name} ({e.Server.EndPoint})!");
        }

        private void ShutdownClient()
        {
            if (AtlasApp.Client == null)
                return;

            AtlasApp.Client.Quit();
            AtlasApp.Client.Joined -= Client_Joined;
        }

        public void OnDeactivate()
        {
            ShutdownClient();
            ShutdownServer();
        }
    }
}
