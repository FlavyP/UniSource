using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisePrimeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {   
            for(int i = 2; i <= 100; i++)
            {
                if(isPrime(i))
                {
                    Console.WriteLine(i);
                }
            }
            Console.ReadKey();
        }

        public static bool isPrime(int x)
        {
            for(int i = 2; i <= Math.Sqrt(x); i++)
            {
                if(x % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
