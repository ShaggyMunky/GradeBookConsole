using System;
using GradeBook.Abstracts;
using GradeBook.Interfaces;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Statistics stats;
            //InMemoryBook book = new InMemoryBook("MathGradeBook");
            DiskBook book = new DiskBook("MathGradeBook");
            book.GradeAdded += OnGradeAdded;

            EnterGrades(book);

            stats = book.GetStatistics();

            Console.WriteLine($"The maximum grade is {stats.High:n1}");
            Console.WriteLine($"The minimum grade is {stats.Low:n1}");
            Console.WriteLine($"The average grade is {stats.Average:n1}");
            Console.WriteLine($"The letter grade is {stats.Letter:n1}");
        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Please enter a grade of 0 to 100. When done, enter Q to view the results.");
                string input = Console.ReadLine();
                double value;
                if (input.ToLower() == "q")
                {
                    break;
                }
                else
                {
                    try
                    {
                        value = double.Parse(input);
                        book.AddGrade(value);
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.Message);
                    }

                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }
    }
}