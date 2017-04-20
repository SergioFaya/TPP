using System;

namespace lab10
{
    /// <summary>
    /// Shows how to use Interlocked to assign values to shared variables in concurrent programming
    /// </summary>
    class Program
    {
        static void Main()
        {
            const int value = 1000000;
            const int numberOfThreads = 1000;

            
            Summation summation = new Summation(value, numberOfThreads);
            summation.Compute();
            Console.WriteLine("Value after performing decrementing directly: {0}.", summation.Value);


            lockSummation l_summation = new lockSummation(value, numberOfThreads);
            l_summation.Compute();
            Console.WriteLine("Value after performing decrementing using lock: {0}.", l_summation.Value);


            InterlockedSummation il_summation = new InterlockedSummation(value, numberOfThreads);
            il_summation.Compute();
            Console.WriteLine("Value after performing decrementing using Interlocked: {0}.", il_summation.Value);


            Console.ReadLine();
        }

    }
}
