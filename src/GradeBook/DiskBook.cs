using System;
using System.IO;
using GradeBook.Abstracts;
using GradeBook.Delegates;

namespace GradeBook
{
    public class DiskBook : Book
    {
        public DiskBook(string name) : base (name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            using (StreamWriter writer = File.AppendText($"{Name}.txt"))
            {
                if (grade <= 100 && grade >= 0)
                {
                    writer.WriteLine(grade);
                    GradeAdded?.Invoke(this, new EventArgs());
                }
                else
                {
                    throw new ArgumentException($"Invalid {nameof(grade)}");
                }                
            }
        }

        public override Statistics GetStatistics()
        {
            Statistics stats = new Statistics();

            using(StreamReader reader = File.OpenText($"{Name}.txt"))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    double number = double.Parse(line);
                    stats.Add(number);
                    line = reader.ReadLine();
                }
            }

            return stats;
        }
    }
}
