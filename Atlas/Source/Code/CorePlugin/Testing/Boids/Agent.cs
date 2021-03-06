﻿using System;
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
    public class Agent : Component, IAgent
    {
        public float StuckTime { get; set; }

        public TurnDirection SteerBias { get; set; } = TurnDirection.Left;

        public SteeringNoise Noise { get; set; } = new SteeringNoise();

        public bool LocalVisualDebug { get; set; } = false;

        public ColorHsva NaturalColor { get; set; } = ColorHsva.Red;

        public Vector2 GetPosition()
        {
            return GameObj.Transform.Pos.Xy;
        }

        public void ApplyPosition(Vector2 newPos)
        {
            if (GameObj?.Transform != null)
                GameObj.Transform.Pos = new Vector3(newPos);
        }

        public float GetAngle()
        {
            return GameObj.Transform.Angle;
        }

        public void ApplyAngle(float angle)
        {
            if (GameObj?.Transform != null)
                GameObj.Transform.Angle = angle;
        }

        public float GetScale()
        {
            return GameObj.Transform.Scale;
        }

        public void ApplyScale(float scale)
        {
            if (GameObj?.Transform != null)
                GameObj.Transform.Scale = scale;
        }

        public void ApplyColor(ColorHsva color)
        {
            var renderer = GameObj.GetComponent<SpriteRenderer>();
            if (renderer != null)
                renderer.ColorTint = color.ToRgba();
        }

        public ColorHsva GetColor()
        {
            var renderer = GameObj.GetComponent<SpriteRenderer>();
            if (renderer != null)
                return renderer.ColorTint.ToHsva();

            return NaturalColor;
        }

        public Vector2 GetLocalPoint(Vector2 worldPoint)
        {
            return GameObj.Transform.GetLocalPoint(worldPoint);
        }

        public Vector2 GetWorldPoint(Vector2 localPoint)
        {
            return GameObj.Transform.GetWorldPoint(localPoint);
        }

        public Vector2 GetLocalVector(Vector2 worldVector)
        {
            return GameObj.Transform.GetLocalVector(worldVector);
        }

        public Vector2 GetWorldVector(Vector2 localVector)
        {
            return GameObj.Transform.GetWorldVector(localVector);
        }
    }
}
