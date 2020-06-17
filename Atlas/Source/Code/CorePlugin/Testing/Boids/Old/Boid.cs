using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using Duality;
using Duality.Components;
using Duality.Components.Renderers;
using Duality.Drawing;
using Duality.Editor;

namespace Soulstone.Duality.Plugins.Atlas.Testing.Boids
{
    [RequiredComponent(typeof(SpriteRenderer))]
    [RequiredComponent(typeof(Transform))]
    [EditorHintCategory(CategoryNames.Testing)]
    public class Boid : Component, ICmpUpdatable, ICmpInitializable
    {
        public bool LocalVisualDebug { get; set; } = false;

        private static HashSet<Boid> boids = new HashSet<Boid>();
        private static readonly Random globalRandom = new Random();

        private readonly Random _random = new Random(globalRandom.Next());
        private double _lastRandomTime;
        private float _randomValue;

        private ColorHsva _naturalColor;

        public GeneralParameters General
        {
            get => BoidGroup.GlobalGeneral;
        }

        public AllSteeringParameters Steering
        {
            get => BoidGroup.GlobalSteering;
        }

        public void OnActivate()
        {
            boids.Add(this);

            float hue = _random.NextFloat(0, 1);
            _naturalColor = General.BaseColor.WithHue(hue);

            ApplyColor(_naturalColor);
        }


        private void ApplyColor(ColorHsva color)
        {
            var renderer = GameObj.GetComponent<SpriteRenderer>();
            if (renderer != null)
                renderer.ColorTint = color.ToRgba();
        }

        private ColorHsva GetColor()
        {
            var renderer = GameObj.GetComponent<SpriteRenderer>();
            if (renderer != null)
                return renderer.ColorTint.ToHsva();

            return _naturalColor;
        }

        public void OnDeactivate()
        {
            boids.Remove(this);
        }

