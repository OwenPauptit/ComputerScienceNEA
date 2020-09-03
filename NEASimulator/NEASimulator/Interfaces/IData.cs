using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace NEASimulator.Interfaces
{
    public interface IData
    {
    }

    public class VelocityTimestampData : IData
    {
        public Vector2 Velocity { get; set; }
        public long? TimeStamp { get; set; } // in miliseconds
        //long milliseconds = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
    }

    public class AccelerationCalculationData : IData
    { 
        public float VelocityA { get; set; }
        public float VelocityB { get; set; }
        public long TimeDifference { get; set; }
        public float Acceleration { get; set; }
    }

    public class DisplayData : IData
    {
        public float? VelocityA { get; set; }
        public float? VelocityB { get; set; }
        public float TimeDifference { get; set; }
        public float? Acceleration { get; set; }
    }

}
