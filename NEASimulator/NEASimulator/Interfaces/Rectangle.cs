using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace NEASimulator.Interfaces
{
    public class Rectangle : iShape
    {
        public Vector2 Min { get; set; }
        public Vector2 Max { get; set; }
        public Vector2 Size { get; set; }

    }
}
