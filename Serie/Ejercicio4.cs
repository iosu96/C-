using System;

namespace Ej4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Se declara la variable que almacenará el valor que reciba del usuario
            int numero = 0;
            //Se declaran variables tipo int64, ya que la serie de fibonacci puede arrojar número muy grandes
            Int64 aux1 = 1, aux2 = 0, fibonacci=0;
            //Se declara un booleano para controlar el bucle do-while
            bool sig = true;
            do
            {
                //con try-catch se controlan errores de Formato de datos
                try
                {
                    Console.Write("Ingrese el número hasta el cual desea mostrar la seria de Fibonacci: ");
                    //Espera del usuario un número para calcular su serie de fibonacci
                    numero = Convert.ToInt32(Console.ReadLine());
                    //Si el número es entero mayor o igual a 0, saldrá del bucle 
                    if (numero >= 0)
                        sig = false;
                    //Si es un entero menor a 0, volverá a pedir un número al usuario
                    else
                        Console.WriteLine("Favor de ingresar un número mayor a 0");
                }
                catch (FormatException)
                {
                    //si l oque recibe del usuario no es un entero, saldrá esta excepción
                    Console.WriteLine("Error al ingresar dato, favor de verificar que sea un número entero.");
                }
            }
            while (sig);
            //Si el número es 0, no se necesita calcular su serie, ya que fibonacci de 0 es 1
            if (numero == 0)
                Console.WriteLine("0:\t1");
            //Caso contrario, calcula la serie hasta el número ingresado por el usuario
            else
            {
                //Se crea el ciclo para ls número del 0 al N (donde N es el número ingresado por el usuario)
                for (int i = 0; i <= numero; i++)
                {
                    //Ya que la serie de fibonacci es sumar los dos predecesores de un número, se calculará desde 1=0+1, 2=1+1,3=2+1,4=3+2...
                    //aux1 almacenará el valor de fibonacci de primer número predecesor, aux2 almacenará el segundo número predecesor 
                    aux2 = fibonacci;
                    fibonacci += aux1;
                    aux1 = aux2;
                    //Se escribirá en consola en formato numero: valor en la serie de fibonacci
                    Console.WriteLine("{0}:\t{1}",i,fibonacci);
                }
            }
            Console.ReadKey();
        }
    }
}
