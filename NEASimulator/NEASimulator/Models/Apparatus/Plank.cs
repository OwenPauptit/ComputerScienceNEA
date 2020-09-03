using NEASimulator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Numerics;
using Microsoft.AspNetCore.Components.Web;

namespace NEASimulator.Models.Apparatus
{
    class Plank : Draggable, IPhysical
    {
        public enum Type
        {
            Horizontal,
            Vertical
        }

        public Plank(Vector2 startingPos, Type type, bool dragging=true)
        {
            Position = startingPos;

            switch(type)
            {
                case Type.Horizontal:
                    ImageSrc = "/Plank.png";
                    Size = new Vector2 { X = 300, Y = 20 };
                    break;
                case Type.Vertical:
                    ImageSrc = "/V_Plank.png";
                    Size = new Vector2 { X = 20, Y = 300 };
                    break;
            }
            
            BoundingBox = new Rectangle()
            {
                Size = Size
            };

            Material = MaterialPresets.Wood;
            MassData = new MassData(BoundingBox, Material.Density);

            Dragging = dragging;

            SetStyle();
            SetBoundingBox();
        }

        public Plank(Plank p)
        {
            Size = p.Size;
            BoundingBox = p.BoundingBox;
            Position = p.Position;

            Material = p.Material;
            MassData = p.MassData;

            ImageSrc = p.ImageSrc;
            Dragging = false;
            Style_Position = p.Style_Position;
        }

        public iShape BoundingBox { get; set; }
        public Material Material { get; set; }
        public MassData MassData { get; set; }

        public override void SetPositionToMouse(MouseEventArgs e)
        {
            if (Dragging)
            {
                Position = new Vector2 { X = (float)e.ClientX, Y = (float)e.ClientY };
                SetStyle();
            }

            SetBoundingBox();

        }

        public void SetBoundingBox()
        {
            (BoundingBox as Rectangle).Min = Position - ((BoundingBox as Rectangle).Size / 2);
            (BoundingBox as Rectangle).Max = Position + ((BoundingBox as Rectangle).Size / 2);
        }

        public override IDisplayObject Clone()
        {
            return new Plank(this);
        }
    }
}
