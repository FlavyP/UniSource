using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            numbers.Select(x => x * 5).ToList().ForEach(Console.WriteLine);
            Console.ReadKey();
        }
    }
}
