using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool ok = false;
            while(!ok)
            {
                Console.Write("Enter company name: ");
                string company_name = Console.ReadLine();
                Regex company_name_pattern = new Regex("^[A-Za-z][-A-Za-z ,.\"\"]*$");
                if (company_name_pattern.IsMatch(company_name))
                {
                    Manager = new CompanyManager(new Company(company_name));
                    ok = true;
                }
                else
                {
                    Console.WriteLine("Wrong company name format!");
                }
            }

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
                    try
                    {
                        Commands[command[0]].Method(command);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
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
            { "list", new ConsoleCommand(ListPositions, "Show company positions` structure in different formats: direct order or height of position. --order-type") },
            { "manager", new ConsoleCommand(AddManager, "Create a new manager and subs it to another one.") },
            { "worker", new ConsoleCommand(AddWorker, "Creates new worker and subs it to a manager.") },
            { "nhead", new ConsoleCommand(NewHead, "Set new manager as a head.") },
            { "chead", new ConsoleCommand(ChangeHead, "Set new manager as a head.") },
            { "remove", new ConsoleCommand(Remove, "Removes the position.") },
            { "hire", new ConsoleCommand(Hire, "Hire new employee.") },
            { "fire", new ConsoleCommand(Fire, "Fire the empoyee. --id") },
            { "appoint", new ConsoleCommand(Appoint, "Appoint an employee to a new position. --id --position") },
            { "get", new ConsoleCommand(Get, "Get employee by name. --name") },
            { "filter", new ConsoleCommand(Get, "Filter employees by criterion. --criterion") }
        };

        private static void Get(string[] command)
        {
            CheckParamsCount(command, 2);

            Manager.Get(command[1]);
        }
        private static void Appoint(string[] command)
        {
            CheckParamsCount(command, 3);

            Manager.Appoint(command[1], command[2]);
        }
        private static void Fire(string[] command)
        {
            CheckParamsCount(command, 2);

            Manager.Fire(command[1]);
        }
        private static void Hire(string[] command)
        {
            CheckParamsCount(command, 1);

            Manager.Hire();
        }
        private static void Remove(string[] command)
        {
            CheckParamsCount(command, 2);

            Manager.Remove(command[1]);
        }
        private static void ChangeHead(string[] command)
        {
            CheckParamsCount(command, 2);

            Manager.ChangeHead(command[1]);
        }
        private static void NewHead(string[] command)
        {
            CheckParamsCount(command, 2);

            Manager.NewHead(command[1]);
        }
        private static void AddWorker(string[] command)
        {
            CheckParamsCount(command, 3);

            Manager.AddWorker(command[1], command[2]);
        }
        private static void AddManager(string[] command)
        {
            CheckParamsCount(command, 3);

            Manager.AddManager(command[1], command[2]);
        }
        // COMMANDS
        private static void ListPositions(string[] command)
        {
            CheckParamsCount(command, 2);

            Manager.ListPositions(command[1]);
        }
        // Service
        private static void Alias(string[] command)
        {
            CheckParamsCount(command, 3);

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

        private static void CheckParamsCount(string[] command, int param_count)
        {
            if (command.Length < param_count)
            {
                throw new Exception("Not enough parameters!");
            }
        }
    }
}
