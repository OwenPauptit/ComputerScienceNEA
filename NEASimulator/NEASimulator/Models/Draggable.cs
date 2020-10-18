using Microsoft.AspNetCore.Components.Web;
using NEASimulator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace NEASimulator.Models
{
    public class Draggable : IDisplayObject // Any object that can be dragged by the user
    {
        public bool Dragging { get; set; }
        public string ImageSrc { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Size { get; set; }
        public string Style_Position { get; set; }

        public virtual void SetPositionToMouse(MouseEventArgs e)
        {
            //if(Dragging)
            //{
                Position = new Vector2 { X = (float)e.ClientX, Y = (float)e.ClientY };
                SetStyle();
            //}
        }
        public void SetStyle()
        {
            Style_Position = $"left: {Position.X - (Size.X / 2)}px; top: {Position.Y - (Size.Y / 2)}px";
        }
        public void OnClick()
        {
            Dragging = !Dragging;
        }


        public virtual IDisplayObject Clone()
        {
            return new Draggable();
        }
    }
}
