using System.Collections.Generic;
using System.Linq;

namespace Main
{
    static class ExtensionMethods
    {
        public static IList<Car> Sort(this IList<Car> list)
        {
            return list.OrderBy(c => c.Speed).ToList();
        }
    }
}
