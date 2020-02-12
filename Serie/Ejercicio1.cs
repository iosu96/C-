using System;

namespace Ej1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Se declaran las variables que el programa ocupará, se inicializan en 0
            int numero=0,sumatoria=0;
            bool sig;
            //Mediante la variable booleana sig, controlará el proceso do.while, el cual se ejecutará hasta que el usuario ingrese un número entero mayor a 0
            do
            {
                //Con excepciones, se intentará controlar el tipo de dato que recibe del usuario
                try
                {
                    sig = false;
                    Console.Write("Ingrese el número natural hasta donde desea sumar: ");
                    numero = Convert.ToInt32(Console.ReadLine());
                    if (numero < 1)
                    {
                        Console.WriteLine("Número incorrecto, favor de ingresa sólo numeros enteros mayores a 0");
                    }

                }
                catch (FormatException)
                {
                    Console.WriteLine("Por favor ingrese un número entero.");
                    sig = true;
                }
            } while (sig);
            //Con el ciclo for, se hará la sumatoria hasta el número natural n ingresado por el usuario
            for (int i = 1; i <= numero; i++)
                sumatoria += i;

            //Al finalizar, se dará formato de salida al texto
            Console.WriteLine("La sumatoria de números naturales hasta el {0} es de: {1}",numero,sumatoria);
            Console.ReadKey();
        }
    }
}
