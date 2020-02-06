using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Statistics stats;
            Book book = new Book("Math Grade Book");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.7);
            stats = book.GetStatistics();

            Console.WriteLine($"The maximum grade is {stats.High:n1}");
            Console.WriteLine($"The minimum grade is {stats.Low:n1}");
            Console.WriteLine($"The average grade is {stats.Average:n1}");

        }
    }
}