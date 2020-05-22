using System;
using System.Collections.Generic;
using System.Linq;
using CommandBotFramework.Abstracts;
using CommandBotFramework.Commands;

namespace CommandBotFramework
{
    public class BotManager
    {
        private List<BaseCommand> _registeredCommands = new List<BaseCommand>();
        private string _commandPrefix;
        
        public BotManager(string commandPrefix = "!")
        {
            _commandPrefix = commandPrefix;
            Register(new HelpCommand(this));
        }
        
        public bool Register(List<BaseCommand> commands)
        {
            return false;
        }

        public bool Register(BaseCommand command)
        {
            if (_registeredCommands.Any(rc => rc.ListensTo(command.Name)))
            {
                return false;
            }
            _registeredCommands.Add(command);
            return true;
        }

        public bool IsCommand(string command)
        {
            if (!command.StartsWith(_commandPrefix))
                return false;

            command = command.TrimStart(_commandPrefix.ToCharArray());
            command = command.Split(" ")[0];
            return FindCommandByName(command) != null;
        }

        public string RunCommand(string commandString)
        {
            commandString = commandString.TrimStart(_commandPrefix.ToCharArray());
            var commandList = commandString.Replace("  ", " ").Split(" ").ToList();
            var commandName = commandList[0]; 
            commandList.RemoveAt(0);
            var command = FindCommandByName(commandName);
            if (command == null)
                return null;
            
            var method = command.FindMethod(commandList, out var parameters);
            if (method != null)
            {
                return method.Invoke(command, parameters) as string;
            }

            return null;
        }

        public BaseCommand FindCommandByName(string commandName)
        {
            return _registeredCommands.FirstOrDefault(c => c.ListensTo(commandName));
        }

        public BaseCommand[] GetRegisteredCommands()
        {
            return _registeredCommands.ToArray();
        }
    }
}