using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedListGeneric;

namespace MyList
{
    public interface MyList<T>
    {
        void Add(T value);

        void Add(T value, int pos);

        void Remove(T value);

        void RemovePos(int pos);

        Node<T> getNode(int pos);

        T getElement(int pos);

        bool Contains(T value);

        String ToString();
    }
}
