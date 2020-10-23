using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Duality;
using Duality.Drawing;

namespace Soulstone.Duality.Plugins.Atlas.Testing.Boids.Network
{
    public class AgentState
    {
        public ColorHsva Color { get; set; }

        public float Angle { get; set; }
        
        public Vector2 Position { get; set; }

        public float Scale { get; set; }

        public float StuckTime { get; set; }

        public TurnDirection SteerBias { get; set; } = TurnDirection.Left;

        public SteeringNoise Noise { get; set; } = new SteeringNoise();

        public bool LocalVisualDebug { get; set; } = false;

        public ColorHsva NaturalColor { get; set; } = ColorHsva.Red;
    }
}
