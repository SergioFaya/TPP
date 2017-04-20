using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nullableTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            bool variable;

            bool? nullableVariable;
            try {
                //variable = null;
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.StackTrace);
            }
            
            nullableVariable = null;
        }
    }
}
