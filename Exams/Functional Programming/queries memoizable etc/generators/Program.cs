using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generators
{
    class Program
    {

        static void Main()
        {
            const int numberOfTerms = 100;
            // * The 10 first tems in the Fibonacci sequence
            int i = 1;
            foreach (int value in Fibonacci.InfiniteFibonacci())
            {
                Console.WriteLine("Term {0}: {1}.", i, value);
                if (i++ == numberOfTerms)
                    break;
            }
            
            
            Console.ReadLine();
        }
    }
}
