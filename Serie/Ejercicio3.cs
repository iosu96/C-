using System;
//Se agrega System.Text.RegularExpressions para poder usar expresiones regulares.
using System.Text.RegularExpressions;

namespace Ej3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Se declaran las variables que se usará en la ejecución del programa
            string cadena,cadenaNueva;
            bool sig=true;
            do
            {
                Console.WriteLine("Ingrese una  cadena:");
                //Se  almacenará lo que el usuario ingrese en la variable cadena
                cadena = Console.ReadLine();
                //Se verifica que la cadena que ingresó el usuario sea mayor a 0 para salir del bucle
                if (cadena.Length > 0)
                    sig = false;
                //Caso contrario le indica al usuario que debe ingresar al menos un caracter.
                else
                    Console.WriteLine("Por favor ingrese una cadena de al menos 1 caracter.");
            }
            while (sig);
            //Mediante expresiones regulares, sustituirá cualquier vocal, ya sea mayúscula o minúscula por una f, seguida de esa vocal.
            cadenaNueva = Regex.Replace(cadena, "([aeiouAEIOU])", "f$0");
            //Se imprime en pantalla el resutlado nuevo.
            Console.WriteLine(cadenaNueva);
            Console.ReadKey();
        }
    }
}
