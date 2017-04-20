using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLinkedList;
namespace MyConcurrentQueue
{
    public class MyConcurrentQueue<T>
    {
        LinkedListEnumerable<T> list = new LinkedListEnumerable<T>();
        //Locker Objects
        private static object _lockenqueue = new object();
        private static object _lockdequeue = new object();
        private static object _lockpeek = new object();
        private static object _lockIsEmpty = new object();
        private static object _lockNElements = new object();

        public int NumberOfElements {
            get {
                //lock (_lockNElements) {
                    return list.NumberOfElements;
                //}
            }
        }
        
        public bool IsEmpty()
        {
            lock (_lockIsEmpty) {
                return NumberOfElements == 0;
            }
        }

        public void Enqueue(T value)
        {
            if (value == null) {
                throw new NullReferenceException();
            }
            lock (_lockenqueue) { 
                list.Add(value);
            }
        }

        public T Peek()
        {
            T value = default(T);
            if (NumberOfElements == 0) {
                throw new IndexOutOfRangeException(); 
            }
            lock (_lockpeek) {
                value = list.getElement(0);
            }
            return value;
        }
        public T Dequeue()
        {
            T value = default(T);
            if (NumberOfElements == 0) {
                throw new IndexOutOfRangeException();
            }
            lock(_lockdequeue){ 
                value = list.getElement(0);
                list.RemovePos(0);
            }
            return value;
        }
    }
} 