using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDLL;

namespace Example3
{
    class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car();

            Console.WriteLine("id:"+myCar.IdCar);
            Console.WriteLine("brand:" + myCar.Brand);
            Console.WriteLine("driven km:" + myCar.Driven_km);
            Console.WriteLine("number of constructed cars: {0}", Car.NumberOfConstructedCars);
            Console.WriteLine();


            Car myCar2 = new Car {IdCar="823 ",Brand ="Citroen "};

            Console.WriteLine(myCar2.ToString());
            Class1.hi();//dll
            Console.ReadLine();
        }
    }
}
