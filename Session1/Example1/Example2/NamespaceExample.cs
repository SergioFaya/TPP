using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamespaceExample
{
    class NamespaceExampleClass
    {
        public static void hi()
        {
            Console.WriteLine("Hi(from NamespaceExample)");
        }
    }


    namespace AdderNamespace
    {
        class myClass
        {
            public static int doOperation(int a ,int b)
            {
                return a + b;
            }
        }
    }

    namespace MultiplierNamespace
    {
        class myClass
        {
            public static int doOperation(int a, int b)
            {
                return a * b;
            }
        }
    }
}
