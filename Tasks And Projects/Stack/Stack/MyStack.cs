using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedListGeneric;
namespace MyStack
{
    public class Stack<T>
    {
        public bool IsEmpty
        {
            get
            {
                return list.NumberOfElements == 0;
            }
        }
        public bool IsFull
        {
            get
            {
                return list.NumberOfElements == MaxNumberOfElements;
            }
        }
        private uint MaxNumberOfElements;
        private LinkedList<T> list;

        public Stack(uint maxNumberOfElements)
        {
            list = new LinkedList<T>();
            MaxNumberOfElements = maxNumberOfElements;
        }

        public void Push(T value)
        {
            if (list.NumberOfElements < MaxNumberOfElements)
            {
                list.Add(value);
            }
        }

        public T Pop()
        {
            T element = list.getElement(list.NumberOfElements-1);
            list.RemovePos(list.NumberOfElements-1);
            return element;
        }

        public override string ToString()
        {
            string str = "";
            for (int i = list.NumberOfElements-1; i >=0 ; i--) {
                str += "["+list.getElement(i)+"]\n";
            }
            return str;
        }
    }
}
