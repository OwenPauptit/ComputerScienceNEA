using NEASimulator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace NEASimulator.Models
{
    class Dot : Draggable, IPhysical
    {
        public Dot(Vector2 startingPos)
        {
            Position = startingPos;

            //Temp
            ImageSrc = "/dot.png";
            Size = new Vector2 { X = 30, Y = 30 };
            CoR = 0;
            BoundingBox = new Circle(Size.X / 2, Position);
            Dragging = false;

            SetStyle();
        }

        public double CoR { get; set; }
        public double Mass { get; set; }
        public iShape BoundingBox { get; set; }
        public float Inv_Mass { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Material Material { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public MassData MassData { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
