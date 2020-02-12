using System;

namespace ej2
{
    class Program
    {
        private static int digito1;//Se declara las variables en donde se va a almacenar
        private static int digito2;//lo que el usuario ingresa
        static void Main(string[] args)
        {
            bool sig; //Esta variable permitirá que el programa continúe hasta que el usuario ingrese un número entero.
            do
            {
                try
                {
                    sig = false;
                    Console.Write("Ingrese el primer dígito del 1 al 9: ");
                    digito1 = Convert.ToInt32(Console.ReadLine());
                    if(digito1>9 || digito1 < 1)//Se validará que el usuario haya ingresado un dígito entre 1 y 9,
                    {
                        Console.WriteLine("Por favor verifique su número.");
                        sig = true;
                    }

                }
                catch (FormatException e)
                {
                    Console.WriteLine("Por favor ingrese un número.");//Se ejecutará este error si el usuario no ingresa un número
                    sig = true;
                }
            } while (sig);
            do
            {
                try
                {
                    sig = false;
                    Console.Write("Ingrese el segundo dígito del 1 al 9: ");
                    digito2 = Convert.ToInt32(Console.ReadLine());
                    if (digito2 > 9 || digito2 < 1)//Se validará que el usuario haya ingresado un dígito entre 1 y 9,
                    {
                        Console.WriteLine("Por favor verifique su número.");
                        sig = true;
                    }

                }
                catch (FormatException e)
                {
                    Console.WriteLine("Por favor ingrese un número entero.");//Se ejecutará este error si el usuario no ingresa un número
                    sig = true;
                }
            } while (sig);
            string coincidencia,dig1 = Convert.ToString(digito1),dig2 = Convert.ToString(digito2);
            //A continuación se imprimirán 100 números del 1 al 100 mediante un ciclo
            for(int i = 1; i <= 100; i++)
            {
                coincidencia = Convert.ToString(i);
                //Si un número es múltiplo del digito 1 o el digito 2, o el número contiene el dígito 1 o dígito 2, se imprimirá Clap
                if ((i % digito1) == 0 || (i % digito2) == 0 || coincidencia.Contains(dig1) || coincidencia.Contains(dig2))
                    Console.WriteLine("Clap");
                //Caso contrario imprime el número
                else
                    Console.WriteLine(i);
            }
            Console.ReadKey();
        }
    }
}
