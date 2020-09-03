using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace NEASimulator.Interfaces
{

    public interface IDisplayObject // Any object that will be displayed on the screen
    {
        public string ImageSrc { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Size { get; set; }
        public string Style_Position { get; set; } // CSS for positioning of object

        public IDisplayObject Clone();
        
    }

}
