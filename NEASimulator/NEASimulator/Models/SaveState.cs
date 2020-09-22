using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NEASimulator.Interfaces;
using NEASimulator.Models.Apparatus;

namespace NEASimulator.Models
{
    public class SaveState
    {
        public SaveState()
        {
            Objects = new List<IDisplayObject>();
            Sensors = new List<ISensor>();
            DataLoggers = new List<DataLogger>();
            Edges = new List<Edge>();
            Stopwatches = new List<UserStopwatch>();
        }

        public SaveState(SaveState s)
        {
            Objects = new List<IDisplayObject>();
            Sensors = new List<ISensor>();
            DataLoggers = new List<DataLogger>();
            Edges = new List<Edge>();
            Stopwatches = new List<UserStopwatch>();

            Objects.AddRange(s.Objects.Select(i => i.Clone()));
            Sensors.AddRange(s.Sensors.Select(i => i.Clone()));
            DataLoggers.AddRange(s.DataLoggers.Select(i => i.Clone()));
            Stopwatches.AddRange(s.Stopwatches.Select(i => i.Clone()));

            int index;
            Edge temp;

            foreach(var edge in s.Edges)
            {
                temp = new Edge();
                index = s.DataLoggers.IndexOf(edge.datalogger);
                temp.datalogger = DataLoggers[index];

                index = s.Sensors.IndexOf(edge.sensor);
                temp.sensor = Sensors[index];

                temp.portnum = edge.portnum;

                Edges.Add(temp);
            }

        }

        public List<IDisplayObject> Objects { get; set; }
        public List<ISensor> Sensors { get; set; }
        public List<DataLogger> DataLoggers {get; set;}
        public List<Edge> Edges { get; set; }

        public List<UserStopwatch> Stopwatches { get; set; } // Will change to more generic

    }
}
