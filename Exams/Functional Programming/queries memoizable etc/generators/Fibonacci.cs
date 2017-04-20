using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generators
{
    class Fibonacci
    {

        /// <summary>
        /// Returns a generator of infinite terms of the Fibonacci sequence
        /// </summary>
        static internal IEnumerable<int> InfiniteFibonacci()
        {
            int first = 1, second = 1;
            while (true)
            {
                // * Returns the first one and stores the execution state.
                // * In the subsequent invocation, the state is retrieved
                //   and the invocation continues after the yield statement
                yield return first;
                int addition = first + second;
                first = second;
                second = addition;
            }
        }

    }
}
