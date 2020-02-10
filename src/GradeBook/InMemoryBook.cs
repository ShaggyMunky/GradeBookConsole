using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        private readonly List<double> grades;
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
                throw new ArgumentException($"Invalid {nameof(grade)}");
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
            switch (stats.Average)
            {
                case var d when d >= 90.0:
                    stats.Letter = 'A';
                    break;
                case var d when d >= 80.0:
                    stats.Letter = 'B';
                    break;
                case var d when d >= 70.0:
                    stats.Letter = 'C';
                    break;
                case var d when d >= 60.0:
                    stats.Letter = 'D';
                    break;
                default:
                    stats.Letter = 'F';
                    break;
            }
            return stats;
        }

        public int GetTotalNumberOfGrades()
        {
            return grades.Count;
        }
    }
}