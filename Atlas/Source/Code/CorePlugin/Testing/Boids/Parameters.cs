using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Duality;
using Duality.Drawing;
using Duality.Editor;

namespace Soulstone.Duality.Plugins.Atlas.Testing.Boids
{
    [EditorHintCategory(CategoryNames.Testing)]
    public class Parameters : Resource
    {
        public AgentParameters General { get; set; } = new AgentParameters()
        {
            BaseColor = ColorHsva.Red,
            Border = 0,
            EdgeBehaviour = EdgeBehaviour.Wrap,
            Region = Rect.Align(global::Duality.Alignment.Center, 0, 0, DualityApp.WindowSize.X, DualityApp.WindowSize.Y),
            Margin = 100,
            Speed = 400,
            SteeringStrength = 1,
            VisualDebug = false,
           
            Noise = new NoiseParameters()
            {
                Apply = true,
                Duration = 1,
                Strength = 1
            },

            Mouse = new BehaviourParameters()
            {
                Apply = false,
                Strength = 1
            }
        };

        public AvoidanceParameters Avoidance { get; set; } = new AvoidanceParameters()
        {
            Apply = true,
            Strength = 5,
            VisionRadius = 100,
            VisionAngle = MathF.PiOver6,
            ShowVision = false
        };

        public FlockingParameters Alignment { get; set; } = new FlockingParameters()
        {
            Apply = false,
            Strength = 1,
            VisionAngle = MathF.PiOver2,
            VisionRadius = 200,
            ShowVision = true
        };

        public FlockingParameters Cohesion { get; set; } = new FlockingParameters()
        {
            Apply = false,
            Strength = 1,
            VisionAngle = MathF.PiOver2,
            VisionRadius = 400,
            ShowVision = true
        };

        public FlockingParameters Separation { get; set; } = new FlockingParameters()
        {
            Apply = false,
            Strength = 1,
            VisionAngle = MathF.Pi,
            VisionRadius = 100,
            ShowVision = true
        };

        public ColorParameters Color { get; set; } = new ColorParameters()
        {
            Apply = false,
            Strength = 1,
            VisionAngle = MathF.PiOver4,
            VisionRadius = 400,
            ShowVision = false,
            ShowTarget = true
        };
    }
}
