using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soulstone.Duality.Plugins.Atlas.Network
{
    public interface INetworkPeer
    {
        event EventHandler<DisconnectEventArgs> Disconnect;
        event EventHandler<DataRecievedEventArgs> DataRecieved;

        DebugOptions DebugOptions { get; set; }

        PeerInfo Info { get; }

        Guid ID { get; }
        string Name { get; }
        IPEndPoint EndPoint { get; }

        PeerInfo Server { get; }
        IEnumerable<PeerInfo> Connections { get; }

        bool Connected { get; }
        bool Idle { get; }

        void Update();

        void Quit();
    }
}
