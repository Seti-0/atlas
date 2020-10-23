using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Duality;
using Duality.Components;
using Duality.Components.Physics;
using Duality.Drawing;
using Duality.Resources;

namespace Soulstone.Duality.Plugins.Atlas.Testing.Boids
{
    public class AvoidanceBehaviour : AgentBehaviour
    {
        public AvoidanceParameters Avoidance
        {
            get => AgentManager.GlobalParameters.Avoidance;
        }

        protected override void OnApply()
        {
            if (Avoidance.Apply)
            {
                var currentShape = Scene.Current.Physics.PickShape(
                    Agent.GetWorldPoint(Vector2.Zero));

                var left = CastRay(-Avoidance.VisionAngle);
                var right = CastRay(Avoidance.VisionAngle);

                float targetDirection = 0;

                if (currentShape != null)
                {
                    Agent.StuckTime += DeltaTime;
                    left = true;
                    right = true;
                }

                else Agent.StuckTime = 0;

                DrawRay(left, -Avoidance.VisionAngle);
                DrawRay(right, Avoidance.VisionAngle);

                if (left && !right)
                {
                    Agent.SteerBias = TurnDirection.Right;
                    targetDirection = 1;
                }

                else if (right & !left)
                {
                    Agent.SteerBias = TurnDirection.Left;
                    targetDirection = -1;
                }

                else if (right && left)
                {
                    targetDirection = Agent.SteerBias == TurnDirection.Right ?
                        1 : -1;
                }

                if (Agent.StuckTime < 1)
                {
                    var angle = Agent.GetAngle();
                    angle += DeltaTime * Avoidance.Strength * targetDirection;
                    Agent.ApplyAngle(angle);
                }
            }
        }

        private bool CastRay(float localAngle)
        {
            var localVector = Vector2.FromAngleLength(localAngle, Avoidance.VisionRadius);
            var globalVector = Agent.GetWorldVector(localVector);

            var origin = Agent.GetWorldPoint(Vector2.Zero);

            bool hit = Scene.Current.Physics.RayCast(origin, origin + globalVector, d => 0, out var data);

            return hit;
        }

        private void DrawRay(bool hit, float angle)
        {
            if ((Agent.LocalVisualDebug || General.VisualDebug) && Avoidance.ShowVision)
            {
                var globalVector = Agent.GetWorldVector(
                    Vector2.FromAngleLength(angle, Avoidance.VisionRadius));

                var origin = Agent.GetWorldPoint(Vector2.Zero);

                var camera = Scene.Current.FindComponent<Camera>();

                var screenOrigin = camera.GetScreenPos(origin);
                var screenEnd = camera.GetScreenPos(origin + globalVector);

                var color = hit ? ColorRgba.Green : ColorRgba.Red;

                VisualLogs.Default.DrawVector(screenOrigin, screenEnd - screenOrigin)
                    .WithColor(color);
            }
        }
    }
}
