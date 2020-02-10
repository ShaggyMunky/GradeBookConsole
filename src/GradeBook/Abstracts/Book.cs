using GradeBook.Delegates;
using GradeBook.Interfaces;

namespace GradeBook.Abstracts
{
    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();
    }
}
