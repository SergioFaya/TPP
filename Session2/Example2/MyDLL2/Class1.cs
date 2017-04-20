using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example2
{
    public class Class1
    {
        public int Value { get; set; }
        public static void value_example(int a)
        {
            a = a + 1;
        }

        public static void in_out_ref_example(ref int a)
        {
            a = a + 1;
        }

        public static void out_ref_example(out int a)
        {
            a = 1;
        }

        public static void named_arguments_example(string str, int i = 3,float f =9.2f)//optional params
        {
            Console.WriteLine("string :" + str);
            Console.WriteLine("float :" + f);
            Console.WriteLine("int:" + i);
        }
        //operator overload
        public static Class1 operator +(Class1 c1,Class1 c2)
        {
            Class1 cr = new Class1();
            cr.Value = c1.Value + c2.Value;
            return cr;
        } 
    }
}
