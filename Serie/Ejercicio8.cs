using System;

namespace Ej8
{
    class Program
    {
        static void Main(string[] args)
        {
            Auto modelo1 = new Auto();
            Auto modelo2 = new Auto("Rojo", 720,270,1.90,"estandar");
            modelo1.AumentarVelocidad();
            modelo1.Retroceder();
            modelo1.Encender();
            modelo1.AumentarVelocidad();
            modelo1.AumentarVelocidad();
            modelo1.AumentarVelocidad();
            modelo1.DisminuirVelodidad();
            modelo1.DisminuirVelodidad();
            modelo1.DisminuirVelodidad();
            modelo1.DisminuirVelodidad();
            modelo1.Retroceder();
            modelo1.Retroceder();
        }
    }
    
    class Auto
    {
        bool status;
        int vel = 0;
        public string Color { get; set; }
        public int Potencia { get; set; }
        public int Velocidad { get; set; }
        public double Tamanio { get; set; }
        public string Transmision { get; set; }
        public Auto()
        {
            Color = "blanco";
            Transmision = "automatico";
            Potencia = 90;
            Velocidad = 120;
            Tamanio = 1.80;
        }
        public Auto(string color, int hp, int vel, double dim, string tipo)
        {
            Color = color;
            Potencia = hp;
            Velocidad = vel;
            Tamanio = dim;
            Transmision = tipo;
        }
        public void Encender()
        {
            if (status == false)
            {
                Console.WriteLine("El carro se ha encendido");
                status = true;
            }
            else
                Console.WriteLine("El carro ya está encendido");
        }

        public void Apagar()
        {
            if (status == true)
            {
                Console.WriteLine("El carro se ha apagado");
                status = false;
            }
            else
                Console.WriteLine("El carro ya está apagado");
        }
        public void AumentarVelocidad()
        {
            if (status == true)
            {
                if (vel < 5)
                {
                    vel++;
                    Console.WriteLine("El carro está en la velocidad {0}",vel);
                }
                else
                    Console.WriteLine("El carro ya está en la quinta velocidad.");
            }
            else
                Console.WriteLine("El carro no puede avanzar por que no está encedido.");
        }
        public void DisminuirVelodidad()
        {
            if (status == true)
            {
                if (vel > 0)
                {
                    vel--;
                    Console.WriteLine("El carro está en la velocidad {0}", vel);
                }
                else
                    Console.WriteLine("El carro está en neutro. No se puede disminuir");
            }
            else
                Console.WriteLine("El carro no puede disminuir velocidad por que no está encedido.");
        }
        public void Retroceder()
        {
            if(status == true)
            {
                if (vel == 0 || vel! < -1)
                {
                    vel--;
                    Console.WriteLine("El carro está en reversa.");
                }
                else
                    Console.WriteLine("No se puede poner en reversa porque el carro no está en neutro o ya se encuentra en reversa.");
            }
            else
                Console.WriteLine("El carro no puede retroceder por que no está encedido.");
        }
    }
}
