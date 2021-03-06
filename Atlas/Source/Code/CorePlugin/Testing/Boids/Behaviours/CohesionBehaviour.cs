﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Duality;
using Duality.Drawing;

namespace Soulstone.Duality.Plugins.Atlas.Testing.Boids
{
    public class CohesionBehaviour : AgentBehaviour
    {
        public FlockingParameters Cohesion
        {
            get => AgentManager.GlobalParameters.Cohesion;
        }

        protected override void OnApply()
        {
            bool visualDebug = Agent.LocalVisualDebug || General.VisualDebug;

            if (Cohesion.Apply)
            {
                float visionRadius = Cohesion.VisionRadius;
                float visionAngle = Cohesion.VisionAngle;

                var neighbours = GetAgentNeighbours(visionRadius, visionAngle);

                var averagePos = Vector2.Zero;
                foreach (var neighbour in neighbours)
                    averagePos += neighbour.GetPosition();
                averagePos /= neighbours.Count();

                float targetAngle = (averagePos - Agent.GetPosition()).Angle;

                ApplyTargetAngle(targetAngle, Cohesion.Strength);

                if (visualDebug && Cohesion.ShowVision)
                    DrawAgentVision(visionRadius, visionAngle, false, new ColorRgba(71, 93, 255));
            }
        }
    }
}
