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
                if (command[0] == "")
                {
                    continue;
                }

                if (Aliases.ContainsKey(command[0]))
                {
                    command[0] = Aliases[command[0]];
                }

                if (Commands.ContainsKey(command[0]))
                {
                    Commands[command[0]].Method(command);
                }
                else
                {
                    Console.WriteLine("Unknown command. Please, try again or type \"help\" to get full list of commands.");
                }
            }
        }

        public static bool ShouldClose { get; private set; }
        private static CompanyManager Manager { get; set; }
        private static Dictionary<string, string> Aliases = new Dictionary<string, string>();
        private static Dictionary<string, ConsoleCommand> Commands = new Dictionary<string, ConsoleCommand>
        {
            { "exit", new ConsoleCommand(Exit, "Exit the application.") },
            { "alias", new ConsoleCommand(Alias, "Add alias to the command name. --command --alias") },
            { "aliases", new ConsoleCommand(ShowAliases, "Show all alias names and corresponding commands.") },
            { "help", new ConsoleCommand(ShowHelp, "Show all commands and their descriptions.") },
            { "manager", new ConsoleCommand(AddManager, "Add position that can have subordinates. --manager-position-name") },
            { "worker", new ConsoleCommand(AddWorker, "Add position that can`t have subordinates. --worker-position-name") },
            { "set-head", new ConsoleCommand(SetHead, "Set position as a head of a company. --manager-position-name") },
            { "add-head", new ConsoleCommand(AddHead, "Create a manager position and set it as a head of a company or change current head. --manager-position-name") },
            { "change-head", new ConsoleCommand(ChangeHead, "Set given position as a head of a company and set previous head as a subordinate. --manager-position-name") },
            { "list", new ConsoleCommand(ListPositions, "Show company positions` structure in different formats: direct order or height of position. --order-type") },
            { "sub", new ConsoleCommand(Subordinate, "Add subordinate to the manager position. --manager-position --subordiante-position") },
            { "remove", new ConsoleCommand(Remove, "Remove a position from the company structure. --position") }
        };

        // COMMANDS
        private static void Remove(string[] command)
        {
            try
            {
                if (command.Length < 2)
                {
                    throw new Exception("Not enough parameters!");
                }
                Manager.Remove(command[1]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private static void Subordinate(string[] command)
        {
            try
            {
                if (command.Length < 3)
                {
                    throw new Exception("Not enough parameters!");
                }
                Manager.Subordinate(command[1], command[2]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
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
        private static void ChangeHead(string[] command)
        {
            try
            {
                if (command.Length < 2)
                {
                    throw new Exception("Not enough parameters!");
                }
                Manager.ChangeHead(command[1]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private static void AddHead(string[] command)
        {
            try
            {
                if (command.Length < 2)
                {
                    throw new Exception("Not enough parameters!");
                }
                Manager.AddHead(command[1]);
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
                Console.WriteLine(comm + ":      " + Commands[comm].Description);
            }
        }
        private static void Exit(string[] command)
        {
            ShouldClose = true;
        }
    }
}
