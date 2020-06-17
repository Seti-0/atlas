using Duality;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soulstone.Duality.Plugins.Atlas.Testing.Boids
{
    public class SteeringNoise
    {
        private static Random random = new Random();

        private float _lastTime;
        private float _duration;
        private float _value;
        private float _time;

        public float MaxDuration { get; set; }

        public float Next(float dT)
        {
            _time += dT;

            if (_time - _lastTime > _duration)
            {
                NextValue();
            }

            return _value;
        }

        private void NextValue()
        {
            _value = (float) random.NextDouble();
            _duration = (float) random.NextDouble() * MaxDuration;
            _lastTime = _time;
        }
    }
}
