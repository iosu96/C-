using System;
using System.Collections.Generic;
using System.Text;

namespace evaluacion
{
    abstract class Persona
    {
        protected string Nombre { get; set; }
        protected string Apellido { get; set; }
        public Persona(string nombre, string apellido)
        {
            Nombre = nombre;
            Apellido = apellido;
        }
        public abstract string Informacion {
            get;
        }
    }
}