        public void OnUpdate()
        {
            if (GameObj.Transform == null) return;

            ApplyVel();

            var neighbours = GetNeighbours();

            //CheckDebugColor(neighbours.Select(x => x.Boid));
            if (General.VisualDebug || LocalVisualDebug) DrawVisualDebug(neighbours.Select(x => x.Boid));

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
                float targetAngle = (float) RandomNext() * MathF.TwoPi;
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

            if (Steering.ApplyColorMerge)
            {
                var color = GetColor();
                float hue = color.H;

                /*float targetHue = hue;

                foreach (var neighbour in neighbours)
                    targetHue += neighbour.Boid.GetColor().H;

                targetHue /= neighbours.Count + 1f;
                */

                Boid target = null;
                float value = 0;

                foreach (var boid in neighbours.Select(x => x.Boid))
                {
                    var currentTransform = boid.GameObj.Transform;
                    var currentValue = Vector2.Dot(currentTransform.Pos.Xy,
                        GameObj.Transform.Forward.Xy);

                    if (value < currentValue)
                    {
                        value = currentValue;
                        target = boid;
                    }
                }

                float targetHue;

                if (target == null)
                    targetHue = _naturalColor.H;

                else targetHue = target.GetColor().H;

                /*
                var hues = neighbours
                    .Select(x => x.Boid.GetColor().H)
                    .ToList();

                hues.Add(hue);

                hues = hues
                    .Select(x => x * MathF.TwoPi)
                    .ToList();

                float targetHue = CircularAverage(hues) / MathF.TwoPi;

                if (neighbours.Count == 0)
                    targetHue = _naturalColor.H;

                */

                if (MathF.Abs(hue - targetHue) > 0.01)
                {
                    hue += Math.Sign(targetHue - hue) * Time.DeltaTime
                        * Steering.ColorMergeStrength;

                    ApplyColor(color.WithHue(hue));
                }
            }

            if (Steering.ApplyAvoidance)
            {
                var transform = GameObj.Transform;
                var camera = Scene.FindComponent<Camera>();

                var origin = transform.GetWorldPoint(Vector2.Zero);
                var screenOrigin = camera.GetScreenPos(origin);

                bool avoid = false;
                Vector2 threat = Vector2.Zero;

                var currentShape = Scene.Physics.PickShape(origin);
                if (currentShape != null)
                {
                    threat = currentShape.Parent.WorldMassCenter;
                    avoid = true;

                    if (LocalVisualDebug || General.VisualDebug)
                    {
                        var screenThreat = camera.GetScreenPos(threat);
                        VisualLogs.Default.DrawVector(screenOrigin, screenThreat - screenOrigin)
                            .WithColor(ColorRgba.Red);
                    }
                }
                else
                {
                    var targets = GetVisionPoints(3).ToArray();
                    var screenTargets = targets
                        .Select(x => camera.GetScreenPos(x))
                        .ToArray();

                    var averageCollisionPoint = Vector2.Zero;
                    var collisionCount = 0;

                    for (int i = 0; i < targets.Length; i++)
                    {
                        bool hit = Scene.Physics.RayCast(origin, targets[i], d => 0, out var data);

                        ColorRgba color = hit ? ColorRgba.Green : ColorRgba.Red;

                        if (LocalVisualDebug || General.VisualDebug)
                        {
                            VisualLogs.Default.DrawConnection(screenOrigin, screenTargets[i])
                                .WithColor(color);
                        }

                        if (hit)
                        {
                            collisionCount++;

                            var pos = data.Pos;
                            if ((data.Pos - GameObj.Transform.Pos.Xy).Length < 1)
                                pos = data.Body.WorldMassCenter;

                            if (LocalVisualDebug || General.VisualDebug)
                                VisualLogs.Default.DrawPoint(camera.GetScreenPos(pos));

                            averageCollisionPoint += data.Pos;
                        }
                    }

                    if (collisionCount > 0)
                    {
                        avoid = true;
                        averageCollisionPoint /= collisionCount;
                        threat = averageCollisionPoint;
                    }
                }

                if (avoid)
                {
                    var localPos = GameObj.Transform.GetLocalPoint(threat);
                    float targetAngle = localPos.Angle + MathF.Pi + GameObj.Transform.Angle;

                    ApplyTarget(targetAngle, Steering.AvoidanceStrength);

                    if (LocalVisualDebug || General.VisualDebug)
                    {
                        VisualLogs.Default.DrawPoint(camera.GetScreenPos(
                            origin + Vector2.FromAngleLength(targetAngle,
                            GameObj.Transform.Scale * General.VisionRadius)));
                    }
                }
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

            return acc.Angle;
        }

        private float RandomNext()
        {
            if (Time.MainTimer.TotalSeconds - _lastRandomTime > 1 / General.NoiseFrequency)
            {
                _randomValue = _random.NextFloat();
                _lastRandomTime = Time.MainTimer.TotalSeconds;
            }

            return _randomValue;
        }

        private void ApplyTarget(float target, float strength)
        {
            var angle = GameObj.Transform.Angle;

            GameObj.Transform.Angle += SteerRecommendation(angle, target)
                    * Time.DeltaTime * strength;
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

        private class Neighbour
        {
            public Vector2 LocalPos;
            public float LocalAngle;
            public float LocalDirection;

            public Boid Boid;
        }

        private List<Neighbour> GetNeighbours()
        {
            List<Neighbour> neighbours = new List<Neighbour>();

            foreach (var boid in boids)
            {
                if (boid == this) continue;
                if (boid.GameObj?.Transform == null) continue;

                var delta = GameObj.Transform.GetLocalPoint(boid.GameObj.Transform.Pos.Xy);

                if (delta.Length > General.VisionRadius) continue;

                var angle = MathF.NormalizeAngle(delta.Angle);
                if (angle > General.VisionAngle && angle < MathF.TwoPi - General.VisionAngle) continue;

                neighbours.Add(new Neighbour
                {
                    LocalPos = delta,
                    LocalAngle = angle,
                    Boid = boid,
                    
                    LocalDirection = boid.GameObj.Transform.Angle
                });
            }

            return neighbours;
        }

        private void ApplyVel()
        {
            var localPos = GameObj.Transform.LocalPos;
            localPos += GameObj.Transform.LocalForward * General.Speed * Time.DeltaTime;

            Vector3 globalPos;

            if (GameObj.Parent?.Transform == null)
                globalPos = localPos;
            else
                globalPos = GameObj.Parent.Transform.GetWorldPoint(localPos);

            var border = General.Border;

            var left = -border + General.Region.LeftX;
            var right = border + General.Region.RightX;
            var bottom = -border + General.Region.TopY;
            var top = border + General.Region.BottomY;

            if (globalPos.X < left) globalPos.X = right + (globalPos.X - left);
            else if (globalPos.X > right) globalPos.X = left + (globalPos.X - right);

            if (globalPos.Y < bottom) globalPos.Y = top + (globalPos.Y - bottom);
            else if (globalPos.Y > top) globalPos.Y = bottom + (globalPos.Y - top);

            GameObj.Transform.Pos = globalPos;
        }

        /*private void CheckDebugColor(IEnumerable<Boid> neighbours)
        {
            if (Time.FrameCount > frameCount)
            {
                foreach (var boid in boids)
                    boid._debugColor = null;

                frameCount = Time.FrameCount;
            }

            foreach (var boid in neighbours)
                if (boid._debugColor != null)
                    _debugColor = boid._debugColor;

            if (_debugColor == null)
            {
                float hue = _random.NextFloat(0,1);
                ColorHsva newColor = General.BaseColor
                    .WithHue(hue);

                _debugColor = newColor.ToRgba();
            }
        }*/

        private void DrawVisualDebug(IEnumerable<Boid> neighbours)
        {
            DrawVisionArea();

            foreach (var boid in neighbours)
            {
                var localPos = GameObj.Transform.GetLocalPoint(boid.GameObj.Transform.Pos.Xy);
                DrawVector(localPos, ColorRgba.Red);
            }
        }

        private IEnumerable<Vector2> GetVisionPoints(int n)
        {
            var transform = GameObj.Transform;

            for (int i = 0; i < n; i++)
            {
                float angle = -(General.VisionAngle * (n - i - 1)) / (n - 1);

                Vector2 localPos = new Vector2(MathF.Sin(angle), -MathF.Cos(angle));
                localPos *= General.VisionRadius;

                yield return transform.GetWorldPoint(localPos);
            }

            for (int i = 0; i < n; i++)
            {
                float angle = (General.VisionAngle * i) / (n - 1);

                Vector2 localPos = new Vector2(MathF.Sin(angle), -MathF.Cos(angle));
                localPos *= General.VisionRadius;

                yield return transform.GetWorldPoint(localPos);

            }
        }

        private void DrawVisionArea()
        {
            int n = 20;
            Vector2[] points = new Vector2[2*n + 2];

            var transform = GameObj.Transform;
            var camera = Scene.FindComponent<Camera>();

            points[0] = camera.GetScreenPos(transform.GetWorldPoint(Vector2.Zero));
            points[(2*n)+1] = points[0];

            var visionPoints = GetVisionPoints(n).ToArray();

            for (int i = 0; i < 2 * n; i++)
                points[i + 1] = camera.GetScreenPos(visionPoints[i]);

            VisualLogs.Default
                .DrawPolygon(Vector2.Zero, points)
                .WithColor(ColorRgba.Blue);
        }

        private Vector2 ScreenPos(Vector2 localPos)
        {
            Vector2 globalPos = GameObj.Transform.GetWorldPoint(localPos);
            return Scene.FindComponent<Camera>().GetScreenPos(globalPos);
        }

        private void DrawVector(Vector2 localVector, ColorRgba color)
        {
            var origin = ScreenPos(Vector2.Zero);
            var point = ScreenPos(localVector);

            VisualLogs.Default
                .DrawVector(origin, point - origin)
                .WithColor(ColorRgba.Red);
        }
    }
}
