using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4
{
    public class Overload
    {
        public int Method1(int param1, int param2, int param3)
        {
            return param1 + param2 + param3;
        }

        public string Method1(string param1, string param2, string param3, string param4)
        {
            return param1 + param2 + param3 + param4;
        }
    }
}