using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace NEASimulator.Interfaces
{
    public class Circle : iShape
    {
        public float Radius { get; private set; }

        public Vector2 Position { get; set; }

        public Circle(float radius, Vector2 position)
        {
            Radius = radius;
            Position = position;
        }

        /*public void calculateCollision(IPhysical self, IPhysical obj)
        {
            // Using equations calculated in my physics research https://docs.google.com/document/d/11booCWzCySJ-c5mPVnTCGwJdgZOgeejw6SyBM3KqDpg/edit?usp=sharing

            if (!(self.BoundingBox is Circle))
            {
                return;
            }

            var Ma = self.Mass;
            var Mb = obj.Mass;
            var Ua = (self is IDynamic) ?
                Math.Sqrt((self as IDynamic).Velocity.X * (self as IDynamic).Velocity.X +
                (self as IDynamic).Velocity.Y * (self as IDynamic).Velocity.Y)
                : 0;
            var Ub = (obj is IDynamic) ?
                Math.Sqrt((obj as IDynamic).Velocity.X * (obj as IDynamic).Velocity.X +
                (obj as IDynamic).Velocity.Y * (obj as IDynamic).Velocity.Y)
                : 0;
            var e = (self.CoR + obj.CoR) / 2;

            Vector2 PoC = new Vector2(); // Point of contact

            double Aa, Ab; // Alpha a and b, i.e. angles before collision


            { // distance variables do not need to be stored outside of this calculation
                var dx = self.Position.X - obj.Position.X;
                var dy = self.Position.Y - obj.Position.Y;
                var d = Math.Sqrt(dx * dx + dy * dy);
                var frac = (self.BoundingBox as Circle).Radius / d;

                PoC.X = self.Position.X - (float)(frac * dx);
                PoC.Y = self.Position.Y - (float)(frac * dy);

                Aa = 90 - Math.Sin((d / 2) / (self.BoundingBox as Circle).Radius);

                dx = obj.Position.X - PoC.X;
                dy = obj.Position.Y - PoC.Y;
                var d_obj_poc = Math.Sqrt(dx * dx + dy * dy);

                Ab = 90 - Math.Sin((d / 2) / d_obj_poc);
            }


            if (self is IDynamic)
            {
                var Vax = ((Ma * Ua * Math.Cos(Aa)) + (Mb * Ub * Math.Cos(Ab)) - (Mb * e * (Ua * Math.Cos(Aa) - Ub * Math.Cos(Ab)))) / (Ma + Mb);
                var Va = Math.Sqrt(Vax * Vax + (Ua * Math.Sin(Aa)) * (Ua * Math.Sin(Aa)));
                var Ba = Math.Atan((Ua * Math.Sin(Aa)) / Vax);

                var dx = self.Position.X - PoC.X;
                var dy = self.Position.Y - PoC.Y;
                var m = dy / dx;
                var angle = Math.Atan(m);
                angle += Aa + Ba;
                if (angle > 360)
                {
                    angle -= 360;
                }
                m = (float)Math.Tan(angle);
                angle = Math.Atan(1 / m);
                (self as IDynamic).Velocity = new Vector2() { X = (float)(Va * Math.Sin(angle)), Y = (float)(Va * Math.Cos(angle)) };

            }
            if (obj is IDynamic)
            {
                var Vbx = ((Mb * Ub * Math.Cos(Ab)) + (Ma * Ua * Math.Cos(Aa)) - (Ma * e * (Ub * Math.Cos(Ab) - Ua * Math.Cos(Aa)))) / (Ma + Mb);
                var Vb = Math.Sqrt(Vbx * Vbx + (Ub * Math.Sin(Ab)) * (Ub * Math.Sin(Ab)));
                var Bb = Math.Atan((Ub * Math.Sin(Ab)) / Vbx);

                var dx = obj.Position.X - PoC.X;
                var dy = obj.Position.Y - PoC.Y;
                var m = dy / dx;
                var angle = Math.Atan(m);
                angle -= Ab - Bb;
                if (angle < 0)
                {
                    angle += 360;
                }
                m = (float)Math.Tan(angle);
                angle = Math.Atan(1 / m);
                (obj as IDynamic).Velocity = new Vector2() { X = (float)(Vb * Math.Sin(angle)), Y = (float)(Vb * Math.Cos(angle)) };
            }

        }

        /*public bool isCollision(IPhysical self, IPhysical obj)
        {
            if (!(self.BoundingBox is Circle))
            {
                return false;
            }

            if (obj.BoundingBox is Circle)
            {
                var dx = obj.Position.X - self.Position.X;
                var dy = obj.Position.Y - self.Position.Y;
                var r = (obj.BoundingBox as Circle).Radius + (self.BoundingBox as Circle).Radius;
                if (dx * dx + dy * dy < r * r)
                {
                    return true;
                }
            }
            else if (obj.BoundingBox is Rectangle)
            {
                var halfWidth = (obj.BoundingBox as Rectangle).Rect.X / 2;
                var halfHeight = (obj.BoundingBox as Rectangle).Rect.Y / 2;

                var top = obj.Position.Y - halfHeight;
                var bottom = obj.Position.Y + halfHeight;
                var left = obj.Position.X - halfWidth;
                var right = obj.Position.X + halfWidth;

                var circletop = self.Position.Y - (self.BoundingBox as Circle).Radius;
                var circlebottom = self.Position.Y + (self.BoundingBox as Circle).Radius;
                var circleleft = self.Position.X - (self.BoundingBox as Circle).Radius;
                var circleright = self.Position.X + (self.BoundingBox as Circle).Radius;

                if (top < circlebottom &&
                    bottom > circletop &&
                    left < circleright &&
                    right > circleleft
                    )
                {
                    return true;
                }


                //List<Vector2> corners = new List<Vector2>();

                //corners.Add(new Vector2 { X = left, Y = top });
                //corners.Add(new Vector2 { X = left, Y = bottom });
                //corners.Add(new Vector2 { X = right, Y = top });
                //corners.Add(new Vector2 { X = right, Y = bottom });

                //foreach (var corner in corners)
                //{
                //    var dx = corner.X - self.Position.X;
                //    var dy = corner.Y - self.Position.Y;
                //    var r = (self.BoundingBox as Circle).Radius;
                //    if (dx * dx + dy * dy < r * r)
                //    {
                //        return true;
                //    }
                //}

            }
            return false;
        }

        public bool isCollision(IPhysical a, IPhysical b)
        {
            return false;
        }*/
    }
}
