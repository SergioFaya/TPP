using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListInt {
    public class LinkedListInt
    {
        public int NumberOfElements { get; private set; }
        private IntegerNode head = null;

        public LinkedListInt()
        {
            NumberOfElements = 0;
        }

        public void Add(int value)
        {
            if (head == null) {
                head = new IntegerNode(value);
                System.Diagnostics.Trace.WriteLine("The node " + head.Value + " has been succesfully added to our linked list");
            }
            else {
                getElement(NumberOfElements - 1).NextNode = new IntegerNode(value);
                System.Diagnostics.Trace.WriteLine("The node " + getElement(NumberOfElements - 1).NextNode.Value + " has been succesfully added to our linked list");
            }

            NumberOfElements++;
        }
        public void Remove(int pos)
        {
            if (pos >= 0) {
                int value = 0;
                if (pos == 0) {
                    head = head.NextNode;
                    System.Diagnostics.Trace.WriteLine("The node " + head.Value + " has been succesfully removed from our linked list");
                }
                else {
                    IntegerNode aux = getElement(pos - 1);
                    value = aux.NextNode.Value;
                    aux.NextNode = aux.NextNode.NextNode;
                    System.Diagnostics.Trace.WriteLine("The node " + value + " has been succesfully removed from our linked list");

                }

                NumberOfElements--;
            }
        }

        public IntegerNode getElement(int pos)
        {
            int c = 0;
            IntegerNode node = head;
            while (c != pos) {
                c++;
                node = node.NextNode;
            }
            return node;
        }




        public String ToString()
        {
            String list = "";
            IntegerNode node = head;
            while (node != null) {
                list += "-" + node.Value;
                node = node.NextNode;
            }
            return list;
        }
    }
}
