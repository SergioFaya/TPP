using System;

namespace Exercise
{
    // You are given 2 arrays of integers.
    // The second array's size <= the first array's size
    // Calculate the number of times that the second array appears in the first one.
    // Suppose that you will have a maximum of vector1.Length/vector2.Length threads
    // Example:
    // { 2, 2, 1, 3, 2, 2, 1, 2, 1, 2, 2, 1 } and { 2, 2, 1}
    // Result: 3
    
    public class Program
    {
        static void Main(string[] args)
        {
            //short[] vector1 = new short[] { 2, 2, 1, 3, 2, 2, 1, 2, 1, 2, 2, 1 };
            //short[] vector2 = new short[] { 2, 2, 1 };

            short[] vector1 = CreateRandomVector(1000, 0, 4);
            short[] vector2 = CreateRandomVector(2, 0, 4);


        }
        
        public static short[] CreateRandomVector(int numberOfElements, short lowest, short greatest)
        {
            short[] vector = new short[numberOfElements];
            Random random = new Random();
            for (int i = 0; i < numberOfElements; i++)
                vector[i] = (short)random.Next(lowest, greatest + 1);
            return vector;
        }

    }
}
