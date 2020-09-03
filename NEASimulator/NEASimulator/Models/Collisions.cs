using NEASimulator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NEASimulator.Models
{
    public static class Collisions
    {
        public struct Manifold
        {
            public IDynamic A;
            public IDynamic B;
            public float PenetrationDepth;
            public float Dt;
            public Vector2 Normal;
        }

        private class Static : IDynamic
        {

            public Static(IPhysical p)
            {
                Material = p.Material;
                MassData = p.MassData;
                BoundingBox = p.BoundingBox;
                Position = p.Position;
            }
            public Static(ISensor s)
            {
                BoundingBox = s.BoundingBox;
                Position = s.Position;
            }

            public Material Material { get; set; }
            public MassData MassData { get; set; }
            public iShape BoundingBox { get; set; }
            public string ImageSrc { get { return null; } set { } }
            public Vector2 Position { get; set; }
            public Vector2 Size { get; set; }
            public string Style_Position { get { return null; } set { } }
            public Vector2 Velocity { get; set; }
            public Vector2 Acceleration { get; set; }

            public void CalculateAVP()
            {
                return;
            }
            public IDisplayObject Clone()
            {
                return new Static(this);
            }
        }

        public static void CheckCollision(ref IPhysical a, ref IPhysical b)
        {
            Manifold m = new Manifold();

            if (a is IDynamic)
            {
                m.A = (a as IDynamic);
            }
            else
            {
                m.A = new Static(a);
            }
            if (b is IDynamic)
            {
                m.B = (b as IDynamic);
            }
            else
            {
                m.B = new Static(b);
            }

            if (isCollision(ref m))
            {
                ResolveCollision(ref m);
            }
            
        }

        private static bool isCollision(ref Manifold m)
        {
            string types = ((m.A.BoundingBox is Circle) ? "Circle" : "Rect") + " " +
                                        ((m.B.BoundingBox is Circle) ? "Circle" : "Rect");

            switch (types)
            {
                case "Circle Circle":
                    return CirclevsCircle(ref m);
                case "Rect Rect":
                    return RectvsRect(ref m);
                case "Rect Circle":
                    return RectvsCircle(ref m);
                case "Circle Rect":
                    // Switch around variables so circle is in A
                    var temp = m.A;
                    m.A = m.B;
                    m.B = temp;
                    return RectvsCircle(ref m);

                default:
                    return false;
            }

        }

        private static bool CirclevsCircle(ref Manifold m)
        {
            Vector2 n = m.B.Position - m.A.Position;

            float r = (m.A.BoundingBox as Circle).Radius + (m.B.BoundingBox as Circle).Radius;

            if (n.LengthSquared() > r * r)
            {
                return false;
            }

            float d = n.Length(); // only perform sqrt when we have to

            if (d != 0) // To avoid zero division error
            {
                m.PenetrationDepth = r - d;

                //Calculate unit vector of normal contact
                m.Normal = n / d;
            }
            else // Circles are perfectly on top of each other
            {
                // Penetration depth is the radius of the larger circle
                m.PenetrationDepth = Math.Max((m.A.BoundingBox as Circle).Radius, (m.B.BoundingBox as Circle).Radius);

                // Random, normal is the x axis
                m.Normal = new Vector2() { X = 1, Y = 0 };
            }
            return true;
        }

        private static bool RectvsRect(ref Manifold m)
        {
            Vector2 n = m.B.Position - m.A.Position;


            // Using extent to refer to half width/height
            float a_extent = ((m.A.BoundingBox as Rectangle).Max.X - (m.A.BoundingBox as Rectangle).Min.X) / 2;
            float b_extent = ((m.B.BoundingBox as Rectangle).Max.X - (m.B.BoundingBox as Rectangle).Min.X) / 2;
            float x_overlap = a_extent + b_extent - Math.Abs(n.X);

            if (x_overlap > 0) // Separating Axis Theorem
            {
                a_extent = ((m.A.BoundingBox as Rectangle).Max.Y - (m.A.BoundingBox as Rectangle).Min.Y) / 2;
                b_extent = ((m.B.BoundingBox as Rectangle).Max.Y - (m.B.BoundingBox as Rectangle).Min.Y) / 2;
                float y_overlap = a_extent + b_extent - Math.Abs(n.Y);

                if (y_overlap > 0) // Separating Axis Theorem
                {

                    if (x_overlap > y_overlap)
                    {
                        // The normal unit vector will be in the direction of one of the faces,
                        // either along x or y axis - since Rect is a non rotatable rigid body
                        if (n.X < 0)
                        {
                            m.Normal = new Vector2 { X = -1, Y = 0 };
                        }
                        else
                        {
                            m.Normal = new Vector2 { X = 1, Y = 0 };
                        }
                        m.PenetrationDepth = x_overlap;
                    }
                    else
                    {
                        if (n.Y < 0)
                        {
                            m.Normal = new Vector2 { X = 0, Y = -1 };
                        }
                        else
                        {
                            m.Normal = new Vector2 { X = 0, Y = 1 };
                        }
                        m.PenetrationDepth = y_overlap;
                    }
                    return true;
                }

            }
            return false;
        }

        private static bool RectvsCircle(ref Manifold m) // m.A is Rect, m.B is Circle
        {
            Vector2 n = m.B.Position - m.A.Position;

            //closest point on A to centre of B
            Vector2 closest = n;

            //Half width/height of rect, as before
            Vector2 extent = new Vector2
            {
                X = ((m.A.BoundingBox as Rectangle).Max.X - (m.A.BoundingBox as Rectangle).Min.X) / 2,
                Y = ((m.A.BoundingBox as Rectangle).Max.Y - (m.A.BoundingBox as Rectangle).Min.Y) / 2
            };

            closest = Vector2.Clamp(closest, -extent, extent);

            bool inside = false;

            // Circle is inside the Rect, so we clamp circle's center to the closest edge
            if (n == closest)
            {
                inside = true;

                // Find axis which is further from the center,
                // i.e. closest to the edge
                if (Math.Abs(n.X) > Math.Abs(n.Y))
                {
                    if (closest.X > 0)
                    {
                        closest.X = extent.X;
                    }
                    else
                    {
                        closest.X = -extent.X;
                    }
                }
                else
                {
                    if (closest.Y > 0)
                    {
                        closest.Y = extent.Y;
                    }
                    else
                    {
                        closest.Y = -extent.Y;
                    }
                }
            }

            Vector2 normal = n - closest;
            float d = normal.LengthSquared();
            float r = (m.B.BoundingBox as Circle).Radius;

            // Early out to avoid unnecessary square root
            if (d > r * r && !inside)
            {
                return false;
            }

            // Don't square root until have to
            d = (float)Math.Sqrt(d);

            if (inside)
            {
                m.Normal = -normal;
                m.PenetrationDepth = r - d;
            }
            else
            {
                m.Normal = normal;
                m.PenetrationDepth = r - d;
            }

            return true;
        }

        private static void ResolveCollision(ref Manifold m)
        {
            Vector2 rv = m.B.Velocity - m.A.Velocity;

            // Amount of rv in direction of normal - Dot Product
            float rvNormal = Vector2.Dot(rv, Vector2.Normalize(m.Normal));

            // If objects are already separating, return
            if (rvNormal > 0)
            {
                return;
            }

            float e = Math.Min(m.A.Material.CoR, m.B.Material.CoR);

            // j = impulse scalar
            float j = -(e + 1) * rvNormal;
            j /= m.A.MassData.Inv_Mass + m.B.MassData.Inv_Mass;

            Vector2 impulse = j * Vector2.Normalize(m.Normal);
            m.A.Velocity -= m.A.MassData.Inv_Mass * impulse;
            m.B.Velocity += m.B.MassData.Inv_Mass * impulse;

            //ResolveFriction(ref m, j);
            BaumgarteStabilisation(ref m);

        }

        private static void BaumgarteStabilisation(ref Manifold m)
        {
            // When a dynamic object is resting on a static object, it has
            // a tendency to sink into the static object due to floating 
            // point errors caused by hardware, known as "positional drift".
            // This method pushes the objects even further apart if they are 
            // travelling at low velocities and are overlapping. This is the  
            // Baumgarte Stabilisation Technique for positional correction.

            const float percent = 0.1f;
            const float slop = 1.0f;
            //const double velocityRestraint = 3.0;

            Vector2 bias = (Math.Max(m.PenetrationDepth - slop, 0.0f) / (m.A.MassData.Inv_Mass + m.B.MassData.Inv_Mass)) * percent * m.Normal;
            //if (m.A.Velocity.Length() < velocityRestraint)
            {
                m.A.Position -= m.A.MassData.Inv_Mass * bias;
            }
            //if (m.B.Velocity.Length() < velocityRestraint)
            {
                m.B.Position += m.B.MassData.Inv_Mass * bias;
            }
        }

        private static void ResolveFriction(ref Manifold m, float j)
        {
            Vector2 rv = m.B.Velocity - m.A.Velocity;

            Vector2 tangent = rv - Vector2.Dot(rv, m.Normal) * m.Normal;

            tangent = Vector2.Normalize(tangent);

            var tx = tangent.X;
            var ty = tangent.Y;

            float jt = Vector2.Dot(rv, tangent); // Would be - * -, so leave it as +
            jt /= m.A.MassData.Inv_Mass + m.B.MassData.Inv_Mass;

            float mu = (m.A.Material.muStatic + m.B.Material.muStatic) / 2;

            Vector2 frictionImpulse;

            if (Math.Abs(jt) < j * mu)
            {
                frictionImpulse = jt * tangent;
            }
            else
            {
                mu = (m.A.Material.muKinetic + m.B.Material.muKinetic) / 2;
                frictionImpulse = -j * mu * tangent;
            }

            m.A.Velocity -= m.A.MassData.Inv_Mass * frictionImpulse;
            m.B.Velocity += m.B.MassData.Inv_Mass * frictionImpulse;
            var x = m.A.Velocity.X;
            var x2 = m.B.Velocity.X;
        }

        public static bool CheckCollision(ISensor a, IDynamic b) // objects will not be modified, so dont need to pass as reference
        {
            Manifold m = new Manifold
            {
                A = new Static(a),
                B = b
            };

            return isCollision(ref m);
            
        }
    }
}
