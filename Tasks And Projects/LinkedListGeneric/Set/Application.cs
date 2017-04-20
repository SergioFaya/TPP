using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Set;
namespace Application
{
    class Application
    {
        static void Main(string[] args)
        {
            Set<int> set1 = new Set<int>();
            Set<int> set2 = new Set<int>();
            set1.Add(5);
            set1.Add(3);
            set1.Add(8);
            set1.Add(8);
            Console.WriteLine(set1.ToString());
            set2.Add(1);
            set2.Add(3);
            set2 += 2;
            set2.Add(4);
            set2[0] = 4;
            Console.WriteLine(set2.ToString());
            Set<int> set0 = set1 & set2;
            Console.WriteLine(set0.ToString());
            Console.ReadLine();
        }
    }
}
