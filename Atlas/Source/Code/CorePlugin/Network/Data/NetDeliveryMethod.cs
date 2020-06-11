using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soulstone.Duality.Plugins.Atlas.Network
{
    public enum DeliveryMethod
    {
        Unknown,
        Unreliable,
        UnreliableSequenced,
        ReliableUnordered,
        ReliableSequenced,
        ReliableOrdered
    }
}
