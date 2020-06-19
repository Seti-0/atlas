using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Duality;
using Duality.Editor;

namespace Soulstone.Duality.Plugins.Atlas
{
    public class AtlasLogs
    {
        public static Log Network = Logs.Get<NetworkLogInfo>();

        public static Log Tests = Logs.Get<TestLogInfo>();

        public static Log Sync = Logs.Get<SyncLogInfo>();

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
    }
}
