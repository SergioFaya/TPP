using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListNode
{
    public class Node<T>
    {
        public Node<T> NextNode { get; set; }
        public T Value { get; private set; }
        public Node(T value)
        {
            NextNode = null;
            Value = value;
        }

        public override String ToString()
        {
            return Value.ToString();
        }
        ~Node()
        {
            System.Diagnostics.Trace.WriteLine("The node " + Value.ToString() + " has been destroyed");
        }
    }
}
