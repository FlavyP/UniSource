using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise18
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Calling /SM/");
            //B.SM();
            //C.SM();

            B b = new C();
            C c = new C();
            Console.WriteLine(b.GetType());
            Console.WriteLine(c.GetType());

            Console.WriteLine("Calling /NIM/");
            
            b.NIM();
            c.NIM();

            Console.WriteLine("Calling /VIM/");
            b.VIM();
            c.VIM();
            Console.ReadKey();
        }
    }
}
