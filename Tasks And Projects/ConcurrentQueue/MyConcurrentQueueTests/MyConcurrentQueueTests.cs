using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyConcurrentQueue;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConcurrentQueue.Tests
{
    [TestClass()]
    public class MyConcurrentQueueTests
    {
        MyConcurrentQueue<int> queue = new MyConcurrentQueue<int>();
        Thread[] threads = new Thread[10];

        [TestMethod()]
        public void IsEmptyTest()
        {
            //Enqueue
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(() => queue.Enqueue(5));
                threads[i].Start();
            }
            for (int i = 0; i < threads.Length; i++) {
                threads[i] = new Thread(() => queue.Dequeue());
                threads[i].Start();
            }

            foreach (var t in threads)
            {
                t.Join();
            }
            Console.WriteLine(queue.NumberOfElements);
            Assert.IsTrue(queue.NumberOfElements == 0);
            Assert.IsTrue(queue.IsEmpty());
        }
    }
}