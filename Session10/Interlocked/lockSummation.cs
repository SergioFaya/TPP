using System;
using System.Threading;

namespace lab10
{
    internal class lockSummation : Summation
    {
        static private object _locker = new object();
        
        internal lockSummation(int value, int numberOfThreads) :
            base(value, numberOfThreads)
        {
        }
        
        override protected void DecrementValue()
        {
            lock (_locker)
            {
                value = value - 1;
            }
        }

    }
}