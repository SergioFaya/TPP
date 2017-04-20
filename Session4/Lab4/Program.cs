using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Program
    {
        static void ArrToList<T>(T[] arr)
        {
            LinkedList<T> list = new LinkedList<T>();
            for (int i = 0; i < arr.Length; i++)
            {
                list.AddLast(arr[i]);
            }
        }

        static void Main(string[] args)
        {
            List<int> l = new List<int>();
            l.Add(4);
            l.Add(43);
            l.Add(44);

            foreach(int element in l) //foreach C#
            {
                Console.WriteLine(element);
            }

            Console.ReadLine();
        }


    }
}
