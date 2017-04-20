using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLinkedList;
using System.Linq;
using System.Collections.Generic;
using PTP_HW_5;
using System;

namespace ExtensionDefaultTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMyList()
        {
            Person[] people = Factory.CreatePeople();
            LinkedListEnumerable<Person> list = new LinkedListEnumerable<Person>();
            foreach (var p in people) {
                list.Add(p);
            }
            //Find
            Person james = list.First(p => p.Name == "James");

            Assert.AreEqual(james.Name, "James");
            Assert.AreEqual(james.Surname, "Smith");
            Assert.AreEqual(james.Id, "9876384A");
            //Filter
            IEnumerable<Person> whatever = list.Where(p => p.Name == "Mary");

            foreach (var item in whatever) {
                Assert.IsTrue(item.Name == "Mary");
            }
            //Map
            //Every Id of the people in the array
            IEnumerable<String> whatever2 = list.Select(p => p.Id);
            string[] ids = { "9876384A", "103478387F", "23476293R", "4837649A", "67365498B", "98673645T", "56837645F", "87666354D", "9376384K", "3582356F"};
            int i=0;
            foreach (var item in whatever2) {
                Assert.AreEqual(ids[i], item);
                i++;
            }
            //Reduce
            //Heir of the first and last person (heir takes the father's id)
            Person heir = list.Aggregate((x, d) => new Person(x.Name, d.Surname, x.Id));
            Assert.AreEqual(heir.Name, list.getElement(0).Name);
            Assert.AreEqual(heir.Surname, list.getElement(list.NumberOfElements-1).Surname);
            Assert.AreEqual(heir.Id, list.getElement(0).Id);
        }

        [TestMethod]
        public void TestList()
        {
            Person[] people = Factory.CreatePeople();
            LinkedList<Person> list = new LinkedList<Person>();
            foreach (var p in people) {
                list.AddLast(p);
            }
            //Find
            Person james = list.First(p => p.Name == "James");

            Assert.AreEqual(james.Name, "James");
            Assert.AreEqual(james.Surname, "Smith");
            Assert.AreEqual(james.Id, "9876384A");
            //Filter
            IEnumerable<Person> whatever = list.Where(p => p.Name == "Mary");

            foreach (var item in whatever) {
                Assert.IsTrue(item.Name == "Mary");
            }
            //Map
            //Every Id of the people in the array
            IEnumerable<String> whatever2 = list.Select(p => p.Id);
            string[] ids = { "9876384A", "103478387F", "23476293R", "4837649A", "67365498B", "98673645T", "56837645F", "87666354D", "9376384K", "3582356F" };
            int i = 0;
            foreach (var item in whatever2) {
                Assert.AreEqual(ids[i], item);
                i++;
            }
            //Reduce
            //Heir of the first and last person (heir takes the father's id)
            Person heir = list.Aggregate((x, d) => new Person(x.Name, d.Surname, x.Id));
            Assert.AreEqual(heir.Name, list.ElementAt(0).Name);
            Assert.AreEqual(heir.Surname, list.ElementAt(list.Count - 1).Surname);
            Assert.AreEqual(heir.Id, list.ElementAt(0).Id);
        }
    }
}
