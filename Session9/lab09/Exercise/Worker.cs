using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise
{
    internal class Worker
    {
        private short[] vector1;

        private short[] vector2;

        private int fromIndex, toIndex;

        // ...


        internal Worker(short[] vector1, short[] vector2, int fromIndex, int toIndex)
        {
            this.vector1 = vector1;
            this.vector2 = vector2;
            this.fromIndex = fromIndex;
            this.toIndex = toIndex;

            // ...
        }

        internal void Compute()
        {
            // ...
        }
    }
}
