using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example3
{
    class Car
    {
        public static int NumberOfConstructedCars = 0;
        private String idCar;
        /*
        public string IdCar
        {
            get
            {
                return idCar;
            }

            set
            {
                idCar = value;
            }
        }
        */
        public string IdCar { get; set; }
        public string Brand { get; set; }
        public float Driven_km { get; set; }

        public Car()
        {
            IdCar = "123";//string.Empty;
            Brand = "Ford";
            Driven_km = 1.5f;
            ++NumberOfConstructedCars;
        }
        
        public Car(string id, string brand, float km)
        {
                IdCar = id;
                Brand = brand;
                Driven_km = km;
                ++NumberOfConstructedCars;
        }
        
        ~Car()
        {
            System.Diagnostics.Trace.WriteLine("Garbage colected from car "+IdCar +":)");
        }

        public override string ToString()
        {
            return "IdCar: " + IdCar + " Brand: " + Brand + " Driven_km: " + Driven_km; 
        }

        public void drive(float km)
        {
            Driven_km += km;
        }
    }
}
