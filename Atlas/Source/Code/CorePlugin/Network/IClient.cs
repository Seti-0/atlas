using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soulstone.Duality.Plugins.Atlas.Network
{
    public interface IClient : INetworkPeer
    {
        event EventHandler<ServerJoinedEventArgs> Joined;

        bool Join(string name, IPEndPoint target);

        void SendData(byte[] data, DeliveryMethod deliveryMethod, int channel = 0);
    }
}
