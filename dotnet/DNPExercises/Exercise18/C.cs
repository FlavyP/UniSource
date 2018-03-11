using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise18
{
    class C : B
    {
        public new static void SM() { Console.WriteLine("Hello from CCCCC.SM()"); }
        public override void VIM() { Console.WriteLine("Hello from CCCCC.VIM()"); }
        public new void NIM() { Console.WriteLine("Hello from CCCCC.NIM()"); }
    }
}
