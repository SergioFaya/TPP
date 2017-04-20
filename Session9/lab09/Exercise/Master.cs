using System;
using System.Collections;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise
{
    public class Master
    {
        private short[] vector1;
        
        private short[] vector2;
        
        private int numberOfThreads;

        public Master(short[] vector1, short[] vector2, int numberOfThreads)
        {
            if (numberOfThreads < 1 || numberOfThreads > vector1.Length)
                throw new ArgumentException("The number of threads must be lower or equal to the number of elements in the vector.");
            this.vector1 = vector1;
            this.vector2 = vector2;
            this.numberOfThreads = numberOfThreads;
        }

        public int ComputeNumberOfAppearances()
        {
            int result =0;
            for (int i = 0; i < vector1.Length; i++)
            {
                for (int j = 0; j < vector2.Length; j++)
                {
                    if(vector1[i] == vector2[i])
                }
            } 
            return result;
        }
    }
}
