using System;
using LinkedListInt;
namespace Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedListInt.LinkedListInt list = new LinkedListInt.LinkedListInt(); 
            int x = 10;
            while (x != 0) {
                list.Add(x);
                x--;
                Console.WriteLine(list.ToString());
                Console.WriteLine("Elements:" +list.NumberOfElements);
            }
            x = 5;
            while (x != 0) {
                list.Remove(x);
                Console.WriteLine(list.ToString());
                Console.WriteLine("Elements:" +list.NumberOfElements);
                x--;
            }

            Console.WriteLine("Final"+list.ToString());

            Console.ReadLine();
        }
    }
}
