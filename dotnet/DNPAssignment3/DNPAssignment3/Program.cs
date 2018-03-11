using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNPAssignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            Pair<String, int> kurt = new Pair<String, int>("Kurt", 13);
            Pair<String, int> john = new Pair<String, int>("John", 16);
            Pair<String, int> mike = new Pair<String, int>("Mike", 21);

            Pair<String, double> phx = new Pair<String, double>("Phoenix", 39.7);
            Pair<String, double> clb = new Pair<String, double>("Colibri", 25.35);

            //(d) Can you assign a value of type Pair<String,int> to a variable of type Pair<String,double>?
            //Should this be allowed?
            //mike = phx;
            //It is not allowed since phx is (String, double) and not (String, int). I don't think it should be allowed because it might lose certain information when doing the conversion from double to int

            //For the 2 empty values it prints nothing for the String part and 0 for the int part of the pair => ( , 0);
            Pair<String, int>[] grades = new Pair<String, int>[5];
            grades[0] = kurt;
            grades[1] = john;
            grades[2] = mike;
            foreach(var grade in grades)
            {
                Console.WriteLine(grade);
            }

            //(g) Type int, value 15
            Pair<Pair<int, int>, String> appointment = new Pair<Pair<int, int>, string>(new Pair<int, int>(10, 15), "test");
            Console.WriteLine("Type of app.fst.snd = {0}, value = {1}", appointment.first.second.GetType(), appointment.first.second);

            //(h)
            Pair<int, String> pair = kurt.Swap();
            Console.WriteLine("Swapped (String, int) to (int, String) = {0}", pair);
            Console.ReadKey();
        }
    }
}
