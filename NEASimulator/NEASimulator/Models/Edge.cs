using NEASimulator.Interfaces;
using NEASimulator.Models.Apparatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NEASimulator.Models
{
    public struct Edge
    {

        public DataLogger datalogger { get; set; }
        public ISensor sensor { get; set; }
        public int portnum { get; set; }
    }
}
