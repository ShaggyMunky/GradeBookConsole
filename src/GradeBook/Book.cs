using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        private List<double> grades;
        public string Name;

        public Book(string name)
        {
            grades = new List<double>();
            Name = name;
        }

        public void AddGrade(double grade)
        {
            if(grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
            }
            else
            {
                Console.WriteLine("Invalid Value");
            }
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

        public int GetTotalNumberOfGrades()
        {
            return grades.Count;
        }
    }
}