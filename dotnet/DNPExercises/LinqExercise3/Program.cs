using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            var letters = new[] { "a", "b", "c", "d", "e", "f", "g", "h" };

            var index = 0;
            var groups = letters.GroupBy(x => index++ / 3);
            foreach (var group in groups)
            {
                foreach (var groupedItem in group)
                {
                    Console.Write(groupedItem);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
