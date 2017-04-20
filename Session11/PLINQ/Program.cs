using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace PLINQ
{
    // Try to calculate the vector modulus with LINQ and PLINQ

    class Program
    {
        static short[] CreateRandomVector(int numberOfElements, short lowest, short greatest)
        {
            short[] vector = new short[numberOfElements];
            Random random = new Random();
            for (int i = 0; i < numberOfElements; i++)
                vector[i] = (short)random.Next(lowest, greatest + 1);
            return vector;
        }



        
        static double VectorModulusLinq(IEnumerable<short> vector)
        {
            int value = 0;
            double acc = vector.AsParallel().Aggregate(value,(v, a) => v += a*a );
            return Math.Sqrt(acc);
        }



        // https://msdn.microsoft.com/es-es/library/dd460688(v=vs.110).aspx

        static double VectorModulusPLinq(IEnumerable<short> vector)
        {
            int value = 0;
            double acc = vector.Aggregate(value, (v, a) => v += a * a).;
            return Math.Sqrt(acc);
        }



        static void Main()
        {
            short[] vector = CreateRandomVector(100000000, -10, 10);

            
            Stopwatch chrono = new Stopwatch();

            chrono.Start();
            double result = VectorModulusLinq(vector);
            chrono.Stop();
            long time = chrono.ElapsedMilliseconds;
            Console.WriteLine("Elapsed time with LINQ: {0}. Result {1}.", time, result);

            chrono.Restart();
            result = VectorModulusPLinq(vector);
            chrono.Stop();
            time = chrono.ElapsedMilliseconds;
            Console.WriteLine("Elapsed time with PLINQ: {0}. Result {1}.", time, result);


            Console.ReadLine();
        }
    }
}
