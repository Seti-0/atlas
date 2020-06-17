/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

using Duality;

namespace Soulstone.Duality.Plugins.Atlas.Testing.Boids
{
    public class BoidSystem : Component, ICmpUpdatable
    {
        public GeneralParameters General { get; set; } = new GeneralParameters();

        public SteeringParameters Steering { get; set; } = new SteeringParameters();

        public void OnUpdate()
        {
            if (GameObj.Transform == null) return;

            var boids = Scene
                .FindComponents<Boid>()
                .ToArray();

            int n = boids.Length;

            List<Boid>[] neighbours = GetNeighbours(boids)
                .Select(x => x.ToList())
                .ToArray();

            for (int i = 0; i < n; i++)
            {
                neighbours = boids[i]
            }

            ApplyVel();

            var neighbours = GetNeighbours();

            CheckDebugColor(neighbours.Select(x => x.Boid));
            DrawVisualDebug(neighbours.Select(x => x.Boid));

            if (Steering.ApplyAlignment)
            {
                float targetAngle = neighbours
                    .Select(x => x.LocalDirection)
                    .Sum() / neighbours.Count;

                ApplyTarget(targetAngle, Steering.AlignmentStrength);
            }

            if (Steering.ApplyCohesion)
            {
                var averagePos = Vector2.Zero;
                foreach (var neighbour in neighbours)
                    averagePos += neighbour.LocalPos;
                averagePos /= neighbours.Count;

                float targetAngle = averagePos.Angle;
                targetAngle += GameObj.Transform.Angle;

                ApplyTarget(targetAngle, Steering.CohesionStrength);
            }

            if (Steering.ApplySeparation)
            {
                foreach (var neighbour in neighbours)
                {
                    float targetAngle = neighbour.LocalPos.Angle + MathF.Pi;
                    targetAngle += GameObj.Transform.Angle;

                    ApplyTarget(targetAngle, Steering.SeparationStrength);
                }
            }

            if (Steering.ApplyNoise)
            {
                float targetAngle = (float)RandomNext() * MathF.TwoPi;
                ApplyTarget(targetAngle, Steering.NoiseStrength);
            }

            if (Steering.ApplyMouse)
            {
                Vector2 worldPos = Scene
                    .FindComponent<Camera>()
                    .GetWorldPos(DualityApp.Mouse.Pos)
                    .Xy;

                Vector2 targetLocalPos = GameObj.Transform.GetLocalPoint(worldPos);

                float targetAngle = targetLocalPos.Angle;
                targetAngle += GameObj.Transform.Angle;

                ApplyTarget(targetAngle, Steering.MouseStrength);
            }
        }

        public IEnumerable<Boid>[] GetNeighbours(Boid[] population)
        {
            int n = population.Length;
            var targets = new HashSet<Boid>[n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    var subject = population[i];
                    var target = population[j];

                    var subjectTransform = subject.GameObj.Transform;
                    var targetTransform = target.GameObj.Transform;

                    if (subjectTransform == null || targetTransform == null) continue;

                    var delta = subjectTransform.GetLocalPoint(targetTransform.Pos.Xy);

                    if (delta.Length > General.VisionRadius) continue;

                    var angle = MathF.NormalizeAngle(delta.Angle);
                    if (angle > General.VisionAngle && angle < MathF.TwoPi - General.VisionAngle) continue;

                    targets[i].Add(target);
                }
            }

            return targets;
        }
    }
}
*/