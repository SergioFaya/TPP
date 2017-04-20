using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ListTest
{

    class Person{
        public int Age { get; set; }
        public string Name { get; set; }

        public Person(int age, string name)
        {
            Age = age;
            Name = name;
        }

        public override string ToString()
        {
            return "Age: " + Age + " Name: " + Name;
        }

    }
    

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TesList()
        {
            IList<int> integers = new List<int>();
            IList<string> strings = new List<string>();
            IList<Person> slaves = new List<Person>();

            //Add elements
            for (int i = 0; i < 15; i++)
            {
                integers.Add(i);
                strings.Add(i + "");
                slaves.Add(new Person(i, "Slave:" + i));
            }
            //Number of elements
            Assert.AreEqual(integers.Count, 15);
            Assert.AreEqual(strings.Count, 15);
            Assert.AreEqual(slaves.Count, 15);

            //Using foreach
            int j = 0;
            foreach (int item in integers)
            {
                Assert.AreEqual(item,j);
                j++;
            }
            j = 0;
            foreach (string item in strings)
            {
                Assert.AreEqual(item, j+"");
                j++;
            }
            //get the index of the first occurrence
            Assert.AreEqual(integers.IndexOf(0),0);
            //get and set at the ith pos
            Person p = new Person(20, "Freeman");
            slaves[0] = p;
            Assert.AreEqual(slaves[0].Age,20);
            Assert.AreEqual(slaves[0].Name, "Freeman");
            //consult wheter an element is in the vector or not
            Assert.IsTrue(slaves.Contains(p));
            Assert.IsFalse(slaves.Contains(new Person(5, "Joselito")));
            for (int i = 0; i < integers.Count; i++) {
                Assert.IsTrue(integers.Contains(i));
            }
            //obtain the index of the first occurrence of an element and then remove it
            var index = 0;
            if (slaves.Contains(p)) {
                index = slaves.IndexOf(p);
            }
            slaves.RemoveAt(index);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException),"if the exception is thrown the remove works")]
        public void TestDictionary()
        {
            //add elements with a given key and value
            IDictionary<int,Person> dictionary = new Dictionary<int, Person>();
            for (int i = 0; i < 10; i++) {
                dictionary.Add(i,new Person(i, "Slave:" + i));
            }
            Person p = new Person(20, "Freeman");
            dictionary.Add(69,p);

            //consult whether a key exist or not in a dictionary
            for (int i = 0; i < 10; i++) {
                Assert.IsTrue(dictionary.ContainsKey(69));
                Assert.IsTrue(dictionary.Contains(new KeyValuePair<int, Person>(69,p))); 
            }
            //obtain the number of pairs in a collection
            Assert.AreEqual(dictionary.Count,11);
            //get abd set the value of a key
            Person q = dictionary[6];
            Assert.AreEqual(q.Age, 6);
            Assert.AreEqual(q.Name, "Slave:6");
            dictionary[6] = p;
            Assert.AreEqual(dictionary[6].Age, 20);
            Assert.AreEqual(dictionary[6].Name, "Freeman");
            //delete a pair given a key
            dictionary.Remove(69);
            var dic = dictionary[69];
            //iterate with a for each through the pairs
            foreach (var item in dictionary) {
                Console.WriteLine(item.ToString());
            }

        }
    }
}