using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] arguments = args
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string commandName = arguments[0];
            string[] commandArgs = arguments.Skip(1).ToArray();

            Type type = Assembly
                .GetEntryAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == commandName + "Command");

            ICommand commandInstance = Activator.CreateInstance(type) as ICommand;

            return commandInstance.Execute(commandArgs);
        }
    }
}
