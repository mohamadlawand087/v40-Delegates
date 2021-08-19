using System;
using GradingLib.Delegate;
using GradingLib.Models;

namespace GradeApplication
{
    class Program
    {
        static Exam exam = new Exam();

        static void Main(string[] args)
        {
            InitializeStudents();

            var deleg = new TopGrade(HighGrade);
            var pdeleg = new PassingCondition(StudentPassing);

            var result = exam.CalculateAverageGrade(deleg);

            Console.WriteLine($"The Student Average is: {result}");

            exam.PassStudents(pdeleg);

            foreach(var std in exam.Students)
            {
                Console.WriteLine($"{std.Name} has passed: {std.Pass}");
            }
        }

        public static void HighGrade(double grade)
        {
            Console.WriteLine($"The highest Grade is {grade}");
        }

        public static bool StudentPassing(double grade)
        {
            if(grade >= 80)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void InitializeStudents()
        {
            exam.Students.Add(new Student
            {
                Name = "Mohamad",
                Grade = 70
            });

            exam.Students.Add(new Student
            {
                Name = "Mickey ",
                Grade = 60
            });

            exam.Students.Add(new Student
            {
                Name = "Donald",
                Grade = 89
            });

            exam.Students.Add(new Student
            {
                Name = "Goofy",
                Grade = 55
            });

            exam.Students.Add(new Student
            {
                Name = "Batman",
                Grade = 75
            });

            exam.Students.Add(new Student
            {
                Name = "Superman",
                Grade = 20
            });
        }
    }
}
