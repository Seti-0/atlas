using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Duality;
using Duality.Components;
using Duality.Components.Renderers;
using Duality.Drawing;
using Duality.Editor;
using Duality.Resources;
using Soulstone.Duality.Plugins.Atlas.Components;
using Soulstone.Duality.Plugins.Atlas.Interface;

namespace Soulstone.Duality.Plugins.Atlas.Testing.Boids.Network
{
    [EditorHintCategory(CategoryNames.Testing)]
    public class ClientAgent : ClientComponent<AgentState>, IAgent, ICmpInitializable
    {
        private AgentState _state = new AgentState();

        public float StuckTime
        {
            get => _state.StuckTime;
            set => _state.StuckTime = value;
        }

        public TurnDirection SteerBias
        {
            get => _state.SteerBias;
            set => _state.SteerBias = value;
        }

        public SteeringNoise Noise
        {
            get => _state.Noise;
            set => _state.Noise = value;
        }

        public bool LocalVisualDebug
        {
            get => _state.LocalVisualDebug;
            set => _state.LocalVisualDebug = value;
        }

        public ColorHsva NaturalColor
        {
            get => _state.NaturalColor;
            set => _state.NaturalColor = value;
        }

        public override void OnUpdate(AgentState newValue)
        {
            _state = newValue;

            ApplyPosition(_state.Position);
            ApplyAngle(_state.Angle);
            ApplyColor(_state.Color);
            ApplyScale(_state.Scale);
        }

        public Vector2 GetPosition()
        {
            return _state.Position;
        }

        public void ApplyPosition(Vector2 newPos)
        {
            _state.Position = newPos;

            if (GameObj?.Transform != null)
                GameObj.Transform.Pos = new Vector3(newPos);
        }

        public float GetAngle()
        {
            return _state.Angle;
        }

        public void ApplyAngle(float angle)
        {
            _state.Angle = angle;

            if (GameObj?.Transform != null)
                GameObj.Transform.Angle = angle;
        }

        public void ApplyColor(ColorHsva color)
        {
            _state.Color = color;

            var renderer = GameObj.GetComponent<SpriteRenderer>();
            if (renderer != null)
                renderer.ColorTint = color.ToRgba();
        }

        public ColorHsva GetColor()
        {
            return _state.Color;
        }

        public float GetScale()
        {
            return GameObj.Transform.Scale;
        }

        public void ApplyScale(float scale)
        {
            _state.Scale = scale;

            if (GameObj?.Transform != null)
                GameObj.Transform.Scale = scale;
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

        public void OnActivate()
        {
            GameObj.AddComponent<Transform>();

            var renderer = GameObj.AddComponent<SpriteRenderer>();
            renderer.Rect = new Rect(-16, -17, 32, 34);
            renderer.SharedMaterial = ContentProvider
                .GetAvailableContent<Material>("Data/Test Scenes/Boids")
                .FirstOrDefault();
        }

        public void OnDeactivate(){}
    }
}
