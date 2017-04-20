using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutMethods
{
    class Program
    {
        static void MethodOut8(out int a)
        {
            a = 8;
        }

        static void Main(string[] args)
        {
            int a = int.MaxValue;
            Console.WriteLine("Before--{0}", a);
            MethodOut8(out a);
            Console.WriteLine("After--{0}",a);
            Console.ReadLine();
        }
    }
}
