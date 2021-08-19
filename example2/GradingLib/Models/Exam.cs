using System.Collections.Generic;
using System.Linq;
using GradingLib.Delegate;

namespace GradingLib.Models
{
    public class Exam
    {
        public List<Student> Students { get; set; } = new List<Student>();

        public double CalculateAverageGrade(TopGrade topGrade)
        {
            topGrade(Students.Max(x => x.Grade));
            return Students.Sum(x => x.Grade) / Students.Count;
        }
        
        public void PassStudents(PassingCondition isPassed)
        {
            foreach (var student in Students)
            {
                if(isPassed(student.Grade))
                {
                    student.Pass = true;
                }
                else
                {
                    student.Pass = false;
                }
            }
        }
    }
}