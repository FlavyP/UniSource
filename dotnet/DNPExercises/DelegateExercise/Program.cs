using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateExercise
{
    class Program
    {
        public delegate void Notifier(string sender);

        private static Notifier greetings;

        private static void SayHello(string sender)
        {
            Console.WriteLine("Hello from {0}", sender);
        }

        private static void SayGoodBye(string sender)
        {
            Console.WriteLine("GoodBye from {0}", sender);
        }

        private static bool isEven(int val)
        {
            return val % 2 == 0;
        }

        static void Main(string[] args)
        {
            greetings = SayHello;
            greetings("John");

            greetings = SayGoodBye;
            greetings("John");

            Console.WriteLine();

            var delList = new List<Notifier> { SayGoodBye, SayHello };
            foreach(var del in delList) {
                del("John");
            }

            Console.WriteLine("Predicate delegates");
            Console.WriteLine();

            int[] integers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] evenIntegers = Array.FindAll(integers, isEven);

            Console.WriteLine("Even integers: ");
            evenIntegers.ToList().ForEach(Console.WriteLine);

            var p = new { Name = "Kurt", Age = 33 };

            p.Name = "Mitica";

            Console.ReadKey();
        }
    }
}
