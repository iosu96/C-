using System;

namespace evaluacion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Favor de ingresar el número de alumnos a calificar:");
            int numero = Convert.ToInt32(Console.ReadLine());
            Estudiante[] estudiantes = new Estudiante[numero];
            for(int i = 0; i < estudiantes.Length; i++)
            {
                Console.WriteLine("Datos del alumno {0}:", i + 1);
                Console.Write("Nombre: ");
                string nombre = Console.ReadLine();
                Console.Write("Apellido(s): ");
                string apellido = Console.ReadLine();
                Console.Write("Calificación del proyecto: ");
                double proyecto = Convert.ToDouble(Console.ReadLine());
                Console.Write("Número de tareas: ");
                int tareas = Convert.ToInt32(Console.ReadLine());
                Console.Write("Número de participaciones: ");
                int part = Convert.ToInt32(Console.ReadLine());
                estudiantes[i] = new Estudiante(nombre,apellido,proyecto,tareas,part);
            }

            foreach(Estudiante alumno in estudiantes)
            {
                Console.WriteLine(alumno.Informacion);
            }
            Console.ReadKey();
        }
    }
}
