using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NamespaceExample;

namespace Example2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello world 2");
            NamespaceExampleClass.hi();//no need to use namesspaceExample as we are using it in the upper part

            int x, y;
            x = 2;
            y = 3;
            int xyadded = NamespaceExample.AdderNamespace.myClass.doOperation(x, y);
            int xymultiplied = NamespaceExample.MultiplierNamespace.myClass.doOperation(x, y);


            Console.WriteLine("{0} + {1} = {2}",x,y,xyadded);

            Console.WriteLine("{0} * {1} = {2}", x, y, xymultiplied);
            Console.ReadLine();
            System.Diagnostics.Trace.WriteLine("My trace message");
            System.Diagnostics.Trace.WriteLineIf(x==2, "x=2");
        }

    }
}
