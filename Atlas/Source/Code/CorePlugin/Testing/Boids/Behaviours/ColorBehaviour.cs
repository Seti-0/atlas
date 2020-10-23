using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Duality;
using Duality.Components;
using Duality.Drawing;
using Duality.Resources;

namespace Soulstone.Duality.Plugins.Atlas.Testing.Boids
{
    public class ColorBehaviour : AgentBehaviour
    {
        public ColorParameters Color
        {
            get => AgentManager.GlobalParameters.Color;
        }

        protected override void OnApply()
        {
            bool visualDebug = Agent.LocalVisualDebug || General.VisualDebug;

            if (Color.Apply)
            {
                float visionRadius = Color.VisionRadius;
                float visionAngle = Color.VisionAngle;

                var neighbours = GetAgentNeighbours(visionRadius, visionAngle);

                /*float targetHue = hue;

                foreach (var neighbour in neighbours)
                    targetHue += neighbour.Boid.GetColor().H;

                targetHue /= neighbours.Count + 1f;
                */

                /*
                Agent target = null;
                float value = 0;

                foreach (var agent in neighbours)
                {
                    var currentTransform = agent.GameObj.Transform;
                    var currentValue = Vector2.Dot(
                        currentTransform.Pos.Xy - Agent.GameObj.Transform.Pos.Xy,
                        Agent.GameObj.Transform.Forward.Xy);

                    if (visualDebug && Color.ShowLinks)
                        DrawLink(agent, ColorRgba.Blue);

                    if (value < currentValue)
                    {
                        value = currentValue;
                        target = agent;
                    }
                }

                float targetHue;

                if (target == null)
                    targetHue = Agent.NaturalColor.H;

                else targetHue = GetColor(target).H;
                */
                /*
                if (visualDebug)
                {
                    if (Color.ShowVision)
                        Agent.DrawVision(visionRadius, visionAngle, false, new ColorRgba(194, 36, 235));

                    if (Color.ShowTarget && target != null)
                        DrawLink(target, ColorRgba.Red);
                }
                */

                var hues = neighbours
                    .Select(x => x.NaturalColor.H)
                    .ToList();

                hues.Add(Agent.NaturalColor.H);

                hues = hues
                    .Select(x => x * MathF.TwoPi)
                    .ToList();

                float targetHue = CircularAverage(hues) / MathF.TwoPi;

                ApplyTargetHue(targetHue, Color.Strength);
            }
        }
        private float CircularAverage(IEnumerable<float> input)
        {
            var n = input.Count();
            var vectors = input.Select(x => Vector2.FromAngleLength(x, 1));

            var acc = Vector2.Zero;

            foreach (var vector in vectors)
                acc += vector;

            acc /= n;

            if ((Agent.LocalVisualDebug || General.VisualDebug) && Color.ShowCircular)
            {
                foreach (var vector in vectors)
                    DrawColorVector(vector);

                DrawColorVector(Vector2.FromAngleLength(acc.Angle, 2));
            }

            return acc.Angle;
        }

        private void DrawColorVector(Vector2 vector)
        {
            var camera = Scene.Current.FindComponent<Camera>();

            var screenOrigin = camera.GetScreenPos(Vector2.Zero);
            var screenEnd = camera.GetScreenPos(100 * vector);

            var color = ColorHsva.Red.WithHue(vector.Angle / MathF.TwoPi);

            VisualLogs.Default
                .DrawVector(screenOrigin, screenEnd - screenOrigin)
                .WithColor(color.ToRgba());
        }

        private void DrawLink(Agent target, ColorRgba color)
        {
            var camera = Scene.Current.FindComponent<Camera>();

            var screenOrigin = camera.GetScreenPos(
                Agent.GetWorldPoint(Vector2.Zero));

            var screenEnd = camera.GetScreenPos(target.GameObj.Transform.Pos.Xy);

            VisualLogs.Default
                .DrawVector(screenOrigin, screenEnd - screenOrigin)
                .WithColor(color);
        }
    }
}
