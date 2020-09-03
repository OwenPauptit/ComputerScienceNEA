using NEASimulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NEASimulator.Interfaces
{
    public interface IPhysical : IDisplayObject // Any object that can collide
    {

        public Material Material { get; set; }
        public MassData MassData { get; set; }
        public iShape BoundingBox { get; set; }
    }
}
