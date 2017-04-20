using System;
using System.Threading;

namespace lab09
{
    class ExampleClass
    {
        public int MyNumber { get; set; }

        public ExampleClass(int i)
        {
            MyNumber = i;
        }

        public void Run()
        {
            while (true)
            {
                Thread.Sleep(MyNumber * 1000);
                Console.WriteLine("Hello, my number is {0} and I will see you in {0} seconds.", MyNumber);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int number_of_threads = 10;

            ExampleClass[] ecs = new ExampleClass[number_of_threads];

            for (int i = 1; i <= number_of_threads; i++)
                ecs[i-1] = new ExampleClass(i);
            
            Thread[] threads = new Thread[number_of_threads];
            for (int i = 0; i < number_of_threads; i++)
            {
                threads[i] = new Thread(ecs[i].Run);
                threads[i].Start();
            }
        }

    }
}
