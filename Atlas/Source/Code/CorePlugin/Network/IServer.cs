using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soulstone.Duality.Plugins.Atlas.Network
{
    public interface IServer : INetworkPeer
    {
        bool Hosting { get; }


        event EventHandler<ClientJoinedEventArgs> Joined;

        bool Host(string name, ushort port);
        
        void SendData(byte[] data, DeliveryMethod deliveryMethod, int channel = 0);
        void SendData(byte[] data, DeliveryMethod deliveryMethod, int channel = 0, params PeerInfo[] targets);
    }
}
