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
            bool done = false;

            while (!done)
            {
                Console.WriteLine("Please enter a grade of 0 to 100. When done, enter Q to view the results.");
                string input = Console.ReadLine();
                double value;
                if (input.ToLower() == "q")
                {
                    done = true;
                }
                else
                {
                    try
                    {
                        value = double.Parse(input);
                        book.AddGrade(value);
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    
                }
            } 
            

            stats = book.GetStatistics();

            Console.WriteLine($"The maximum grade is {stats.High:n1}");
            Console.WriteLine($"The minimum grade is {stats.Low:n1}");
            Console.WriteLine($"The average grade is {stats.Average:n1}");
            Console.WriteLine($"The letter grade is {stats.Letter:n1}");
        }
    }
}