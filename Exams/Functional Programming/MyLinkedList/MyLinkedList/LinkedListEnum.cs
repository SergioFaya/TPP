using System;
using System.Collections;
using System.Collections.Generic;
using MyLinkedList;

namespace MyLinkedList
{
    public class LinkedListEnumerator<T> : IEnumerator<T>
    {

        public LinkedListEnumerable<T> list;
        int position = -1;


        public LinkedListEnumerator(LinkedListEnumerable<T> list)
        {
            this.list = list;
        }

        public T Current
        {
            get
            {
                return list.getElement(position);
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>true if you can go further, false otherwise</returns>
        public bool MoveNext()
        {
            position++;
            return (position < list.NumberOfElements);
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
