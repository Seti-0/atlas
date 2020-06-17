using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soulstone.Duality.Plugins.Atlas.Testing.Boids
{
    public class ColorParameters : FlockingParameters
    {
        public bool ShowTarget { get; set; }

        public bool ShowLinks { get; set; }

        public bool ShowCircular { get; set; }
    }
}
