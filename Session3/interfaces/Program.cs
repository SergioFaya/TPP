using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfaces
{
    public interface I1
    {
        void method1();
        void method2();
    }

    public class myClass : I1
    {
        public void method1()
        {
            throw new NotImplementedException();
        }

        public void method2()
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            myClass mc = new myClass();
            mc.method1();

            Console.ReadLine();
        }
    }


}
