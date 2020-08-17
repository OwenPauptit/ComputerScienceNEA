using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NEA.Models.ViewModels
{
    public class ClassroomIndexVM
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Teacher { get; set; }
        public int StudentCount { get; set; }
    }
}
