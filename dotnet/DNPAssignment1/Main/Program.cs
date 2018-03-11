using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            cars.Add(new Car("Porsche 911", 265, 1.36, 5900, 2994, 6, 6));
            cars.Add(new Car("Mazda MX-5", 130, 55.5, 6800, 2500, 5, 7));
            cars.Add(new Car("Ford Focus", 250, 2.73, 3500, 1500, 5, 4));
            cars.Add(new Car("Ferrari 488", 315, 35, 7500, 1790, 7, 7));
            cars.Add(new Car("Opel Astra", 89, 15.67, 4500, 1395, 5, 5));
            cars.Add(new Car("Ran out of ideas Car", 555, 45, 5550, 6542, 4, 5));
            
            cars.Sort( (c1, c2) => c1.Speed.CompareTo(c2.Speed));
            Console.WriteLine("Printing cars sorted with 'SORT' BY SPEED");
            cars.ForEach(i => Console.WriteLine("Name = {0}, Speed = {1}", i.Name, i.Speed));
            Console.WriteLine();

            cars = cars.OrderBy(c => c.Name).ToList();
            Console.WriteLine("Printing cars sorted with 'ORDERBY' NAME");
            cars.ForEach(i => Console.WriteLine("Name = {0}, Speed = {1}", i.Name, i.Speed));
            Console.WriteLine();

            Hand h1 = new Hand(cars);
            int minSpeed = 150;
            List<Car> speedyCars = h1.getCarsWithSpeedGreaterThan(minSpeed);
            Console.WriteLine("Printing cars from HAND class that have speed > than {0}", minSpeed);
            speedyCars.ForEach(i => Console.WriteLine("Name = {0}, Speed = {1}", i.Name, i.Speed));
            Console.WriteLine();

            //Comparing properties
            Console.WriteLine("Comparison result = {0}", cars[0].compareBy(cars[3], "Speed"));
            Console.WriteLine();

            //Sorting with extension method
            IList<Car> cars2 = new List<Car>();
            cars2.Add(new Car("Porsche 911", 265, 1.36, 5900, 2994, 6, 6));
            cars2.Add(new Car("Mazda MX-5", 130, 55.5, 6800, 2500, 5, 7));
            cars2.Add(new Car("Astra Opel", 200, 15.67, 4500, 1395, 5, 5));

            Console.WriteLine("Sorting cars with ORDER BY NAME IN SAME CLASS");
            cars2 = cars2.OrderBy(c => c.Name).ToList();
            cars2.ToList().ForEach(i => Console.WriteLine("Name = {0}, Speed = {1}", i.Name, i.Speed));
            Console.WriteLine();

            Console.WriteLine("Sorting cars with ORDER BY SPEED EXTENSION METHOD");
            cars2 = cars2.Sort();
            cars2.ToList().ForEach(i => Console.WriteLine("Name = {0}, Speed = {1}", i.Name, i.Speed));

            Console.ReadLine();
        }
    }
}
