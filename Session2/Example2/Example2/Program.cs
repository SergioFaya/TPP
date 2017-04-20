using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example2
{
    class Program
    {
        static void Main(string[] args)
        {
            int vm = 0;
            Class1.value_example(vm);
            int iorm = 0;
            Class1.in_out_ref_example(ref iorm);
            int orm;
            Class1.out_ref_example(out orm);
            int ip = 5;
            float fp= 4.5f;
            string sp = "my String";
            Class1.named_arguments_example(i: ip, f: fp, str: sp);
            Class1.named_arguments_example(str: sp);
            Console.WriteLine("VM:" + vm);
            Console.WriteLine("IOrm:" + iorm);
            Console.WriteLine("Orm:" + orm);

            object o = 5;

            var v = 8;

            v++;
            //    o++; lauch an error as object cannot be 

            object[] oa = new object[3];
            oa[0] = 34;
            oa[1] = "hello";
            oa[2] = 54;

            int int_pair = 4;
            int int_not_pair = 5;



            Console.ReadLine();
        }
    }
}
