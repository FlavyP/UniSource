using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise19
{
    class Program
    {
        static void Main(string[] args)
        {
            string hello = "Hello, Extension Methods!";
            Console.WriteLine(hello.WordCount());

            IList<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            numbers.IncreaseWith(5);
            Console.WriteLine(numbers.MyToString());
            Console.ReadKey();
        }
    }
}
