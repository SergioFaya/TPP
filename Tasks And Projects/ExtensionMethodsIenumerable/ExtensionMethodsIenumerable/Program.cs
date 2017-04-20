using PTP_HW_5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication1
{
    class Program
    {
        public static T Find<T>(IEnumerable<T> collection, Predicate<T>  pred)
        {
            foreach (T item in collection)
            {
                if (pred(item))
                {
                    return item;
                }
            }
            return default(T);
        }

        public static List<T> Filter<T>(IEnumerable<T> collection, Predicate<T> pred)
        {
            List<T> l = new List<T>();
            foreach (T item in collection)
            {
                if (pred(item))
                {
                    l.Add(item);
                }
            }
            return l;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"> First type is the type of the collection</typeparam>
        /// <typeparam name="P"> Second type is the output type</typeparam>
        /// <param name="collection">Collection of type T</param>
        /// <param name="function"></param>
        /// <returns></returns>
        public static P Reduce<T,P>(IEnumerable<T> collection,Func<T,P,P> function)
        {
            P something = default(P);
            foreach (T item in collection) {
                something = function(item,something);
            }
            return something;
        }

        public static void Main(string[] args)
        {
            Person[] slaves = Factory.CreatePeople();
            Person res = Find(slaves, p => p.Name == "Mary");
            Console.WriteLine(res.ToString());
            List<Person> l = Filter(slaves, p => p.Name == "Mary");
            foreach (var item in l) {
                Console.WriteLine(item.ToString());
            }
            Angle[] angles = Factory.CreateAngles();
          
            Console.ReadLine();     
        }

        
    }
}
