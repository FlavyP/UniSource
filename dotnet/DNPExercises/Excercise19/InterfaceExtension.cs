using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise19
{
    public static class InterfaceExtension
    {
        public static void IncreaseWith(this IList<int> list, int value)
        {
            for(int i = 0; i < list.Count; i++)
            {
                list[i] += value;
            }
            //return list.Select(x => x + value).ToList();
        }
    }
}
