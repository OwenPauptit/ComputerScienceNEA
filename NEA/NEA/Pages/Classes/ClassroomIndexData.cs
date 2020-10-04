using NEA.Models;
using NEA.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NEA.Pages.Classes
{
    public class ClassroomIndexData
    {
        public IEnumerable<Classroom> Classrooms { get; set; }
        public IEnumerable<ClassAssignment> ClassAssignments { get; set; }
        public IEnumerable<StudentAssignmentIndexVM> StudentAssignments { get; set; }

        public IEnumerable<Question> Questions { get; set; }
        public IEnumerable<StudentQuestionVM> StudentQuestions { get; set; }

    }
}
