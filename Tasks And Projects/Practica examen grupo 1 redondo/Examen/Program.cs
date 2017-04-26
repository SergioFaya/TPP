using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Threading;

namespace Examen
{
    class Program
    {
        /*
            metodo1 = Uno era sacra el minimo y el maximo en un intervalo de una array de numeros aleatorias double
            metodo2 = Otro era crear un diccionario y pasarle las palabras de mas de 7 caracteres y de menos de 4
            Pero para q sea concurrent todo
            Tbn hacer este mismo pero con el master worker
            metodo3  = Luego con plinq te pasan un array de strings y retornar la array sin q halla strings vacios
            Si habia un string vacio habia q aumentar un counter
            Y el ultimo te pedia lo mismo q este pero con tpl
            Y esos 5 eran, El q menos el primero q hice Valia 1,5, El resto 2 o 2'5 
         */

        static void Main(string[] args)
        {
            int i = 0;
            double[] randomArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            string[] palabras = { "holas", "skljlakh", "1", "", "" };
            Console.WriteLine(randomArray);
            IDictionary<int, string> dic = new Dictionary<int, string>();
            double min = 0;
            double max = 0;
            Thread thread1 = new Thread(() => metodo1(randomArray, 2, 5, out min, out max));
            Thread thread2 = new Thread(() => metodo2(dic, palabras));
            thread1.Start();
            thread1.Join();
            thread2.Start();
            thread2.Join();
            Console.WriteLine("minimun = " + min + "maximum" + max);
            string[] a= metodo3(palabras);
            int b = metodo4(palabras);
            Console.WriteLine(b);

            Console.ReadLine();
            
        }

        public static void metodo1(double[] array, int a, int b,out double min,out double max)
        {
            min = Double.MaxValue;
            max = 0;
            for (int i = 0; i < array.Length; i++) {
                if(i >= a && i <= b) {
                    if (array[i] > max) {
                        max = array[i];
                    }
                    if (array[i]<min){
                        min = array[i];
                    }
                }
            }
        }
        
        public static void metodo2(IDictionary<int,string> dic,string[] palabras)
        {
            for (int i = 0; i < palabras.Length; i++) {
                if(palabras[i].Length > 7 || palabras[i].Length < 4) {
                    dic.Add(i, palabras[i]);
                }
            }
        }

        public static string[] metodo3(string[] palabras) {
            palabras.AsParallel().Where((s) => s.Trim().Length != 0);
            return palabras;
        }

        //Interlocked.increment(out counter); para incrementar en paralelo
        public static int metodo4(string[] palabras) {
            string[] returnStrings = new string[palabras.Length];
            int counter = 0;
            Parallel.ForEach(palabras, w =>
            {
                if(w.Trim().Length!= 0) {
                    returnStrings[counter] = w;
                }else {
                    Interlocked.Increment(ref counter);
                    Console.WriteLine(w + " counter:" + counter);
                }
                
            });
            return counter ;
        }
    }
}
