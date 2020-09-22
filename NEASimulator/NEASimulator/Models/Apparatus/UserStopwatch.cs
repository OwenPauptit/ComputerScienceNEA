using NEASimulator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using System.Diagnostics;

namespace NEASimulator.Models.Apparatus
{
    public class UserStopwatch : Draggable
    {
        private Stopwatch stopwatch;
        public bool StartWithSimulation { get; set; }
        public UserStopwatch(Vector2 startingpos, bool dragging = true)
        {
            Position = startingpos;
            Dragging = dragging;

            //ImageSrc = "/DataLogger.png";
            Size = new Vector2(200, 100);

            stopwatch = new Stopwatch();

            SetStyle();
        }

        public UserStopwatch(UserStopwatch s)
        {
            Size = s.Size;
            Position = s.Position;

            ImageSrc = s.ImageSrc;
            Dragging = false;
            Style_Position = s.Style_Position;

            stopwatch = new Stopwatch();

        }

        public new UserStopwatch Clone()
        {
            return new UserStopwatch(this);
        }

        public void Start()
        {
            stopwatch.Start();
            OnClick();
        }

        public void Stop()
        {
            stopwatch.Stop();
            OnClick();
        }

        public void Reset()
        {
            stopwatch.Reset();
            OnClick();
        }

        public float GetElapsedTime()
        {
            return stopwatch.ElapsedMilliseconds / 1000f;
        }

    }
}
