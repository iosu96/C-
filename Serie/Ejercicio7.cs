using System;
using System.Collections.Generic;
using System.Text;

namespace Ej7
{
    class Program
    {
        static void Main(string[] args)
        {
            //Se crean dos nuevos números complejos
            NumeroComplejo complejoA = new NumeroComplejo(7,5);
            NumeroComplejo complejoB = new NumeroComplejo(3, 8);
            //Se imprime el formato de núero complejo para A y B
            complejoA.Imprimir();
            complejoB.Imprimir();
            //Se suma A y B
            complejoA.SumaComplejo(complejoB);
            //Se imprime el nuevo valor de A
            complejoA.Imprimir();
            Console.ReadKey();
        }
    }
    
    class NumeroComplejo
    {
        //Se crean los atributos real e imaginario, el cual compone un número complejo
        public double ParteReal { get; set; }
        public double ParteImaginaria { get; set; }
        //El metodo imprimir, mostrará en pantalla el formato de un número complejo, compuesto por su parte real y su parte imaginaria
        public void Imprimir()
        {
            Console.WriteLine("{0} {1} {2}i",ParteReal,ParteImaginaria>0?"+":"-",ParteImaginaria);
        }
        //El método sumacomplejo recibirá un objeto tipo NumeroComplejo, el cual hará adición a la parte real y parte imaginara (A + B).
        public void SumaComplejo(NumeroComplejo b)
        {
            ParteReal += b.ParteReal;
            ParteImaginaria += b.ParteImaginaria;
        }
        //El constructor recibirá dos valores
        public NumeroComplejo(double real,double imaginario)
        {
            ParteReal = real;
            ParteImaginaria = imaginario;
        }
    }
}
