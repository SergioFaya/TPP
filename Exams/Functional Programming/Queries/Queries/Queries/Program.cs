using System;
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
            Console.WriteLine(" Find the first Person in people that is older than 20:");
            Console.WriteLine(people.First((p) => p.Age > 20).Name);
            Console.WriteLine();
            // Create a collection with people that are 20 years of age.
            Console.WriteLine("people that are 20 years of age.");
            var twenty = people.Where(p => p.Age > 20);
            foreach (var item in twenty) {
                Console.WriteLine(item.Name + " " +item.Age);
            }
            Console.WriteLine();
            // Create a collection that has strings of the form "<person_name> is <person.age> years old." with the elements of people.
            Console.WriteLine("strings of the form < person_name > is < person.age > years old with the elements of people.");
            var aged = people.Select(p => p.Name + " is " + p.Age + " years old");
            foreach (var item in aged) {
                Console.WriteLine("\t"+item);
                    
            }
            Console.WriteLine();
            // Calculate the sum of the ages of people.
            Console.WriteLine("Sum of the ages of people");
            int zero = 0;
            Console.WriteLine(people.Aggregate(zero, (s, p) => s = s + p.Age));
            Console.WriteLine();
            // Calculate the sum of the ages of people over 20 years of age.
            Console.WriteLine("Sum of the ages of people over 20 years of age.");
            Console.WriteLine(twenty.Aggregate(zero, (c, p) => c += p.Age));
            Console.WriteLine();
            // Find the youngest and the oldest person in people.
            Console.WriteLine("Youngest and the oldest person in people.");
            var sortedByAge= people.OrderBy(p => p.Age);
            Console.WriteLine("Older---" + sortedByAge.Last().Name);
            Console.WriteLine( "Younger---" + sortedByAge.First().Name);
            Console.WriteLine();
            // Print people ordered by age
            Console.WriteLine("People ordered by age");
            foreach (var item in sortedByAge) {
                Console.WriteLine("\t" + item.Name + "  " + item.Age);
            }

            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
