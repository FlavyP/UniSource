using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise19
{
    public static class EnumerableExtension
    {
        public static string MyToString<T>(this IEnumerable<T> collection)
        {
            /*string result = "[";
            foreach(var s in collection)
            {
                result += s.ToString() + ", ";
            }
            return result + "]";*/
            return "[" + string.Join(", ", collection.ToArray()) + "]";
        }
    }
}
