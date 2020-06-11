using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soulstone.Duality.Plugins.Atlas.Network
{
    public class ClientJoinedEventArgs : NetEventAgs
    {
        public PeerInfo Client { get; }

        public ClientJoinedEventArgs(PeerInfo clientInfo)
        {
            Client = clientInfo;
        }
    }
}
