using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soulstone.Duality.Plugins.Atlas.Network
{
    public class PeerInfo
    {
        public Guid ID { get; }
        public string Name { get; }
        public IPEndPoint EndPoint { get; }

        public PeerInfo(Guid id, string name, IPEndPoint endPoint)
        {
            ID = id;
            Name = name;
            EndPoint = endPoint;
        }

        public override string ToString()
        {
            string result = "";

            if (Name != null)
                result += Name;

            if (Name != null && EndPoint != null)
                result += " ";

            if (EndPoint != null)
                result += $"({EndPoint})";

            return result;
        }

        public string ToLongString()
        {
            return $"{ToString()} ({ID})";
        }
    }
}
