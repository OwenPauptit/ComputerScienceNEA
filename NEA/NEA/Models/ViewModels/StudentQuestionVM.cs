using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NEA.Models.ViewModels
{
    public class StudentQuestionVM
    {
        public int QIndex { get; set; }
        public string StudentName { get; set; }
        public string Answer { get; set; }
        public AnswerType isCorrect { get; set; }
    }
}
