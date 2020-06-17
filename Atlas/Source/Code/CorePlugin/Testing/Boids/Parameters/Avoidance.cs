using Duality;
using Duality.Editor;

namespace Soulstone.Duality.Plugins.Atlas.Testing.Boids
{
    public class AvoidanceParameters : BehaviourParameters
    {
        [EditorHintRange(0, MathF.Pi)]
        public float VisionAngle { get; set; }

        public float VisionRadius { get; set; }

        public bool ShowVision { get; set; }
    }
}
