using NEASimulator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace NEASimulator.Models.Apparatus
{
    class Ball : Draggable, IDynamic
    {
        public Ball(Vector2 startingPos, bool dragging = true)
        {
            Position = startingPos;

            //Temp
            ImageSrc = "/RedBall.png";
            Size = new Vector2 { X = 100, Y = 100};
            Velocity = new Vector2 { X = 0, Y = 0 };
            Acceleration = new Vector2 { X = 0, Y = Constants.gravity };
            BoundingBox = new Circle(Size.X/2,Position);
            Dragging = dragging;

            Material = MaterialPresets.SuperBall;
            MassData = new MassData(BoundingBox, Material.Density);

            SetStyle();
        }

        public Ball(Ball b)
        {
            Size = b.Size;
            BoundingBox = b.BoundingBox;

            Position = b.Position;
            Velocity = b.Velocity;
            Acceleration = b.Acceleration;

            Material = b.Material;
            MassData = b.MassData;

            ImageSrc = b.ImageSrc;
            Dragging = false;
            Style_Position = b.Style_Position;
        }

        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }
        public Material Material { get; set; }
        public MassData MassData { get; set; }
        public iShape BoundingBox { get; set; }

        public void CalculateAVP()
        {
            Position += Velocity += Acceleration;
            SetStyle();
        }

        public override IDisplayObject Clone()
        {
            return new Ball(this);
        }

    }
}
