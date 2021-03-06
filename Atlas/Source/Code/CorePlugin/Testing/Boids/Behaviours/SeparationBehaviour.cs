﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Duality;
using Duality.Drawing;

namespace Soulstone.Duality.Plugins.Atlas.Testing.Boids
{
    public class SeparationBehaviour : AgentBehaviour
    {
        public FlockingParameters Separation
        {
            get => AgentManager.GlobalParameters.Separation;
        }

        protected override void OnApply()
        {
            bool visualDebug = Agent.LocalVisualDebug || General.VisualDebug;

            if (Separation.Apply)
            {
                float visionRadius = Separation.VisionRadius;
                float visionAngle = Separation.VisionAngle;

                var neighbours = GetAgentNeighbours(visionRadius, visionAngle);

                foreach (var neighbour in neighbours)
                {
                    var delta = neighbour.GetPosition() - Agent.GetPosition();
                    float targetAngle = delta.Angle + MathF.Pi;

                    ApplyTargetAngle(targetAngle, Separation.Strength);
                }

                if (visualDebug && Separation.ShowVision)
                    DrawAgentVision(visionRadius, visionAngle, false, new ColorRgba(254, 63, 86));
            }
        }
    }
}
