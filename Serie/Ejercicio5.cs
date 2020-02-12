using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Ej5
{
    class Program
    {
        static void Main(string[] args)
        {
            //Se crea un nuevo objeto agenda, el cual tendrá los métodos de agregar, eliminar y mostrar contactos
            Agenda MiAgenda = new Agenda();
            //Banderas que sirven para el control de los bucles Do-While
            bool flag = true,validate = true;
            //Variable para almacenar la opcion que el usuario quiere.
            int opcion = 0;
            //variables para alamacenar los datos agregados por el usuario
            string nombre, telefono;
            Console.WriteLine("Bienvenido a su agenda.");
            do
            {
                Console.Clear();
                //Presenta al usuario el menu y valida el tipo de dato que ingresa el usaurio
                try
                {
                    Console.WriteLine("\nElija que desea hacer \n\n1. Agregar Contacto.\n2. Eliminar Contacto.\n3. Mostrar Contacto. \n4. Salir.\n");
                    opcion = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    //Si el tipo de dato no es entero,  le mandará error al usuario
                    Console.WriteLine("El programa solo permite dígito de 1 a 4. Verifique y vuelva a intentarlo.");
                    Console.ReadKey();
                }
                //El switch sirve para poder realizar el tipo de movimiento que requeire el usuario en el sistema
                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        //Pedirá al usuario que ingrese un nombre
                        Console.Write("Agregando contacto.\nEscriba el nombre del contacto: ");
                        nombre = Console.ReadLine();
                        //El ciclo do-while permite evaluar que el usuario ingrese dígitos del 0 al 9, al menos 6 dígitos
                        do
                        {
                            Console.Write("Escriba el número del contacto: ");
                            telefono = Console.ReadLine();
                            //Si lo que ingresó el usuario cumple con la expresion regular se saldrá del bucle
                            if (Regex.IsMatch(telefono, "[0-9]+") && telefono.Length > 5)
                            {
                                //Del objeto MiAgenda, invocará el método agregar persona, y le pasará los valores que el usuario ingresó, un nombre y un teléfono
                                MiAgenda.AddPerson(nombre,telefono);
                                validate = false;
                            }
                            //caso contrario, seguirá en el bucle hasta que el usuario ingrese un tipo de dato correcto
                            else
                                Console.WriteLine("Favor de verificar el numero.");
                        } while (validate);
                        break;
                    case 2:
                        Console.Clear();
                        //Le pedirá al usuario el nombre del contacto que desea eliminar
                        Console.Write("Eliminando contacto.\nEscriba el nombre del contacto que desea eliminar: ");
                        nombre = Console.ReadLine();
                        //El dato será colocado en el método eliminar persona de MiAgenda
                        MiAgenda.DeletePerson(nombre);
                        break;
                    case 3:
                        Console.Clear();
                        //Invocará el método Mostrar contactos
                        MiAgenda.ShowPerson();
                        break;
                    case 4:
                        //Con esta opción el usuario podrá finalziar el programa
                        Console.WriteLine("Vuelva pronto.");
                        flag = false;
                        break;
                    default:
                        //Si la opción del usuario no corresponde entre el numer 1 y 4, se le mostrará el siguiente mensaje
                        Console.WriteLine("Opción incorrecta");
                        Console.ReadKey();
                        break;
                     
                }
            } while (flag);
            Console.ReadKey();
        }
    }
    //se crea la clase Agenda, el cual hará los movimientos de agregar, eliminar y mostrar contactos
    class Agenda
    {
        //Se declara un nuevo objeto tipo diccioanrio
        Dictionary<string,string> agenda = new Dictionary<string, string>();
        //El método agregar persona, agregará al diccionario un nuevo elemento, su lalve será el nombre del contacto, y el valor será el número telefónico
        public void AddPerson(string alias, string telefono)
        {
            //Si el contaco ya existe en el diccionario, se pregunta si se desea modificar su valor
            if (agenda.ContainsKey(alias))
            {
                Console.WriteLine("El contacto existe, ¿Desea modificarlo?\n1.Si\n2.No");
                string modify = Console.ReadLine();
                //Primero se valida que el dato que ingresó el usuario sea un 1 o un 2
                if (Regex.IsMatch(modify, "[12]{1}"))
                {
                    //Si modify toma el valor de 1, se actualziará el valor del elemento correspondiente en la agenda
                    if (modify == "1")
                        agenda[alias] = telefono;
                }
                //Caso contrario le indicará al usuario que la opción es incorrecta
                else
                    Console.WriteLine("Error al introducir opcion.");
            }
            else
            {
                //Si el contacto que se desea agregar no existe en el diccionario, se agregará a este
                agenda.Add(alias, telefono);
                Console.WriteLine("El contacto con nombre {0} y número {1} se ha agregado correctamente.", alias, telefono);
            }
            Console.ReadKey();
        }
        //El método DeletePerson buscará y eliminará un elemento del diccionario
        public void DeletePerson(string alias)
        {
            int delete = 0;
            //Se valida que el contacto que se desea eliminar exista en el diccionario
            if (agenda.ContainsKey(alias))
            {
                Console.WriteLine("Seguro desea eliminar el contacto?\n1.Si\n2.No");
                //Se valida la opción del usuario, si es numérico.
                try
                {
                    delete = Convert.ToInt32(Console.ReadLine());
                }
                //Caso contrario le mandará error al usuario
                catch
                {
                    Console.WriteLine("Error al ingresar oción, intente de nuevo");
                }
                //Si la opcion no es 1 o 2 le lanzará el mensaje de opcion no valida al usuario.
                if (delete > 2 || delete < 1)
                    Console.WriteLine("Opción no valida");
                //Si la opción es 1, se eliminará ese elemento del diccionario
                else if (delete == 1)
                {
                    agenda.Remove(alias);
                    Console.WriteLine("Contacto borrado");
                }
            }
            //Si la lalve no existe en el diccionario se mencioanra que el contacto no existe
            else
                Console.WriteLine("El contacto no existe.");
            Console.ReadKey();
        }
        public void ShowPerson()
        {
            //Verifica que el número de elementos del diccioanrio sea mayor a 0
            if (agenda.Count > 0)
            {
                //Si es mayor a 0, se imprimirá en pantalla cad elemento del diccionario
                foreach (KeyValuePair<string, string> dic in agenda)
                    Console.WriteLine("Contacto: {0}\tNúmero: {1}", dic.Key, dic.Value);
            }
            //Si tiene 0 elementos se madnará el siguiente mensaje
            else
                Console.WriteLine("No se tiene registrado ningun contacto.");
            Console.ReadKey();
        }
    }
}
