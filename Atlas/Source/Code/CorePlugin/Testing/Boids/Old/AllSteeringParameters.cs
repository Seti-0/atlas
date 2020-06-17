namespace Soulstone.Duality.Plugins.Atlas.Testing.Boids
{
    public class AllSteeringParameters
    {
        public bool ApplyAlignment { get; set; } = false;

        public float AlignmentStrength { get; set; } = 1;

        public bool ApplyCohesion { get; set; } = false;

        public float CohesionStrength { get; set; } = 1;

        public bool ApplySeparation { get; set; } = false;

        public float SeparationStrength { get; set; } = 1;

        public bool ApplyNoise { get; set; } = false;

        public float NoiseStrength { get; set; } = 1;

        public bool ApplyMouse { get; set; } = false;

        public float MouseStrength { get; set; } = 1;

        public bool ApplyColorMerge { get; set; } = false;

        public float ColorMergeStrength { get; set; } = 1;

        public bool ApplyAvoidance { get; set; } = true;

        public float AvoidanceStrength { get; set; } = 5;
    }
}
