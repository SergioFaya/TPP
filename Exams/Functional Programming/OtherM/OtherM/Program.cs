using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALL;
namespace ALL
{
    class Program
    {
        static void Main(string[] args)
        {
            int resultado;
            OutMethods.suma(4, 6, out resultado);
            Console.WriteLine(resultado);
            OutMethods.mult(() => 5);
            Console.WriteLine(resultado);
            Console.ReadLine();
        }
    }
}
