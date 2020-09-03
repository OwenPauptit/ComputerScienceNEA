using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace NEASimulator.Interfaces
{
    public interface IDynamic : IPhysical
    {
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }

        public void CalculateAVP();
    }
}
