using Microsoft.AspNetCore.Components.Web;
using NEASimulator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace NEASimulator.Models.Apparatus
{
    class LightGate : Draggable, ISensor
    {
        public LightGate(Vector2 startingpos, bool dragging=true)
        {
            Data = new VelocityTimestampData();

            ImageSrc = "/media/LightGate.png";
            Position = startingpos;
            Size = new Vector2(41, 41);
            BoundingBox = new Rectangle()
            {
                Size = Size
            };
            Dragging = dragging;
            SetBoundingBox();
            SetStyle();
        }

        public LightGate(LightGate l)
        {
            Size = l.Size;
            Position = l.Position;

            ImageSrc = l.ImageSrc;
            Dragging = false;
            Style_Position = l.Style_Position;

            Data = l.Data;
            BoundingBox = l.BoundingBox;
        }

        public IData Data { get; set; }
        public Rectangle BoundingBox { get; set; }

        public void CollectData(IDynamic obj)
        {
            if (obj?.Velocity.Length() == 0)
            {
                return;
            }
            (Data as VelocityTimestampData).Velocity = obj.Velocity;
            (Data as VelocityTimestampData).TimeStamp = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        }

        public bool HasData()
        {
            return (Data as VelocityTimestampData).TimeStamp != null ? true : false;
        }

        public VelocityTimestampData ReturnData()
        {
            VelocityTimestampData temp = new VelocityTimestampData
            {
                Velocity = (Data as VelocityTimestampData).Velocity,
                TimeStamp = (Data as VelocityTimestampData).TimeStamp
            };
            Data = new VelocityTimestampData()
            {
                TimeStamp = null
            };
            return temp;
        }

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
            BoundingBox.Min = Position - (BoundingBox.Size / 2);
            BoundingBox.Max = Position + (BoundingBox.Size / 2);
        }

        public new ISensor Clone()
        {
            return new LightGate(this);
        }
    }
}
