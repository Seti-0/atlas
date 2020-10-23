using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Duality;
using Duality.Drawing;

namespace Soulstone.Duality.Plugins.Atlas.Testing.Boids
{
    public class AlignmentBehaviour : AgentBehaviour
    {
        public FlockingParameters Alignment
        {
            get => AgentManager.GlobalParameters.Alignment;
        }

        protected override void OnApply()
        {
            bool visualDebug = Agent.LocalVisualDebug || General.VisualDebug;

            if (Alignment.Apply)
            {
                float visionRadius = Alignment.VisionRadius;
                float visionAngle = Alignment.VisionAngle;

                var neighbours = GetAgentNeighbours(visionRadius, visionAngle);

                float targetAngle = neighbours
                    .Select(x => x.GetAngle())
                    .Sum() / neighbours.Count();

                ApplyTargetAngle(targetAngle, Alignment.Strength);

                if (visualDebug && Alignment.ShowVision)
                    DrawAgentVision(visionRadius, visionAngle, false, new ColorRgba(255, 216, 71));
            }
        }
    }
}
