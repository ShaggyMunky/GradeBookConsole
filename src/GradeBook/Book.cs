using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        private List<double> grades;
        private string name;

        public Book(string name)
        {
            grades = new List<double>();
            this.name = name;
        }

        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        public Statistics GetStatistics()
        {
            Statistics stats = new Statistics
            {
                Average = 0,
                High = double.MinValue,
                Low = double.MaxValue
            };

            foreach (double grade in grades)
            {
                stats.High = Math.Max(grade, stats.High);
                stats.Low = Math.Min(grade, stats.Low);
                stats.Average += grade;
            }

            stats.Average /= grades.Count;

            return stats;
        }
    }
}