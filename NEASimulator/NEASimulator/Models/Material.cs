using NEASimulator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NEASimulator.Models
{
    public struct Material
    {
        public readonly float Density { get; }
        public readonly float CoR { get; } // Coefficient of restitution (bounciness)
        public readonly float muStatic { get; }
        public readonly float muKinetic { get; }
        public Material(float density, float cor, float mustatic, float mukinetic)
        {
            Density = density;
            CoR = cor;
            muStatic = mustatic;
            muKinetic = mukinetic;
        }
    }

    public struct MassData
    {
        public readonly float Mass { get; }
        public readonly float Inv_Mass { get; }

        public MassData(iShape shape, float density)
        {
            float area;
            if (shape is Circle)
            {
                area = (shape as Circle).Radius;
                area *= area * (float)Math.PI;
            }
            else
            {
                area = (shape as Rectangle).Size.X * (shape as Rectangle).Size.Y;
            }
            Mass = density * area;
            Inv_Mass = Mass == 0 ? 0 : 1 / Mass;
        }
    }   

    public static class MaterialPresets
    {
        public readonly static Material Wood = new Material(0.3f, 0.6f, 0.5f, 0.4f);
        //public readonly static Material Metal = new Material(1.2f, 0.3f);
        public readonly static Material BouncyBall = new Material(0.06f, 0.8f, 0.2f, 0.1f);
        public readonly static Material SuperBall = new Material(0.000001f, 0.99f, 0.2f,0.1f);
    }
}
