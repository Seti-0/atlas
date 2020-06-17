using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Duality;
using Duality.Components.Renderers;
using Duality.Drawing;

namespace Soulstone.Duality.Plugins.Atlas.Testing.Boids
{
    public class AgentBehaviour
    {
        protected Agent Agent { get; set; }

        protected float DeltaTime { get; set; }

        public AgentParameters General
        {
            get => AgentManager.GlobalParameters.General;
        }

        public void Init(Agent agent)
        {
            Agent = agent;
            DeltaTime = 0;
            OnInit();
        }

        protected virtual void OnInit(){}

        public void Apply(Agent agent, float dt)
        {
            Agent = agent;
            DeltaTime = dt;
            OnApply();
        }

        protected virtual void OnApply(){}

        protected void ApplyTargetAngle(float target, float strength)
        {
            var angle = Agent.GameObj.Transform.Angle;

            Agent.GameObj.Transform.Angle += SteerRecommendation(angle, target)
                    * Time.DeltaTime * strength;
        }

        protected void ApplyTargetHue(float targetHue, float strength)
        {
            var color = GetColor();
            float hue = color.H;

            if (MathF.Abs(hue - targetHue) > 0.01)
            {
                hue += Math.Sign(targetHue - hue) * Time.DeltaTime
                    * strength;

                ApplyColor(color.WithHue(hue));
            }
        }

        protected void ApplyColor(ColorHsva color)
        {
            var renderer = Agent.GameObj.GetComponent<SpriteRenderer>();
            if (renderer != null)
                renderer.ColorTint = color.ToRgba();
        }

        protected ColorHsva GetColor(Agent agent = null)
        {
            agent = agent ?? Agent;

            var renderer = agent.GameObj.GetComponent<SpriteRenderer>();
            if (renderer != null)
                return renderer.ColorTint.ToHsva();

            return agent.NaturalColor;
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
    }
}
