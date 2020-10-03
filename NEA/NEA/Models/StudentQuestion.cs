using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NEA.Areas.Identity.Data;

namespace NEA.Models
{
    public enum AnswerType
    {
        Correct,
        Incorrect,
        ErrorCarriedForward
    }
    public class StudentQuestion
    {
        [Required]
        public int SimulationID { get; set; }

        [Required]
        public int QIndex { get; set; }

        [Required]
        public string UserID { get; set; }

        public string Answer { get; set; }

        [Required]
        public AnswerType isCorrect { get; set; }

        public Simulation Simulation { get; set; }
        public Question Question { get; set; }
        public NEAUser NEAUser { get; set; }
    }
}
