using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinkedListGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListGeneric.Tests
{
    [TestClass()]
    public class LinkedListTests
    {

        private class Person
        {
            public int Age { get; set; }
            public string Name { get; set; }
            public Person(int age, string name)
            {
                Age = age;
                Name = name;
            }

            public override string ToString()
            {
                return Age + " " + Name;
            }
        }


        private LinkedList<Person> AddEnd()
        {
            LinkedList<Person> list = new LinkedList<Person>();
            Person p, q, r, s, t;
            list.Add(p = new Person(5, "Enano"));
            list.Add(q = new Person(15, "Adolescente"));
            list.Add(r = new Person(67, "Jubilao"));
            list.Add(s = new Person(1000, "Momia"));
            list.Add(t = new Person(12, "Peter Pan"));
            return list;
        }

        private LinkedList<Person> AddIn()
        {
            LinkedList<Person> list = new LinkedList<Person>();
            Person p, q, r, s, t;
            list.Add(p = new Person(5, "Enano"),0);
            list.Add(q = new Person(15, "Adolescente"),0);
            list.Add(r = new Person(67, "Jubilao"),0);
            list.Add(s = new Person(1000, "Momia"),0);
            list.Add(t = new Person(12, "Peter Pan"),0);
            return list;
        }

        [TestMethod()]
        public void AddEndTest()
        {
            LinkedList<Person> list = AddEnd();
            string str = "-5 Enano-15 Adolescente-67 Jubilao-1000 Momia-12 Peter Pan";
            Assert.AreEqual(list.ToString(), str);
        }

        [TestMethod()]
        public void AddTest()
        {
            LinkedList<Person> list = AddIn();
            string str = "-12 Peter Pan-1000 Momia-67 Jubilao-15 Adolescente-5 Enano";
            Assert.AreEqual(list.ToString(), str);
        }

        [TestMethod]
        public void RemoveTest()
        {
            LinkedList<Person> list = new LinkedList<Person>();
            Person p, q, r, s, t;
            list.Add(p = new Person(5, "Enano"));
            list.Add(q = new Person(15, "Adolescente"));
            list.Add(r = new Person(67, "Jubilao"));
            list.Add(s = new Person(1000, "Momia"));
            list.Add(t = new Person(12, "Peter Pan"));
            Assert.AreEqual(list.getElement(0), p);
            Assert.AreEqual(list.getElement(1), q);
            Assert.AreEqual(list.getElement(2), r);
            Assert.AreEqual(list.getElement(3), s);
            Assert.AreEqual(list.getElement(4), t);
            list.RemovePos(0);
            Assert.AreEqual(list.getElement(0), q);
            Assert.AreEqual(list.getElement(1), r);
            Assert.AreEqual(list.getElement(2), s);
            Assert.AreEqual(list.getElement(3), t);
            list.RemovePos(2);
            Assert.AreEqual(list.getElement(0), q);
            Assert.AreEqual(list.getElement(1), r);
            Assert.AreEqual(list.getElement(2), t);

        }
    }
}