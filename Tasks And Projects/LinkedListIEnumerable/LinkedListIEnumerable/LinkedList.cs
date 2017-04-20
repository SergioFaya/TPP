using System;
using System.Collections;
using System.Collections.Generic;
using LinkedListNode;
using LinkedListEnum;

namespace LinkedListIEnumerable
    //Add
    //Remove
    //Contains
    //ToString
    //GetElement
    //create through extension methods

{
    public class LinkedListEnumerable<T> : IEnumerable<T>
    {
        public int NumberOfElements { get; private set; }
        protected Node<T> head;

        public LinkedListEnumerable()
        {
            NumberOfElements = 0;
            head = null;
        }

        public virtual void Add(T value)
        {

            if (value == null)
            {
                throw new NullReferenceException();
            }
            if (head == null)
            {
                head = new Node<T>(value);
                System.Diagnostics.Trace.WriteLine("The node " + head.Value + " has been succesfully added to our linked list");
            }
            else
            {
                getNode(NumberOfElements - 1).NextNode = new Node<T>(value);
                System.Diagnostics.Trace.WriteLine("The node " + getNode(NumberOfElements - 1).NextNode.Value + " has been succesfully added to our linked list");
            }

            NumberOfElements++;
        }

        public virtual void Add(T value, int pos)
        {
            if (value == null)
            {
                throw new NullReferenceException();
            }

            if (pos < NumberOfElements && pos > 0)
            {
                Node<T> node = getNode(pos - 1);
                Node<T> newNode = new Node<T>(value);
                newNode.NextNode = node.NextNode;
                node.NextNode = newNode;
                NumberOfElements++;
            }
            else if (pos == 0)
            {
                Node<T> newNode = new Node<T>(value);
                if (head != null)
                {
                    newNode.NextNode = head;
                    head = newNode;
                }
                else
                {
                    head = newNode;
                }
                NumberOfElements++;
            }
            else
            {
                System.Diagnostics.Trace.WriteLine("the position is not valid");
                throw new ArgumentOutOfRangeException();
            }
        }

        public void RemovePos(int pos)
        {
            if (pos >= 0)
            {
                T value;
                if (pos == 0)
                {
                    value = head.Value;
                    head = head.NextNode;
                    System.Diagnostics.Trace.WriteLine("The node " + value + " has been succesfully removed from our linked list");
                }
                else
                {
                    Node<T> aux = getNode(pos - 1);
                    value = aux.NextNode.Value;
                    aux.NextNode = aux.NextNode.NextNode;
                    System.Diagnostics.Trace.WriteLine("The node " + value + " has been succesfully removed from our linked list");

                }

                NumberOfElements--;
            }
        }

        public void Remove(T value)
        {
            if (value == null)
            {
                throw new ArgumentException();
            }
            int c = 0;
            Node<T> node = head;
            while (c != NumberOfElements)
            {
                if (value.Equals(node.Value))
                {
                    RemovePos(c);
                }
                c++;
                node = node.NextNode;
            }
        }

        public virtual Node<T> getNode(int pos)
        {
            if (pos >= 0)
            {
                int c = 0;
                Node<T> node = head;
                while (c != pos)
                {
                    c++;
                    node = node.NextNode;
                }
                return node;
            }
            else
            {
                return null;
            }
        }

        public virtual T getElement(int pos)
        {
            if (pos >= 0)
            {
                int c = 0;
                Node<T> node = head;
                while (c != pos)
                {
                    c++;
                    node = node.NextNode;
                }
                return node.Value;
            }
            else
            {
                System.Diagnostics.Trace.WriteLine("the position is not valid");
                throw new ArgumentOutOfRangeException();
            }
        }

        public override String ToString()
        {
            String list = "";
            Node<T> node = head;
            while (node != null)
            {
                list += "-" + node.ToString();
                node = node.NextNode;
            }
            return list;
        }


        public virtual bool Contains(T value)
        {
            int c = 0;
            Node<T> node = head;
            while (c != NumberOfElements)
            {
                if (value.Equals(node.Value))
                {
                    return true;
                }
                c++;
                node = node.NextNode;
            }
            return false;
        }

        private LinkedListEnumerator<T> GetEnumerator()
        {
            return new LinkedListEnumerator<T>(this);   
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
