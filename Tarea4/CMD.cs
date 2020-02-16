using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Linq;

namespace cmd
{
    class Program
    {
        static void Main(string[] args)
        {
            bool program=true;
            Cmd consola = new Cmd();
            string command;
            string[] arrayCommand;
            do
            {
                consola.PrintPath();
                command = Console.ReadLine();
                if (command != "")
                {
                    arrayCommand = consola.FormatCommand(command);
                    switch (arrayCommand[0].ToLower())
                    {
                        case "dir":
                            consola.Dir(arrayCommand);

                            consola.AddHistory("dir");
                            break;
                        case "cd":
                            consola.Cd(arrayCommand);
                            consola.AddHistory("cd");
                            break;
                        case "history":
                            consola.History();
                            consola.AddHistory("history");
                            break;
                        case "touch":
                            consola.Touch(arrayCommand);
                            consola.AddHistory("touch");
                            break;
                        case "move":
                            consola.Move(arrayCommand);
                            consola.AddHistory("move");
                            break;
                        case "cls":
                            Console.Clear();
                            consola.AddHistory("cls");
                            break;
                        case "exit":
                            program = false;
                            break;
                    }
                }
            } while (program);
        }
    }
    class Cmd
    {
        private string path;
        private List<string> history;
        public Cmd()
        {
            path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            history = new List<string>();
        }
        public string Ruta
        {
            get
            {
                return path;
            }
            set
            {
                if (Directory.Exists(value))
                    path = value;
            }
        }
        public void PrintPath()
        {
            Console.Write(Ruta + ">");
        }
        public void History()
        {
            if (history.Count > 0)
            {
                foreach (var com in history)
                    Console.WriteLine(com);
            }
        }
        public string[] FormatCommand(string com)
        {
            string[] arrayCommand;
            com = com.Trim(' ', '\t');
            com = Regex.Replace(com, "[ \t]+", " ");
            arrayCommand = com.Split(" ");
            return arrayCommand;
        }
        public void Dir(string[] command)
        {
            DirectoryInfo content;
            if (command.Length == 1)
            {
                content = new DirectoryInfo(Ruta);
                Console.WriteLine("CARPETAS:");
                foreach (var dir in content.GetDirectories())
                    Console.WriteLine(dir.Name);
                Console.WriteLine("\nARCHIVOS:");
                foreach (var file in content.GetFiles())
                    Console.WriteLine(file.Name);
            }
            else
            {
                string aux = string.Join(" ", command, 1, command.Length - 1);
                Console.WriteLine(Ruta + '\\' + aux);
                if (aux == ".." || Directory.Exists(Ruta + '\\' + aux) || Directory.Exists(aux))
                {
                    try
                    {
                        content = new DirectoryInfo(aux == ".." ? Path.GetDirectoryName(Ruta) : Ruta + '\\' + aux);
                        Console.WriteLine("CARPETAS:");
                        foreach (var dir in content.GetDirectories())
                            Console.WriteLine(dir.Name);
                        Console.WriteLine("\nARCHIVOS:");
                        foreach (var file in content.GetFiles())
                            Console.WriteLine(file.Name);
                    }
                    catch (UnauthorizedAccessException)
                    {
                        Console.WriteLine("Acceso no autorizado.");
                    }
                }
                else
                    Console.WriteLine("El directorio no existe, favor de verificar y vuelva a intentarlo.");

            }

        }
        public void Cd(string[] command)
        {
            if (command[1] == "..")
                Ruta = Path.GetDirectoryName(Ruta);
            else if (Directory.Exists(command[1]))
                Ruta = command[1];
            else
            {
                string aux = string.Join(" ", command, 1, command.Length - 1);
                if (Directory.Exists(Ruta + '\\' + aux))
                {
                    try
                    {
                        DirectoryInfo content;
                        content = new DirectoryInfo(Ruta + '\\' + aux);
                        Directory.GetFiles(Ruta + '\\' + aux).ToList();
                        Directory.GetDirectories(Ruta + '\\' + aux).ToList();
                        path = Ruta + '\\' + aux;
                    }
                    catch (UnauthorizedAccessException)
                    {
                        Console.WriteLine("Acceso no autorizado.");
                    }
                }

                else
                    Console.WriteLine("El directorio no exite.");
            }

        }
        public void AddHistory(string commandEx)
        {
            history.Add(commandEx);
        }
        public void Touch(string[] command)
        {
            FileStream newfile;
            string aux = string.Join(" ", command, 1, command.Length - 1);
            if (Path.GetDirectoryName(aux).Length > 0)
            {
                try
                {
                    newfile = new FileStream(aux, FileMode.Create, FileAccess.Write);
                    newfile.Close();
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("No tiene permiso para crear el archivo en esa ruta");
                }

            }
            else
            {
                newfile = new FileStream(Ruta + '\\' + aux, FileMode.Create, FileAccess.Write);
                newfile.Close();
            }
                
            
        }
        public void Move(string[] command)
        {
            if (command.Length == 3)
            {
                if (Path.GetDirectoryName(command[1]).Length > 0)
                {
                    if ((File.Exists(command[1]) || File.Exists(Ruta + '\\' + command[1])) && (Path.GetDirectoryName(command[2]).Length > 0 || Path.GetDirectoryName(Ruta + '\\' + command[2]).Length > 0))
                    {
                        File.Move(command[1], command[2]);
                    }
                    else
                        Console.WriteLine("La ruta dos no existe");
                }
            }
            else
                Console.WriteLine("Error al mover el archivo");
        }
    }
}
