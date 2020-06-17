
using Duality;
using Duality.Drawing;
using Duality.Editor;

namespace Soulstone.Duality.Plugins.Atlas.Testing.Boids
{
    public enum EdgeBehaviour
    {
        None, Wrap
    }

    public class GeneralParameters
    {
        public ColorHsva BaseColor { get; set; } = ColorHsva.Red;

        public float NoiseFrequency { get; set; } = 1;

        public float Border { get; set; } = 300;

        public EdgeBehaviour EdgeBehaviour { get; set; } = EdgeBehaviour.None;

        public float Speed { get; set; } = 200;

        [EditorHintRange(0, MathF.Pi)]
        public float VisionAngle { get; set; } = MathF.Pi;

        public float VisionRadius { get; set; } = 150;

        public bool VisualDebug { get; set; } = false;

        public Rect Region { get; set; } = Rect.Align(Alignment.Center,
            0, 0, DualityApp.WindowSize.X, DualityApp.WindowSize.Y);
    }
}
