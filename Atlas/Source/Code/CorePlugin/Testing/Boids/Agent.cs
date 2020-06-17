using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Duality;
using Duality.Components;
using Duality.Components.Renderers;
using Duality.Drawing;
using Duality.Editor;

namespace Soulstone.Duality.Plugins.Atlas.Testing.Boids
{
    public enum TurnDirection
    {
        Right, Left
    }

    [RequiredComponent(typeof(SpriteRenderer))]
    [RequiredComponent(typeof(Transform))]
    [EditorHintCategory(CategoryNames.Testing)]
    public class Agent : Component
    {
        public float StuckTime { get; set; }

        public TurnDirection SteerBias = TurnDirection.Left;

        public SteeringNoise Noise { get; set; } = new SteeringNoise();

        public bool LocalVisualDebug { get; set; } = false;

        public ColorHsva NaturalColor { get; set; } = ColorHsva.Red;

        public IEnumerable<Agent> GetNeighbours(float visionRadius, float visionAngle)
        {
            var agents = Scene.FindComponents<Agent>();

            foreach (var agent in agents)
            {
                if (agent == this) continue;
                if (agent.GameObj?.Transform == null) continue;

                var agentTransform = agent.GameObj.Transform;
                var transform = GameObj.Transform;

                var delta = transform.GetLocalPoint(agentTransform.Pos.Xy);

                if (delta.Length > visionRadius) continue;

                var angle = MathF.NormalizeAngle(delta.Angle);
                if (angle > visionAngle && angle < MathF.TwoPi - visionAngle) continue;

                yield return agent;
            }
        }

        public void DrawVision(float visionRadius, float visionAngle, bool drawArrows, ColorRgba color)
        {
            int n = 20;
            Vector2[] points = new Vector2[2 * n + 2];

            var transform = GameObj.Transform;
            var camera = Scene.FindComponent<Camera>();

            points[0] = camera.GetScreenPos(transform.GetWorldPoint(Vector2.Zero));
            points[(2 * n) + 1] = points[0];

            var visionPoints = GetVisionPoints(n, visionRadius, visionAngle).ToArray();

            for (int i = 0; i < 2 * n; i++)
                points[i + 1] = camera.GetScreenPos(visionPoints[i]);

            VisualLogs.Default.BaseColor = ColorRgba.White;

            var log = VisualLogs.Default
                .DrawPolygon(Vector2.Zero, points)
                .WithColor(color);

            if (drawArrows)
            {
                var origin = transform.Pos;
                var screenOrigin = camera.GetScreenPos(origin);

                foreach (var boid in GetNeighbours(visionRadius, visionAngle))
                {
                    var target = boid.GameObj.Transform.Pos;
                    var screenTarget = camera.GetScreenPos(target);

                    VisualLogs.Default.DrawVector(screenOrigin, screenTarget - screenOrigin);
                }
            }
        }

        private IEnumerable<Vector2> GetVisionPoints(int n, float visionRadius, float visionAngle)
        {
            var transform = GameObj.Transform;

            for (int i = 0; i < n; i++)
            {
                float angle = -(visionAngle * (n - i - 1)) / (n - 1);

                Vector2 localPos = new Vector2(MathF.Sin(angle), -MathF.Cos(angle));
                localPos *= visionRadius;

                yield return transform.GetWorldPoint(localPos);
            }

            for (int i = 0; i < n; i++)
            {
                float angle = visionAngle * i / (n - 1);

                Vector2 localPos = new Vector2(MathF.Sin(angle), -MathF.Cos(angle));
                localPos *= visionRadius;

                yield return transform.GetWorldPoint(localPos);
            }
        }
    }
}
