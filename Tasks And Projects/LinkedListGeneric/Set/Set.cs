using System;
using LinkedListGeneric;
using MyList;
namespace Set
{
    public class Set<T> : MyList<T>
    {
        public int NumberOfElements { get; private set; }
        public LinkedList<T> list;
        /// <summary>
        /// Default constructor
        /// </summary
        public Set()
        {
            list = new LinkedList<T>();
            NumberOfElements = list.NumberOfElements;
        }

        /// <summary>
        /// Adds the given value at the end of the list.
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value)
        {
            if (value == null) {
                throw new NullReferenceException();
            }
            if (!Contains(value)) {
                list.Add(value);
            }
            NumberOfElements = list.NumberOfElements;
        }

        /// <summary>
        /// Adds the given value in the given position in the list. 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="pos"></param>
        public void Add(T value, int pos)
        {
            if (value == null) {
                throw new NullReferenceException();
            }
            if (!Contains(value)) {
                list.Add(value, pos);
            }
            NumberOfElements = list.NumberOfElements;
        }

        /// <summary>
        /// Removes the element in the given position in the list.
        /// </summary>
        /// <param name="pos"></param>
        public void RemovePos(int pos)
        {
            if(pos>=NumberOfElements || pos < 0) {
                System.Diagnostics.Trace.WriteLine("the position is not valid");
                throw new ArgumentOutOfRangeException();
            }
            if (pos >= 0) {
                list.RemovePos(pos);
            }
            NumberOfElements = list.NumberOfElements;
        }

        /// <summary>
        /// If the given value exists, its removed from the list.
        /// </summary>
        /// <param name="value"></param>
        public void Remove(T value)
        {
            if (value == null) {
                throw new NullReferenceException();
            }
            else if (!list.Contains(value)) {
                throw new ArgumentException();
            }
            else {
                list.Remove(value);
            }
            NumberOfElements = list.NumberOfElements;
        }

        /// <summary>
        /// Returns the node in the given position of the list.
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public Node<T> getNode(int pos) 
        {
            if (pos >= NumberOfElements || pos < 0) {
                System.Diagnostics.Trace.WriteLine("the position is not valid");
                throw new ArgumentOutOfRangeException();
            }
            else {
                return list.getNode(pos);
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public T getElement(int pos)
        {
            return list.getElement(pos);
        }

        /// <summary>
        /// Checks if the value is in the list.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>True if the value exists, null if the imput is null, false otherwise</returns>
        public bool Contains(T value)
        {
            if (value == null) {
                throw new ArgumentException();
            }
            return list.Contains(value);
        }

        /// <summary>
        /// The toString.
        /// </summary>
        /// <returns>A representative string of the set</returns>
        public override String ToString() {
            return list.ToString();
        }

        /// <summary>
        /// Concatenation of both sets
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns>Concatenation of both params</returns>
        public static Set<T> operator |(Set<T> s1, Set<T> s2)
        {
            return Concatenate(s1, s2);
        }

        private static Set<T> Concatenate(Set<T> s1, Set<T> s2)
        {
            Set<T> s0 = new Set<T>();
            for (int i = 0; i < s1.NumberOfElements; i++) {
                s0.Add(s1.getElement(i));
            }

            for (int i = 0; i < s2.NumberOfElements; i++) {
                s0.Add(s2.getElement(i));
            }
            return s0;
        }

        /// <summary>
        /// Adds the value to the set
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="value"></param>
        /// <returns>S1 with the value added</returns>
        public static Set<T> operator +(Set<T> s1, T value)
        {
            s1.Add(value);
            return s1;
        }

        /// <summary>
        ///  Removes the value from the set s1.
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="value"></param>
        /// <returns>S1 without the value</returns>
        public static Set<T> operator -(Set<T> s1, T value)
        {
            s1.Remove(value);
            return s1;
        }
        /// <summary>
        /// Intersection of s1 and s2
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns>A set with values from the intersection of s1 and s2</returns>
        public static Set<T> operator &(Set<T> s1, Set<T> s2)
        {
            Set<T> s0 = new Set<T>();
            Set<T> big,small;
            if(s1.NumberOfElements >= s2.NumberOfElements) {
                big = s1;
                small = s2;
            }
            else {
                big = s2;
                small = s1;
            }
            for (int i = 0; i < big.NumberOfElements; i++) {
                if (small.Contains(big.getElement(i))){
                    s0.Add(big.getElement(i));
                }
            }
            return s0;
        }
        /// <summary>
        /// Check if the value is contained
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="value"></param>
        /// <returns>True if its contained, false otherwise</returns>
        public static bool operator ^(Set<T> s1, T value)
        {
            if (s1.Contains(value)) {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns>A set that contains the elements of s1 which not appear in s2</returns>
        public static Set<T> operator -(Set<T> s1, Set<T> s2)
        {
            Set<T> s0 = s1;
            for (int i = 0; i < s2.NumberOfElements; i++) {
                if (s1.Contains(s2.getElement(i))) {
                    s0.Remove(s2.getElement(i));
                }
            }
            return s0;
        }

        /// <summary>
        /// Override the operator [] for a set
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public T this[int pos]
        {
            get
            {
                return getElement(pos);
            }
            set
            {
                Add(value, pos);
            }
        }

    }
}
