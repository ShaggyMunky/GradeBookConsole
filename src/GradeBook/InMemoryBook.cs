using System;
using System.Collections.Generic;
using GradeBook.Abstracts;
using GradeBook.Delegates;

namespace GradeBook
{
    public class InMemoryBook : Book
    {
        private readonly List<double> grades;
        public override event GradeAddedDelegate GradeAdded;

        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
        }

        public override void AddGrade(double grade)
        {
            if(grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public override Statistics GetStatistics()
        {
            Statistics stats = new Statistics();
            foreach(var grade in grades)
            {
                stats.Add(grade);
            }

            return stats;
        }

        public int GetTotalNumberOfGrades()
        {
            return grades.Count;
        }
    }
}