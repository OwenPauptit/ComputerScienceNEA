using NEASimulator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace NEASimulator.Models.Apparatus
{
    class MetreStick : Draggable
    {
        public MetreStick(Vector2 startingpos, bool dragging=false)
        {
            Position = startingpos;
            ImageSrc = "/MetreStick.png";
            Size = new Vector2(30, 500);
            Dragging = dragging;

            SetStyle();
        }

        public MetreStick(MetreStick m)
        {
            Size = m.Size;
            Position = m.Position;

            ImageSrc = m.ImageSrc;
            Dragging = false;
            Style_Position = m.Style_Position;
        }

        public override IDisplayObject Clone()
        {
            return new MetreStick(this);
        }
    }
}
