using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Duality;
using Duality.Drawing;

namespace Soulstone.Duality.Plugins.Atlas.Testing.Boids
{
    public interface IAgent
    {
        float StuckTime { get; set; }

        TurnDirection SteerBias { get; set; }

        SteeringNoise Noise { get; set; }

        bool LocalVisualDebug { get; set; } 

        ColorHsva NaturalColor { get; set; }

        Vector2 GetPosition();

        float GetAngle();

        ColorHsva GetColor();

        float GetScale();

        void ApplyPosition(Vector2 newPos);

        void ApplyAngle(float angle);

        void ApplyColor(ColorHsva color);

        void ApplyScale(float scale);

        Vector2 GetLocalPoint(Vector2 worldPoint);

        Vector2 GetWorldPoint(Vector2 localPoint);

        Vector2 GetLocalVector(Vector2 worldVector);

        Vector2 GetWorldVector(Vector2 localVector);
    }
}
