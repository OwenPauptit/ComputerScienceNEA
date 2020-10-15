using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using NEA.Areas.Identity.Data;
using NEA.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NEA.Models.ViewModels
{
    public class StudentQuestionVM
    {
        public string UserId { get; set; } //TODO: need to make get private
        public int QIndex { get; set; }
        public string StudentName { get; set; }
        public string Answer { get; set; }
        public int SimID { get; set; }
        public AnswerType isCorrect { get; set; }

        public string AuthorizeAccessToID(NEAUser teacher, NEAContext context, string classID)
        {
            var list = context.StudentQuestions.ToList();

            var id = UserId;

            var classroom = context.Users
                .SingleOrDefault(u => u.Id == id)
                .Enrollments
                .SingleOrDefault(e => e.ClassroomID == classID)
                .Classroom;

            if(classroom.UserID == teacher.Id)
            {
                return UserId;
            }

            return "";
        }

        public StudentQuestionVM Clone()
        {
            return new StudentQuestionVM
            {
                UserId = UserId,
                QIndex = QIndex,
                StudentName = StudentName,
                Answer = Answer,
                SimID = SimID,
                isCorrect = isCorrect
            };
        }
    }
}
