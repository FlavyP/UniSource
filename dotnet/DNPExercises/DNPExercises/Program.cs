using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNPExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Kim", "Jesper", "Mads", "Morten", "Rasmus", "Julius" };
            names.OrderBy(x => x).ToList().ForEach(Console.WriteLine);
            Console.ReadLine();
        }
    }
}
