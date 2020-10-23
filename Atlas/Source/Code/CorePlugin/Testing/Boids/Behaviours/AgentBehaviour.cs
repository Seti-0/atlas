using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Duality;
using Duality.Components;
using Duality.Components.Renderers;
using Duality.Drawing;
using Duality.Resources;

namespace Soulstone.Duality.Plugins.Atlas.Testing.Boids
{
    public class AgentBehaviour
    {
        protected IAgent Agent { get; set; }

        protected float DeltaTime { get; set; }

        public IEnumerable<IAgent> Population { get; set; }

        public AgentParameters General
        {
            get => AgentManager.GlobalParameters.General;
        }

        public void Init(IAgent agent)
        {
            Agent = agent;
            DeltaTime = 0;
            OnInit();
        }

        protected virtual void OnInit(){}

        public void Apply(IAgent agent, float dt)
        {
            Agent = agent;
            DeltaTime = dt;
            OnApply();
        }

        protected virtual void OnApply(){}

        protected void ApplyTargetAngle(float target, float strength)
        {
            var angle = Agent.GetAngle();

            angle += SteerRecommendation(angle, target)
                    * Time.DeltaTime * strength;

            Agent.ApplyAngle(angle);
        }

        protected void ApplyTargetHue(float targetHue, float strength)
        {
            var color = Agent.GetColor();
            float hue = color.H;

            if (MathF.Abs(hue - targetHue) > 0.01)
            {
                hue += Math.Sign(targetHue - hue) * Time.DeltaTime
                    * strength;

                Agent.ApplyColor(color.WithHue(hue));
            }
        }

        private float SteerRecommendation(float angle, float target)
        {
            if (MathF.Abs(angle - target) < 0.02)
                return 0;

            angle = MathF.NormalizeAngle(angle);
            target = MathF.NormalizeAngle(target);

            if (MathF.Abs(angle - target) > MathF.Pi)
            {
                if (angle < MathF.Pi)
                    target -= MathF.TwoPi;

                else target += MathF.TwoPi;
            }

            return MathF.Sign(target - angle);
        }

        protected IEnumerable<IAgent> GetAgentNeighbours(float visionRadius, float visionAngle)
        {
            foreach (var otherAgent in Population)
            {
                if (otherAgent == Agent) continue;

                var delta = Agent.GetLocalPoint(otherAgent.GetPosition());

                if (delta.Length > visionRadius) continue;

                var angle = MathF.NormalizeAngle(delta.Angle);
                if (angle > visionAngle && angle < MathF.TwoPi - visionAngle) continue;

                yield return otherAgent;
            }
        }

        protected void DrawAgentVision(float visionRadius, float visionAngle,
            bool drawArrows, ColorRgba color)
        {
            int n = 20;
            Vector2[] points = new Vector2[2 * n + 2];

            var camera = Scene.Current.FindComponent<Camera>();

            points[0] = camera.GetScreenPos(Agent.GetWorldPoint(Vector2.Zero));
            points[(2 * n) + 1] = points[0];

            var visionPoints = GetVisionPoints(n, visionRadius, visionAngle).ToArray();

            for (int i = 0; i < 2 * n; i++)
                points[i + 1] = camera.GetScreenPos(visionPoints[i]);

            VisualLogs.Default.BaseColor = ColorRgba.White;

            VisualLogs.Default
                .DrawPolygon(Vector2.Zero, points)
                .WithColor(color);

            if (drawArrows)
            {
                var origin = Agent.GetPosition();
                var screenOrigin = camera.GetScreenPos(origin);

                foreach (var otherAgent in GetAgentNeighbours(visionRadius, visionAngle))
                {
                    var target = otherAgent.GetPosition();
                    var screenTarget = camera.GetScreenPos(target);

                    VisualLogs.Default.DrawVector(screenOrigin, screenTarget - screenOrigin);
                }
            }
        }

        private IEnumerable<Vector2> GetVisionPoints(int n, float visionRadius, float visionAngle)
        {
            for (int i = 0; i < n; i++)
            {
                float angle = -(visionAngle * (n - i - 1)) / (n - 1);

                Vector2 localPos = new Vector2(MathF.Sin(angle), -MathF.Cos(angle));
                localPos *= visionRadius;

                yield return Agent.GetWorldPoint(localPos);
            }

            for (int i = 0; i < n; i++)
            {
                float angle = visionAngle * i / (n - 1);

                Vector2 localPos = new Vector2(MathF.Sin(angle), -MathF.Cos(angle));
                localPos *= visionRadius;

                yield return Agent.GetWorldPoint(localPos);
            }
        }
    }
}
