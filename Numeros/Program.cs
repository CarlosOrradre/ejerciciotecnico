using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numeros
{
    class Program
    {
        static int CantidadAparaciones(List<int> numeros, int numero)
        {
            int aux = 0;
            for (int i = 0; i < numeros.Count; i++)
            {
                if (numeros[i] == numero)
                {
                    aux++;

                }
            }
            return aux;
        }
        static void ImprimirLista(List<int> lista)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                Console.Write(lista[i] + " ");
            }
        }

        static List<int> RepetidosIgualNumero(List<int> lista)
        {

            List<int> temporal = new List<int>();
            int apariciones = 0;
            for (int i = 0; i < lista.Count; i++)
            {
                for (int j = 0; j < lista.Count; j++)
                {
                    if (lista[i] == lista[j])
                    {
                        apariciones++;
                    }
                }
                if (temporal.Contains(lista[i]) != true && apariciones == lista[i])

                {
                    temporal.Add(lista[i]);
                }
                apariciones = 0;

            }
            return temporal;
        }

        static List<int> MayorOcurrentes(List<int> lista)
        {
            List<int> mayoresOcurrentes = new List<int>();
            int cantidadaApracionesReferencia = CantidadAparaciones(lista, lista[0]);

            for (int i = 0; i < lista.Count; i++)
            {

                if (CantidadAparaciones(lista, lista[i]) > cantidadaApracionesReferencia)
                {
                    mayoresOcurrentes.Clear();
                    cantidadaApracionesReferencia = CantidadAparaciones(lista, lista[i]);
                    mayoresOcurrentes.Add(lista[i]);
                }
                if (CantidadAparaciones(lista, lista[i]) == cantidadaApracionesReferencia && !mayoresOcurrentes.Contains(lista[i]))
                {
                    cantidadaApracionesReferencia = CantidadAparaciones(lista, lista[i]);
                    mayoresOcurrentes.Add(lista[i]);
                }

            }
            return mayoresOcurrentes;
        }

        static List<int> MenosOcurrentes(List<int> lista)
        {
            List<int> menosOcurrentes = new List<int>();
            int cantidadAparacionesReferencia = CantidadAparaciones(lista, lista[0]);

            for (int i = 0; i < lista.Count; i++)
            {
                if (CantidadAparaciones(lista, lista[i]) < cantidadAparacionesReferencia)
                {
                    menosOcurrentes.Clear();
                    cantidadAparacionesReferencia = CantidadAparaciones(lista, lista[i]);
                    menosOcurrentes.Add(lista[i]);
                }

                if (CantidadAparaciones(lista, lista[i]) == cantidadAparacionesReferencia && !menosOcurrentes.Contains(lista[i]))
                {
                    cantidadAparacionesReferencia = CantidadAparaciones(lista, lista[i]);
                    menosOcurrentes.Add(lista[i]);
                }

            }
            return menosOcurrentes;
        }

        static void IngresoNumeros(List<int> lista)
        {
            Console.WriteLine("Ingrese un numero de uno en uno: Ingrese 'terminar' para finalizar la carga.");
            int numero = 0;
            string parametro = Console.ReadLine().Trim().ToLower();
            while (!parametro.Equals("terminar"))
            {
                if (Int32.TryParse(parametro, out numero))
                {
                    lista.Add(numero);
                }
                else
                {
                    Console.WriteLine("Lo Ingresado no es un numero o intento ingresar dos numeros al mismo tiempo.");
                }
                Console.WriteLine("Ingrese otro numero");
                parametro = Console.ReadLine().Trim().ToLower();
            }
        }
        static void ImpresionEstructura(List<int> numeros)
        {

            Console.WriteLine();
            Console.WriteLine("El promedio es: " + numeros.Average());
            Console.WriteLine("Menor: " + numeros.Min() + " " + "Mayor: " + numeros.Max());
            Console.Write("Menos Ocurrencias: " + " ");
            ImprimirLista(MenosOcurrentes(numeros));
            Console.Write(" ");
            Console.Write("Mayor Ocurrencias: ");
            ImprimirLista(MayorOcurrentes(numeros));
            Console.Write("Repeticiones igual al número: ");
            ImprimirLista(RepetidosIgualNumero(numeros));
        }



        static void Main(string[] args)
        {
            List<int> numeros = new List<int>();
            IngresoNumeros(numeros);
            if (numeros.Count() != 0)
            {
                Console.WriteLine("La lista de números es: ");
                ImprimirLista(numeros);
                ImpresionEstructura(numeros);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("No ha ingresado ningún número.");
                Console.ReadKey();
            }
        }
    }
}
