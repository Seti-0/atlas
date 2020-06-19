using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Duality;
using Duality.Editor;
using Duality.Resources;
using Soulstone.Duality.Plugins.Atlas.Network;
using Soulstone.Duality.Plugins.Atlas.Sync;

namespace Soulstone.Duality.Plugins.Atlas
{
    public static class AtlasApp
    {
        [EditorHintImage("Soulstone.Duality.Plugins.Atlas.EmbeddedResources.signal.png")]
        private class NetworkLogInfo : CustomLogInfo
        {
            public NetworkLogInfo() : base("Atlas.Network", "Soulstone.Duality.Plugins.Atlas.Network") { }
        }

        [EditorHintImage("Soulstone.Duality.Plugins.Atlas.EmbeddedResources.flask.png")]
        private class TestLogInfo : CustomLogInfo
        {
            public TestLogInfo() : base("Atlas.Testing", "Soulstone.Duality.Plugins.Atlas.Testing") { }
        }

        [EditorHintImage("Soulstone.Duality.Plugins.Atlas.EmbeddedResources.refresh.png")]
        private class SyncLogInfo : CustomLogInfo
        {
            public SyncLogInfo() : base("Atlas.Sync", "Soulstone.Duality.Plugins.Atlas.Sync") { }
        }

        public static Log NetworkLog = Logs.Get<NetworkLogInfo>();

        internal static Log TestLog = Logs.Get<TestLogInfo>();

        public static Log SyncLog = Logs.Get<SyncLogInfo>();

        public static IServer Server { get; private set; }

        public static IClient Client { get; private set; }

        public static void Init()
        {
            if (Server != null && Client != null)
                return;
            
            Server = FindBackend<IServer>();
            Client = FindBackend<IClient>();

            if (Server != null) Server.DataRecieved += Server_DataRecieved;
            if (Client != null) Client.DataRecieved += Client_DataRecieved;

            Scene.GameObjectParentChanged += Scene_GameObjectParentChanged;
        }

        private static void Scene_GameObjectParentChanged(object sender, GameObjectParentChangedEventArgs e)
        {
            if (SceneHelper.AffectsSync(e.Object))
                SyncManager.PushParentChanged(e.Object, e.OldParent, e.NewParent);
        }

        private static T FindBackend<T>() where T : class
        {
            var types = DualityApp.GetAvailDualityTypes(typeof(T));

            foreach (var type in types)
            {
                var attempt = type.CreateInstanceOf() as T;
                if (attempt != null)
                    return attempt;
            }

            Logs.Game.WriteWarning($"Unable to intialize {nameof(AtlasApp)}:" +
                $" no implementation found for {typeof(T).Name}");

            return null;
        }

        private static void Client_DataRecieved(object sender, DataRecievedEventArgs e)
        {
            //SyncManager.TryParseData(e.Data, e.Sender);
        }

        private static void Server_DataRecieved(object sender, DataRecievedEventArgs e)
        {
            //SyncManager.TryParseData(e.Data, e.Sender);
        }

        public static void Update()
        {
            Server?.Update();
            Client?.Update();
        }

        public static void Shutdown()
        {
            Server?.Quit();
            Client?.Quit();

            Server = null;
            Client = null;
        }
    }
}
