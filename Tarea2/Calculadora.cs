using System;
using System.Collections.Generic;
using System.Text;

namespace evaluacion
{
    static class Calculadora
    {
        private static double Tareas(int n)
        {
            double calTarea = (double)n * .8;
            return calTarea;
        }
        public static double Promedio(double proyecto, int n_tareas, int n_participaciones)
        {
            double evaluacion = proyecto*.6 + Calculadora.Tareas(n_tareas);
            if (n_participaciones > 5)
                evaluacion += 0.8;
            if (evaluacion > 10)
                return 10;
            else if (evaluacion < 5)
                return 5;
            else
                return evaluacion;
        }
    }
}
