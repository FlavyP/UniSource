using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = new[] { "Kim", "Kurt", "Karsten", "Klaus", "Kay" };
            var replacedNames = names.Select(x => x.Replace(x.ElementAt(0), 'C'));
            replacedNames.ToList().ForEach(Console.WriteLine);
            Console.WriteLine();

            var vowels = new HashSet<char>("aeiou");
            var withoutVowels = from name in names
                                select new string(name.Where(c => !vowels.Contains(c)).ToArray());
            withoutVowels.ToList().ForEach(Console.WriteLine);
            Console.WriteLine();
            
            foreach(var name in names)
            {
                var nameWithoutVowels = name.Where(c => !vowels.Contains(c)).ToArray();
                Console.WriteLine(nameWithoutVowels);
            }
            Console.ReadLine();
        }
    }
}
