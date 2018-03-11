using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNPAssignment3
{
    public struct Pair<T, U>
    {
        public readonly T first;
        public readonly U second;

        public Pair(T fst, U snd)
        {
            this.first = fst;
            this.second = snd;
        }

        public Pair<U, T> Swap()
        {
            return new Pair<U, T>(this.second, this.first);
        }

        public override String ToString()
        {
            return "(" + first + ", " + second + ")";
        }
    }
}
