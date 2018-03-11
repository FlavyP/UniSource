using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class Hand
    {
        public List<Car> Cars { get; set; }

        public Hand(List<Car> Cars)
        {
            this.Cars = Cars;
        }

        public List<Car> getCarsWithSpeedGreaterThan(int kmh)
        {
            return Cars.FindAll(x => x.Speed > kmh);
        }
    }
}
