using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace currying
{
    class Currying
    {
        //Currying methods receive a param and return a function 
        static Func<int, int> CurriedAdd(int a)
        {
            return b => a + b;
        }
        
        static void Main(string[] args)
        {
            const int a = 2, b = 1;
            Console.WriteLine("{0} + {1} = {2}", a, b, CurriedAdd(a)(b));
            
            const int x1 = 2, x2 = 1, x3 = 4;
            
            Console.WriteLine("Curried addition: {0}", CurriedAdd(CurriedAdd(x1)(x2))(x3));

            CurriedAdd(5)(7);

            Func<int, int> add_2 = CurriedAdd(2);
            Func<int, int> add_5 = CurriedAdd(5);
            
            Console.WriteLine("{0} + 2 = {1}", 1, add_2(1));
            Console.WriteLine("{0} + 5 = {1}", 1, add_5(1));
            
            
            
            Console.ReadLine();
        }
    }
}