using System;
using System.Collections.Generic;
using System.Text;
using static EFCoreTutorials.Enums;

namespace EFCoreTutorials
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public StudentType StudentType { get; set; }

        //public int CurrentGradeId { get; set; }
        public Grade Grade { get; set; }
        public StudentAddress StudentAddress { get; set; }

        public IList<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    }
}
