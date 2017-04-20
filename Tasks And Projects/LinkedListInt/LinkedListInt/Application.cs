using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedListInt;

namespace LinkedListApplication {
    class Program {
        static void Main(string[] args)
        {
            LinkedListInt.LinkedListInt list = new LinkedListInt.LinkedListInt();
            list.Add(5);
            list.Add(8);
            list.Add(1);
            Console.WriteLine(list.ToString());

            list.Remove(2);
            list.Remove(1);

            Console.WriteLine(list.ToString());
            Console.WriteLine(list.NumberOfElements);
            Console.ReadLine();
        }
    }
}
