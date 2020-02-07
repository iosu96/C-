using System;
using System.Collections.Generic;
using System.Text;

namespace evaluacion
{
    class Estudiante : Persona
    {
        double cproyecto;
        int ntarera;
        int npart;
        public Estudiante(string nombre, string apellido, double proyecto, int tarea, int participacion) : base(nombre, apellido)
        {
            cproyecto = proyecto;
            ntarera = tarea;
            npart = participacion;
        }

        public double Promedio
        {
            get { return Calculadora.Promedio(cproyecto,ntarera,npart); }
        }
        public override string Informacion
        {
            get { return String.Format("El alumno {0} {1} obtuvo un promedio de: {2}", Nombre, Apellido, Promedio); }
        }
    }
}
