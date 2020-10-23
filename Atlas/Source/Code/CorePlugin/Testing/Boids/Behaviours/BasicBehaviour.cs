using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Duality;

namespace Soulstone.Duality.Plugins.Atlas.Testing.Boids.Behaviours
{
    public class BasicBehaviour : AgentBehaviour
    {
        private static Random random = new Random();

        protected override void OnInit()
        {
            float hue = (float) random.NextDouble();
            Agent.NaturalColor = AgentManager.GlobalParameters.General.BaseColor.WithHue(hue);
            Agent.ApplyColor(Agent.NaturalColor);
        }

        protected override void OnApply()
        {
            ApplyNoise();
            ApplyVel();
        }

        private void ApplyNoise()
        {
            if (General.Noise.Apply)
            {
                Agent.Noise.MaxDuration = General.Noise.Duration;
                float targetAngle = Agent.Noise.Next(DeltaTime) * MathF.TwoPi;
                ApplyTargetAngle(targetAngle, General.Noise.Strength);
            }
        }

        private void ApplyVel()
        {
            var pos = Agent.GetPosition();
            var angle = Agent.GetAngle();

            var forward = new Vector2(MathF.Sin(angle), -MathF.Cos(angle));
            pos += forward * General.Speed * DeltaTime;

            if (General.EdgeBehaviour == EdgeBehaviour.Wrap)
            {
                var border = General.Border;
                var left = -border + General.Region.LeftX;
                var right = border + General.Region.RightX;
                var bottom = -border + General.Region.TopY;
                var top = border + General.Region.BottomY;

                if (pos.X < left) pos.X = right + (pos.X - left);
                else if (pos.X > right) pos.X = left + (pos.X - right);

                if (pos.Y < bottom) pos.Y = top + (pos.Y - bottom);
                else if (pos.Y > top) pos.Y = bottom + (pos.Y - top);
            }

            Agent.ApplyPosition(pos);
        }
    }
}
