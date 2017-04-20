using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example1
{
    enum Drinks{
        water, milk, lemonade
    }

    class Program
    {
        static void Main(string[] args)
        {
            //XML comment by using ///
            ///<summary>
            ///My 
            /// </summary
            //this is a comment
            /*Comment*/
            Console.WriteLine("Hello World!");
            int n = 14;
            float f = 21.54f;
            double d = 035.65461654654321d;
            Console.WriteLine("n is {0}, f is {1} and d is {2}", n, f, d);
            bool b = true;
            Console.WriteLine(" b is {0}", b);
            string s = "This is a string";
            Console.WriteLine(s);
            Drinks drink;
            drink = Drinks.water;
            Console.WriteLine(drink);


            Console.ReadLine();
        }
    }
}
