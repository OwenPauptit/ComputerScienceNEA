using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NEASimulator.Interfaces
{
    public interface ISensor : IDisplayObject
    {
        public IData Data { get; set; }
        public Rectangle BoundingBox { get; set; }

        public void CollectData(IDynamic obj);
        public bool HasData();
        public VelocityTimestampData ReturnData();

        public new ISensor Clone();
    }
}
