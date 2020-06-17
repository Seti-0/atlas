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
            ApplyColor(Agent.NaturalColor);
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
            var transform = Agent.GameObj.Transform;

            var localPos = transform.LocalPos;
            localPos += transform.LocalForward * General.Speed * DeltaTime;

            var globalPos = localPos;

            if (Agent.GameObj.Parent?.Transform != null)
                globalPos = Agent.GameObj.Parent.Transform.GetWorldPoint(localPos);

            if (General.EdgeBehaviour == EdgeBehaviour.Wrap)
            {
                var border = General.Border;
                var left = -border + General.Region.LeftX;
                var right = border + General.Region.RightX;
                var bottom = -border + General.Region.TopY;
                var top = border + General.Region.BottomY;

                if (globalPos.X < left) globalPos.X = right + (globalPos.X - left);
                else if (globalPos.X > right) globalPos.X = left + (globalPos.X - right);

                if (globalPos.Y < bottom) globalPos.Y = top + (globalPos.Y - bottom);
                else if (globalPos.Y > top) globalPos.Y = bottom + (globalPos.Y - top);
            }

            transform.Pos = globalPos;
        }
    }
}
