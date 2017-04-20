using System;
using System.Collections;
using System.Collections.Generic;
using MyLinkedList;

namespace MyLinkedList
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
        private Dictionary<int, T> cache = new Dictionary<int, T>();
        private Node<T> head;

        public LinkedListEnumerable()
        { 
            NumberOfElements = 0;
            head = null;
        }

        public virtual void Add(T value)
        {

            if (value == null) {
                throw new NullReferenceException();
            }
            if (head == null) {
                head = new Node<T>(value);
                System.Diagnostics.Trace.WriteLine("The node " + head.Value + " has been succesfully added to our linked list");
            }
            else {
                getNode(NumberOfElements - 1).NextNode = new Node<T>(value);
                System.Diagnostics.Trace.WriteLine("The node " + getNode(NumberOfElements - 1).NextNode.Value + " has been succesfully added to our linked list");
            }

            NumberOfElements++;
        }

        public virtual void AddPos(T value, int pos)
        {
            if (value == null) {
                throw new NullReferenceException();
            }
            //We reset the cache dictionary to avoid index errors 
            cache = new Dictionary<int, T>();

            if (pos < NumberOfElements && pos > 0) {
                Node<T> node = getNode(pos - 1);
                Node<T> newNode = new Node<T>(value);
                newNode.NextNode = node.NextNode;
                node.NextNode = newNode;
                NumberOfElements++;
            }
            else if (pos == 0) {
                Node<T> newNode = new Node<T>(value);
                if (head != null) {
                    newNode.NextNode = head;
                    head = newNode;
                }
                else {
                    head = newNode;
                }
                NumberOfElements++;
            }
            else {
                System.Diagnostics.Trace.WriteLine("the position is not valid");
                throw new ArgumentOutOfRangeException();
            }
        }

        public void Remove(T value)
        {
            if (value == null) {
                throw new ArgumentException();
            }
            int c = 0;
            Node<T> node = head;
            while (c != NumberOfElements) {
                if (value.Equals(node.Value)) {
                    RemovePos(c);
                    //We reset the cache dictionary to avoid index errors 
                    cache = new Dictionary<int, T>();
                }
                c++;
                node = node.NextNode;
            }
        }

        public void RemovePos(int pos)
        {
            if (pos >= 0) {
                T value;
                if (pos == 0) {
                    value = head.Value;
                    head = head.NextNode;
                    System.Diagnostics.Trace.WriteLine("The node " + value + " has been succesfully removed from our linked list");
                    //We reset the cache dictionary to avoid index errors 
                    cache = new Dictionary<int, T>();
                }
                else {
                    Node<T> aux = getNode(pos - 1);
                    value = aux.NextNode.Value;
                    aux.NextNode = aux.NextNode.NextNode;
                    System.Diagnostics.Trace.WriteLine("The node " + value + " has been succesfully removed from our linked list");
                    //We reset the cache dictionary to avoid index errors 
                    cache = new Dictionary<int, T>();

                }

                NumberOfElements--;
            }
        }

        private Node<T> getNode(int pos)
        {
            if (pos >= 0) {
                int c = 0;
                Node<T> node = head;
                while (c != pos) {
                    c++;
                    node = node.NextNode;
                }
                return node;
            }
            else {
                return null;
            }
        }

        public T getElement(int pos)
        {
            if (pos >= 0) {
                int c = 0;
                Node<T> node = head;
                while (c != pos) {
                    c++;
                    node = node.NextNode;
                }
                return node.Value;
            }
            else {
                System.Diagnostics.Trace.WriteLine("the position is not valid");
                throw new ArgumentOutOfRangeException();
            }
        }

        public bool Contains(T value)
        {
            int c = 0;
            Node<T> node = head;
            while (c != NumberOfElements) {
                if (value.Equals(node.Value)) {
                    return true;
                }
                c++;
                node = node.NextNode;
            }
            return false;
        }

        public override string ToString()
        {
            String list = "";
            Node<T> node = head;
            while (node != null) {
                list += "-" + node.ToString();
                node = node.NextNode;
            }
            return list;
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

        public T getMemoizable(int index)
        {
            if (cache.ContainsKey(index)) {
                return cache[index];
            }
            else {
                T element = getElement(index);
                cache[index] = element;
                return element;
            }
        }
    }

    //Extension methods
    public static class Extensions
    {

        public static IEnumerable<T> Map<T>(this IEnumerable<T> c, Func<T,T> f)
        {
            List<T> l = new List<T>();
            foreach (var item in c) {
                l.Add( f(item));
            }
            return l;
        }

        public static T Find<T>(this IEnumerable<T> collection, Predicate<T> pred)
        {
            foreach (T item in collection) {
                if (pred(item)) {
                    return item;
                }
            }
            return default(T);
        }

        public static IEnumerable<T> Filter<T>(this IEnumerable<T> collection, Predicate<T> pred)
        {
            List<T> l = new List<T>();
            foreach (T item in collection) {
                if (pred(item)) {
                    l.Add(item);
                }
            }
            return l;
        }

        //Without seed
        public static P Reduce<T, P>(this IEnumerable<T> collection, Func<T, P, P> function)
        {
            P something = default(P);
            foreach (T item in collection) {
                something = function(item, something);
            }
            return something;
        }

        //With seed as parameter
        public static P Reduce<T, P>(this IEnumerable<T> collection, Func<T, P,P> f, P seed = default(P))
        {
            P p = seed;
            foreach (var item in collection) {
                p = f(item, p);
            }
            return p;
        }

        public static IEnumerable<T> Invert<T>(this IEnumerable<T> collection)
        {
            Stack<T> stack = new Stack<T>();
            foreach (var item in collection) {
                stack.Push(item);
            }
            List<T> l = new List<T>();
            foreach (var item in stack) {
                l.Add(stack.Pop());
            }
            return l;
        }
        //Action  == a method with just a param that is void
        public static void forEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var item in collection) {
                action(item);
            }
        }
    }

}
