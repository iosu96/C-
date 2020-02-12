using System;

namespace ej11
{
    class Program
    {
        private static int n;
        private static int operacion;

        static void Main(string[] args)
        {
            bool sig;
            Console.WriteLine("OPERACIÓN CON MATRICES:");
            do
            {
                try
                {
                    sig = false;
                    Console.WriteLine("Ingrese la operación a realizar.\n1.Suma\n2.Resta\n3.Multiplicación ");
                    operacion = Convert.ToInt32(Console.ReadLine());
                }
                catch(FormatException e)
                {
                    Console.WriteLine("Por favor ingrese un número.");
                    sig = true;
                }
            } while (sig);

            do
            {
                try
                {
                    sig = false;
                    Console.Write("\nIngrese el tamaño de la matriz cuadrada: ");
                    n = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Por favor ingrese un número.");
                    sig = true;
                }
            } while (sig);

            float[,] Matriz1 = new float[n, n];
            float[,] Matriz2 = new float[n, n];
            float[,] Resultado = new float[n, n];

            Console.WriteLine(" \n Datos de la matriz 1: ");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    do
                    {
                        try
                        {
                            sig = false;
                            Console.Write("Ingresa Dato (Fila: {0} - Columna: {1}): ", i + 1, j + 1);
                            Matriz1[i, j] = float.Parse(Console.ReadLine());
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("Por favor ingrese un número.");
                            sig = true;
                        }
                    } while (sig);
                }
            }

            Console.WriteLine(" \n Datos de la matriz 2: ");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    do
                    {
                        try
                        {
                            sig = false;
                            Console.Write("Ingresa Dato (Fila: {0} - Columna: {1}): ", i + 1, j + 1);
                            Matriz2[i, j] = float.Parse(Console.ReadLine());
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("Por favor ingrese un número.");
                            sig = true;
                        }
                    } while (sig);
                }
            }
            if(operacion == 3)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Resultado[i, j] = 0;
                        for (int z = 0; z < n; z++)
                        {
                            Resultado[i, j] += Matriz1[i, z] * Matriz2[z, j];
                        }
                    }
                }

            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if(operacion == 1)
                            Resultado[i, j] = Matriz1[i, j] + Matriz2[i, j];
                        else
                            Resultado[i, j] = Matriz1[i, j] - Matriz2[i, j];
                    }
                }

            }

            for (int i = 0; i < n; i++)
            {
                Console.Write("|");
                for (int j = 0; j < n; j++)
                {
                    Console.Write(" {0} ", Matriz1[i,j]);
                }
                Console.Write("|\t|");
                for (int j = 0; j < n; j++)
                {
                    Console.Write(" {0} ", Matriz2[i, j]);
                }
                Console.Write("|\t|");
                for (int j = 0; j < n; j++)
                {
                    Console.Write(" {0} ", Resultado[i, j]);
                }
                Console.WriteLine("|");
            }
        }
    }
}
