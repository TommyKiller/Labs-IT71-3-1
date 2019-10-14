using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    public class ConsoleCommand
    {
        public ConsoleCommand(Command command, string description)
        {
            Method = command;
            Description = description;
        }

        public delegate void Command(string[] command);
        public Command Method { get; private set; }
        public string Description { get; private set; }
    }
}
