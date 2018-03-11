using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class Car
    {
        public string Name { get; set; }

        // km/h
        public int Speed { get; set; }

        //PS/kW
        public double Power { get; set; }

        // U/min
        public int RevolutionsPerMin { get; set; }

        public int Ccm { get; set; }

        //0-100 km/h in seconds
        public int Acceleration { get; set; }

        //Zylinder
        public int NoOfCylinders { get; set; }

        public Car(string Name, int Speed, double Power, int RevolutionsPerMin, int Ccm, int Acceleration, int NoOfCylinders)
        {
            this.Name = Name;
            this.Speed = Speed;
            this.Power = Power;
            this.RevolutionsPerMin = RevolutionsPerMin;
            this.Ccm = Ccm;
            this.Acceleration = Acceleration;
            this.NoOfCylinders = NoOfCylinders;
        }

        public int compareBy(Car c1, string property)
        {
            switch(property)
            {
                case "Speed":
                    return Speed.CompareTo(c1.Speed);
                case "Power":
                    return Power.CompareTo(c1.Power);
                case "RevolutionsPerMin":
                    return RevolutionsPerMin.CompareTo(c1.RevolutionsPerMin);
                case "Acceleration":
                    return Acceleration.CompareTo(c1.Acceleration);
                case "NoOfCylinders":
                    return NoOfCylinders.CompareTo(c1.NoOfCylinders);
                default:
                    return -2;
            }
        }
    }
}
