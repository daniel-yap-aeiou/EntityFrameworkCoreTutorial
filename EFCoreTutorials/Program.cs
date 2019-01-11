using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTutorials
{
    class Program
    {
        static void Main(string[] args)
        {
            //AddStudent();
            //AddCourse();
            //AddGrade();
            //AddStudentAddress();
            //AssignCourseToStudent();
            //AssignGradeToStudents();

            //var students = GetAllStudents();

            //AddAndRemoveStudent();

            var student = GetStudent(1);
        }

        // Raw SQL Queries
        public static Student GetStudent(int studentId)
        {
            using (var context = new SchoolContext())
            {
                return context.Students
                    .FromSql<Student>($"Select * from Students Where StudentId = {studentId}")
                    .Include(s => s.StudentAddress)
                    .Include(s => s.StudentCourses)
                    .Include(s => s.Grade)
                    .FirstOrDefault();
            }
        }

        private static List<Student> GetAllStudents()
        {
            using (var context = new SchoolContext())
            {
                var students = context.Students
                                .Include(s => s.StudentAddress)
                                .Include(s => s.StudentCourses)
                                .Include(s => s.Grade)
                                .ToList();
                return students;
            }
        }

        private static List<Grade> GetAllGrades()
        {
            using (var context = new SchoolContext())
            {
                var grades = context.Grades.Include(g => g.Students).ToList();
                return grades;
            }
        }

        private static void AddStudent()
        {
            using (var context = new SchoolContext())
            {

                var std = new Student()
                {
                    Name = "Bill",
                    StudentType = Enums.StudentType.University
                };

                context.Students.Add(std);
                context.SaveChanges();
            }
        }

        public static void AddCourse()
        {
            using (var context = new SchoolContext())
            {
                var course = new Course()
                { CourseName = "", Description = "" };

                context.Courses.Add(course);
                context.SaveChanges();
            }
        }

        public static void AddGrade()
        {
            using (var context = new SchoolContext())
            {
                var grade = new Grade() { GradeName = "", Section = "" };

                context.Grades.Add(grade);
                context.SaveChanges();
            }
        }

        private static void AddAndRemoveStudent()
        {
            using (var context = new SchoolContext())
            {

                var std = new Student()
                {
                    Name = "Student1"
                };

                context.Students.Add(std);
                context.SaveChanges();

                context.Remove(std);
                context.SaveChanges();
            }
        }

        // one to one relationship.
        public static void AddStudentAddress()
        {
            using (var context = new SchoolContext())
            {
                var studentAddress = new StudentAddress() { Address = "", City = "", Country = "", State = "", AddressOfStudentId = 1 };

                context.StudentAddresses.Add(studentAddress);
                context.SaveChanges();
            }
        }

        // many to many relationships.
        private static void AssignCourseToStudent()
        {
            using (var context = new SchoolContext())
            {
                var students = context.Students.ToList();
                var courses = context.Courses.ToList();

                foreach (var course in courses)
                {
                    foreach (var student in students)
                    {
                        var studentCourse = new StudentCourse
                        {
                            Course = course,
                            Student = student,
                        };

                        student.StudentCourses.Add(studentCourse);
                        course.StudentCourses.Add(studentCourse);
                        context.SaveChanges();
                    }
                }
            }
        }

        // one to many relationships.
        private static void AssignGradeToStudents()
        {
            using (var context = new SchoolContext())
            {
                var grade = context.Grades.FirstOrDefault();
                var students = context.Students.ToList();

                foreach (var student in students)
                {
                    student.Grade = grade;
                    context.SaveChanges();
                }

            }
        }

    }


}
