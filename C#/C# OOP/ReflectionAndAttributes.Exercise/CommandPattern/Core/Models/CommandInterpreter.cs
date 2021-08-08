using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Core.Models
{
    public class CommandInterpreter : ICommandInterpreter
    {

        public CommandInterpreter()
        {
        }

        public string Read(string args)
        {
            string[] arguments = args.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string commandName = arguments[0];
            arguments = arguments.Skip(1).ToArray();

            Type type = GetTheTypeIfExists(commandName);

            ICommand command = (ICommand)Activator.CreateInstance(type);

            if (command == null)
            {
                throw new ArgumentException("Non existent command type!");
            }

            string result = command.Execute(arguments);

            return result;
        }

        private static Type GetTheTypeIfExists(string commandName)
        {
            Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == $"{commandName}Command");
            return type;
        }
    }
}
