using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NEA.Models
{
    public class Question
    {
        [Required]
        public int SimulationID { get; set; }
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int QIndex { get; set; }
        [Required]
        public int QuestionTypeID { get; set; }
        [Required]
        public string QuestionString { get; set; }
        [Required]
        public string AnswerString { get; set; }

        public QuestionType QuestionType { get; set; }
        public Simulation Simulation { get; set; }
        public ICollection<StudentQuestion> StudentQuestions {get; set;}
    }
}
