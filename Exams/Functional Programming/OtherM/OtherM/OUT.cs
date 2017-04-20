using System;
using System.Collections.Generic;

using System.Text;
using System.Threading.Tasks;

namespace ALL
{
    public class OutMethods
    {
        //metodo void que recibe 2 parametros int los suma y que modifica en memoria  la posicion del tercer parametro
        public static void suma(int a,int b, out int c)
        {
            c = a + b;
        }


        //lazy evaluation de un metodo que multiplica por 2
        public static int mult(Func<int> number)
        {
            int a = number();
            return 2 * a;
        }
    }

    public static class ExamenTPP1
    {
        /*
        *1.5 Puntos:
        Método de extension VOID rangeFind(int a, int b), retorna una lista
        con los elementos de la lista original encontrados entre a y b (indices)
        y un contador con el numero de elementos de la lista filtrada.
        */
        public static void rangeFind<T>(this IEnumerable<T> collection,int a, int b, out int contador, List<T> returningCol)
        {
            contador = 0;
            int count=0;
            returningCol = new List<T>();
            foreach (var item in collection) {
                if(count>=a && count <= b) {
                    returningCol.Add(item);
                    contador++;
                }
                count++;
            }
        }
        /*
        *2.5 Puntos:
        Otro método que hace la misma funcion que el primero pero en vez de VOID
        retorna un IEnumerable, además, en lugar de dos ints recibe dos 
        funciones que retornan un int cada una. Usar closures.
        */
        public static IEnumerable<T> rangeFind<T>(this IEnumerable<T> collection, Func<int> a, Func<int> b)
        {
            int count = 0;
            List<T> returningCol = new List<T>();
            foreach (var item in collection) {
                if (count >= a() && count <= b()) {
                    returningCol.Add(item);
                }
                count++;
            }
            return returningCol;
        }
        /*
        *1.5 Puntos:
        Crear GetElement que use memoization
        */
        //esta en list
        /*
        *1.5 Puntos:
        Testear el RangeFind()
        */

        /*
        3 Puntos:
        Queries
         */


    }
}
