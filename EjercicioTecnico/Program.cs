using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioTecnico
{
    class Program
    {
        static List<String> RepeticionEnOraciones(List<String> lista)
        {
            List<string> retorno = new List<string>();
            string fraseParametro = lista[0];
            string fraseComparacion = lista[0];
            string[] fraseParametroSeparada = fraseParametro.Split(CaracteresSeparacion());
            string[] fraseActual = fraseComparacion.Split(CaracteresSeparacion());
            int cantidadAparaciones = 0;
            for (int i = 0; i < fraseParametroSeparada.Length; i++)
            {
                for (int j = 0; j <= fraseActual.Length + 1;)
                {
                    if (ExistePalabra(fraseParametroSeparada[i], fraseActual) && fraseParametroSeparada[i].Length > 1)
                    {
                        cantidadAparaciones++;

                        if (cantidadAparaciones == lista.Count)
                        {
                            fraseComparacion = lista[0];
                            fraseActual = fraseComparacion.Split(CaracteresSeparacion());
                            retorno.Add(PrimeraLetraMayuscula(fraseParametroSeparada[i]));
                            cantidadAparaciones = 0;
                            j = 0;
                            break;
                        }
                        fraseComparacion = lista[j + 1];
                        fraseActual = fraseComparacion.Split(CaracteresSeparacion());
                        j++;
                    }
                    else
                    {
                        fraseComparacion = lista[0];
                        fraseActual = fraseComparacion.Split(CaracteresSeparacion());
                        cantidadAparaciones = 0;
                        break;
                    }
                }
            }
            Console.WriteLine("Las Palabras que se repiten son: ");
            SacarNumeros(retorno);
            return retorno.Distinct().ToList();
        }
        static Boolean ExistePalabra(string palabra, String[] Frase)
        {
            for (int i = 0; i < Frase.Length; i++)
            {
                if (palabra.Equals(Frase[i]))
                {
                    return true;
                }
            }
            return false;
        }
        static List<String> TransformarMinisculas(List<string> Frase)
        {
            List<String> aux = new List<string>();
            for (int i = 0; i < Frase.Count; i++)
            {
                aux.Add(Frase[i].ToLower());
            }
            return aux;
        }
        static void ImprimirLista(List<String> lista)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                Console.Write(lista[i] + " ");
            }
        }
        static String PrimeraLetraMayuscula(String s)
        {
            s = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s);
            return s;
        }
        static Char[] CaracteresSeparacion()
        {
            Char[] caracteres = { ',', '¡', '!', '.', ' ', '¿', '?', };
            return caracteres;
        }
        static void SacarNumeros(List<String> lista)
        {
            int number;
            for (int i = 0; i < lista.Count; i++)
            {
                if (Int32.TryParse(lista[i], out number))
                {
                    lista.Remove(lista[i]);
                }
            }
        }
        static void IngresoNumeros(List<string> lista)
        {
            Console.WriteLine("Ingrese una oración. Ingrese 'salir' para terminar la carga y ver que palabras se repiten en las oraciones.");
            string parametro = Console.ReadLine().Trim().ToLower();
            while (!parametro.Equals("salir"))
            {
                lista.Add(parametro);
                Console.WriteLine("Ingrese otra oración");
                parametro = Console.ReadLine().Trim().ToLower();
            }
        }

        static void Main(string[] args)
        {
            List<String> oraciones = new List<string>();
            IngresoNumeros(oraciones);
            if (oraciones.Count > 0)
            {
                ImprimirLista(RepeticionEnOraciones(oraciones));
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("No ha ingresado ninguna oracion");
                Console.ReadKey();
            }
        }
    }
}
