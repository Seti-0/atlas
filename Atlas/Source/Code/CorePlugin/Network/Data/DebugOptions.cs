using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soulstone.Duality.Plugins.Atlas.Network
{
    public struct DebugOptions
    {
        public bool Enable { get; set; }

        public float SimulatedLoss { get; set; }

        public float SimulatedDuplicates { get; set; }

        public float SimulatedFixedLatency { get; set; }

        public float SimulatedRandomLatency { get; set; }
    }
}
