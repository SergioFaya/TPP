﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ptp7examples
{
    class Person
    {
        public String Name { get; set; }
        public int Age { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person[] people = {
            new Person{Name = "John", Age = 18},
            new Person{Name = "Mary", Age = 7},
            new Person{Name = "Oscar", Age = 57},
            new Person{Name = "Laura", Age = 43},
            new Person{Name = "James", Age = 23},
            new Person{Name = "Lucy", Age = 12},
            new Person{Name = "Lucas", Age = 9}
                              };


            // Find the first Person in people that is older than 20.
            people.First((p) => p.Age > 20);

            // Create a collection with people that are 20 years of age.


            // Create a collection that has strings of the form "<person_name> is <person.age> years old." with the elements of people.


            // Calculate the sum of the ages of people.


            // Calculate the sum of the ages of people over 20 years of age.


            // Find the youngest and the oldest person in people.

            
            // Print people ordered by age


        }
    }
}
