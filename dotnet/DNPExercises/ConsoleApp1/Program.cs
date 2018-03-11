using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 41, 22, 54, 1, 8, 35, 5, 2, 9, 8, 4, 1, 47, 50 };
            IEnumerable<IGrouping<bool, int>> groups = numbers.GroupBy(n => (n % 2 == 0));

            foreach (IGrouping<bool, int> group in groups)
            {
                if (group.Key == true)
                    Console.Write("\nEven Elements: ");
                else
                    Console.Write("\nOdd Elements: ");

                foreach (int number in group)
                {
                    Console.Write(number + " ");
                }
            }
            foreach (IGrouping<bool, int> group in groups)
            {
                if (group.Key == true)
                    Console.Write("\nEven Elements: ");
                else
                    Console.Write("\nOdd Elements: ");

                foreach (int number in group)
                {
                    Console.Write(number + " ");
                }
            }
            foreach (IGrouping<bool, int> group in groups)
            {
                if (group.Key == true)
                    Console.Write("\nEven Elements: ");
                else
                    Console.Write("\nOdd Elements: ");

                foreach (int number in group)
                {
                    Console.Write(number + " ");
                }
            }
            Console.ReadKey();
        }
    }
}
