using System;
using System.Collections.Generic;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter company name: ");
            Manager = new CompanyManager(new Company(Console.ReadLine()));

            while(!ShouldClose)
            {
                Console.WriteLine();
                string[] command = Console.ReadLine().Split(" ");
                if (Aliases.ContainsKey(command[0]))
                {
                    command[0] = Aliases[command[0]];
                }

                if (Commands.ContainsKey(command[0]))
                {
                    Commands[command[0]](command);
                }
                else
                {
                    Console.WriteLine("Unknown command. Please, try again or type \"help\" to get full list of commands.");
                }
            }
        }

        delegate void Command(string[] command);
        public static bool ShouldClose { get; private set; }
        private static CompanyManager Manager { get; set; }
        private static Dictionary<string, string> Aliases = new Dictionary<string, string>();
        private static Dictionary<string, Command> Commands = new Dictionary<string, Command>
        {
            { "exit", Exit },
            { "alias", Alias },
            { "aliases", ShowAliases },
            { "help", ShowHelp },
            { "manager", AddManager },
            { "worker", AddWorker },
            { "head", SetHead },
            { "list", ListPositions }
        };

        // COMMANDS
        private static void ListPositions(string[] command)
        {
            try
            {
                if (command.Length < 2)
                {
                    throw new Exception("Not enough parameters!");
                }
                Manager.ListPositions(command[1]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private static void SetHead(string[] command)
        {
            try
            {
                if (command.Length < 2)
                {
                    throw new Exception("Not enough parameters!");
                }
                Manager.SetHead(command[1]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private static void AddWorker(string[] command)
        {
            try
            {
                if (command.Length < 2)
                {
                    throw new Exception("Not enough parameters!");
                }
                Manager.AddWorker(command[1]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private static void AddManager(string[] command)
        {
            try
            {
                if (command.Length < 2)
                {
                    throw new Exception("Not enough parameters!");
                }
                Manager.AddManager(command[1]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private static void Alias(string[] command)
        {
            try
            {
                if (command.Length < 3)
                {
                    throw new Exception("Not enough parameters!");
                }
                if (!Commands.ContainsKey(command[1]))
                {
                    throw new Exception("Attempt to set alias to unknown command!");
                }
                if (Aliases.ContainsKey(command[2]))
                {
                    Aliases[command[2]] = command[1];
                }
                else
                {
                    Aliases.Add(command[2], command[1]);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private static void ShowAliases(string[] command)
        {
            if (Aliases.Count > 0)
            {
                Console.WriteLine("List of aliases:");
                foreach (KeyValuePair<string, string> alias in Aliases)
                {
                    Console.WriteLine(alias.Key + " - " + alias.Value);
                }
            }
            else
            {
                Console.WriteLine("Have no aliases.");
            }
        }
        private static void ShowHelp(string[] command)
        {
            Console.WriteLine("List of commands:");
            foreach (string comm in Commands.Keys)
            {
                Console.WriteLine(comm);
            }
        }
        private static void Exit(string[] command)
        {
            ShouldClose = true;
        }
    }
}
