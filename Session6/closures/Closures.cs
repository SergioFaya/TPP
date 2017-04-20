using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace closures
{
    class Closures
    {
        static Func<int> Counter()
        {
            int counter = 0;
            return () => ++counter;
        }


        static void Main(string[] args)
        {
            int a = 2;
            int b = 3;

            Func<int> add_a_b = () => a + b;
            Console.WriteLine("{0} + {1} = {2}.", a, b, add_a_b());
           
            int x1 = 4;
            int x2 = 5;

            Func<int> add_inc = () => { int a1 = x1, a2 = x2; x1++; x2++; return a1 + a2; };

            Console.WriteLine(add_inc());
            Console.WriteLine(add_inc());
            
            x1 = 1;
            x2 = 2;

            Console.WriteLine(add_inc());
            
            Func<int> counter = Counter();
            Console.WriteLine("counter " + counter());
            Console.WriteLine("counter " + counter());
            Console.ReadLine();
        }
    }
}
