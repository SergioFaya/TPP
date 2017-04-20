using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStack.Tests
{
    [TestClass()]
    public class StackTests
    {
        [TestMethod()]
        public void PushPopTest()
        {
            Stack<int> s = new Stack<int>(100);
            Assert.IsTrue(s.IsEmpty);
            for (int i = 1; i < 200; i++) { 
                s.Push(i);
                Assert.IsFalse(s.IsEmpty);
                
            }
            Assert.IsTrue(s.IsFull);
            Assert.IsFalse(s.IsEmpty);
            string str = s.ToString();
            for (int i = 100; i >0; i--) {
                Assert.AreEqual(s.Pop(), i);
            }
            Assert.AreEqual(s.ToString(),"");
            Assert.IsFalse(s.IsFull);
            Assert.IsTrue(s.IsEmpty);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Stack<int> s = new Stack<int>(4);
            for (int i = 0; i < 5; i++) {
                s.Push(i);
            }
            string str = "[3]\n[2]\n[1]\n[0]\n";
            Assert.AreEqual(str, s.ToString());
        }
    }
}