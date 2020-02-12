using System;

namespace Ej6
{
    class Program
    {
        static void Main(string[] args)
        {
            //Se crea el primer objeto con "Saul" como parámetro, se realizará un depósito y dos retiros
            CuentaBancaria MiCuenta1 = new CuentaBancaria("Saul");
            MiCuenta1.Deposito(5000);
            MiCuenta1.Retiro(3000);
            MiCuenta1.Retiro(4000);
            //Se crea el segundo objeto con "Pablo" como parámetro, se realizará un retiro, un depósito y de nuevo un retiro.
            CuentaBancaria MiCuenta2 = new CuentaBancaria("Pablo");
            MiCuenta2.Retiro(200);
            MiCuenta2.Deposito(10000);
            MiCuenta2.Retiro(100);
            //Al primer objeto se desea realizar un depósito
            MiCuenta1.Deposito(30000);
            //Se desea conocer el nombre de ambas cuentas
            Console.WriteLine(MiCuenta1.Nombre);
            Console.WriteLine(MiCuenta2.Nombre);

            Console.ReadKey();
        }
    }
    class CuentaBancaria
    {
        //Se crea el atributo nombre, el cual solo devolverá un valor
        public string Nombre { get; }

        //Se crea una variable que maneje de manera interna el saldo de la cuenta
        private long dinero = 0;
        //Se crea un atributo Saldo, el cual sólo devolverá el saldo actual de  la cuenta
        public long Saldo
        {
            get { return dinero; }
        }
        //El método MostrarInformación imprimrá en pantalla detalles de la cuenta (nombre, y saldo actual).
        public void MostrarInformacion()
        {
            Console.WriteLine("Nombre cuenta: " + Nombre + "\tSaldo actual: $" + Saldo);
        }
        //El método Depósito sumará a dinero lo que el usuario haya depositado, Se dará detalle de la cuenta
        public void Deposito(long ingreso)
        {
            dinero += ingreso;
            Console.WriteLine("{0} ha agregado ${1} a su cuenta. Movimiento exitoso.", Nombre, ingreso);
            MostrarInformacion();
        }
        //El método Retiro hará una substracción a dinero, si la cantidad que se requeire restar es menor a saldo, mostrará que la operación no se peude realizar
        //Caso contrario, hará la resta y mostrará información
        public void Retiro(long retiro)
        {
            if (dinero >= retiro)
            {
                dinero -= retiro;
                Console.WriteLine("{0} ha retirado de su cuenta ${1}.", Nombre, retiro);
            }
            else
                Console.WriteLine("{0} no cuenta con fondos suficientes para realizar este movimiento.", Nombre);
            MostrarInformacion();
        } 

        //El constructor dará inforamción de la cuenta. Cada  cuenta nueva se inicaliza con un saldo de $0.
        public CuentaBancaria(string nombre)
        {
            Nombre = nombre;
            MostrarInformacion();
        }
    }
}
