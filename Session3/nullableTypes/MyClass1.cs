using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nullableTypes
{
    public class MyClass1
    {
        public List<int> myList { get; set; }

        public MyClass1()
        {
            myList = new List<int>();
        }
       
    }
    /*
     * With contracts we specify how a class beahves and then its implemented
     * Requires-> Preconditions
     * Ensures-> PostConditions
     * Invariant-> Invariants
     * 
     * 
     * 
    [ContractInvariantMethod]
    private void ObjectInvariant()
    {
        Contract.Invariant(this.myList.Count < 5);
    }
    */
}
