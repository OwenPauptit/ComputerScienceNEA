using NEASimulator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace NEASimulator.Models.Apparatus
{
   class DataLogger : Draggable
    {
        const int _numPorts = 2;
        public DataLogger(Vector2 startingpos, bool dragging=true)
        {
            Position = startingpos;
            Dragging = dragging;

            ImageSrc = "/DataLogger.png";
            Size = new Vector2(200,170);

            CalculationData = new AccelerationCalculationData();
            PortData = new VelocityTimestampData[2];

            SetStyle();
        }

        public DataLogger(DataLogger d)
        {
            Size = d.Size;
            Position = d.Position;

            ImageSrc = d.ImageSrc;
            Dragging = false;
            Style_Position = d.Style_Position;

            PortData = d.PortData;
            CalculationData = d.CalculationData;
        }

        public AccelerationCalculationData CalculationData { get; set; }
        public VelocityTimestampData[] PortData { get; set; }

        public void ReceiveData(int portNumber, VelocityTimestampData data)
        {
            if (portNumber < 0 || portNumber >= _numPorts)
            {
                return;
            }

            if (portNumber == 0)
            {
                ResetData();
            }
            else if (portNumber > 0)
            {
                if (PortData[0] == null || PortData[portNumber] != null)
                {
                    return;
                }
            }

            PortData[portNumber] = data;

            EvaulateData();
        }

        public void EvaulateData()
        {
            
            CalculationData.VelocityA = PortData[0]?.Velocity.Length() ?? 0f;
            CalculationData.VelocityB = PortData[1]?.Velocity.Length() ?? 0f;

            if (CalculationData.VelocityA != 0f && CalculationData.VelocityB != 0f &&
                 PortData[0]?.TimeStamp != null && PortData[1]?.TimeStamp != null)
            {
                CalculateAcceleration();
            }
        }

        public void ResetData()
        {
            CalculationData = new AccelerationCalculationData();
            PortData = new VelocityTimestampData[2];
        }

        public void CalculateAcceleration()
        {
            CalculationData.TimeDifference = PortData[1].TimeStamp.Value - PortData[0].TimeStamp.Value;
            //CalculationData.TimeDifference /= 1000;

            var va = CalculationData.VelocityA;
            var vb = CalculationData.VelocityB;
            var t = CalculationData.TimeDifference;

            CalculationData.Acceleration = (CalculationData.VelocityB - CalculationData.VelocityA) / CalculationData.TimeDifference;
            CalculationData.Acceleration *= 1000;
        }

        public DisplayData GetDisplayData()
        {
            return new DisplayData
            {
                VelocityA = CalculationData.VelocityA,
                VelocityB = CalculationData.VelocityB,
                TimeDifference = (float)CalculationData.TimeDifference / 1000,
                Acceleration = CalculationData.Acceleration
            };
        }

        public new DataLogger Clone()
        {
            return new DataLogger(this);
        }
    }
}
