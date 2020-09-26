using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NEA.Models
{
    public class QuestionType
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        
        public string AnswerFormat { get; set; }
    }
}
