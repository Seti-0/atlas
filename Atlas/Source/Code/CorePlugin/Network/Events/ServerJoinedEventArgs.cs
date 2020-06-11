using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soulstone.Duality.Plugins.Atlas.Network
{
    public class ServerJoinedEventArgs : NetEventAgs
    {
        public PeerInfo Server { get; }

        public ServerJoinedEventArgs(PeerInfo serverInfo)
        {
            Server = serverInfo;
        }
    }
}
