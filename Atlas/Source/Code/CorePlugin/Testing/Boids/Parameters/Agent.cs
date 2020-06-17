
using Duality;
using Duality.Drawing;

namespace Soulstone.Duality.Plugins.Atlas.Testing.Boids
{
    public class AgentParameters
    {
        public EdgeBehaviour EdgeBehaviour { get; set; }

        public Rect Region { get; set; } 

        public float Border { get; set; }

        public float Margin { get; set; }

        public ColorHsva BaseColor { get; set; }

        public float Speed { get; set; } 

        public NoiseParameters Noise { get; set; }

        public BehaviourParameters Mouse { get; set; }

        public bool VisualDebug { get; set; } 

        public float SteeringStrength { get; set; } 
    }
}
