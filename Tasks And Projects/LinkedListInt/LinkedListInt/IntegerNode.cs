using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class IntegerNode {
    public IntegerNode NextNode { get; set; }
    public int Value { get; private set; }
    public IntegerNode(int value)
    {
        NextNode = null;
        Value = value;
    }

    ~IntegerNode()
    {
        System.Diagnostics.Trace.WriteLine("The node "+Value+" has been destroyed");
    }
}
