using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CommandBotFramework.Abstracts;
using CommandBotFramework.Commands;

namespace CommandBotFramework
{
    public class BotManager
    {
        private readonly List<string> _loadedPlugins = new List<string>();
        private readonly List<BaseCommand> _registeredCommands = new List<BaseCommand>();
        private readonly string _commandPrefix;
        
        public BotManager(string commandPrefix = "!")
        {
            _commandPrefix = commandPrefix;
            RegisterCommand(new HelpCommand(this));
        }
        
        public bool LoadPlugin<T>(T pm) where T: PluginManager
        {
            var success = true;
            var name = pm.PluginName;
            // LOG: Start loading "name"
            if (_loadedPlugins.Contains(name))
            {
                // LOG: "name" has already been loaded
            }
            else
            {
                var pluginCommands = pm.GetCommands();
                
                // Make sure all commands are valid
                foreach (var command in pluginCommands)
                {
                    if (_registeredCommands.Any(rc => rc.ListensTo(command.Name)))
                    {
                        success = false;
                        // LOG: Duplicate command name "command.Name"
                    }
                }

                if (success)
                {
                    // Register all commands
                    foreach (var command in pluginCommands)
                    {
                        if (!RegisterCommand(command))
                        {
                            // This should never happen
                            throw new Exception($"Validated command '{command.Name}' is not valid anymore");
                        }
                    }
                }
            }

            if (success)
            {
                _loadedPlugins.Add(name);
                // LOG: succesfully loaded "name"
            }
            // else
            // LOG: Failed loading/ loaded "name"

            return success;
        }

        public bool UnloadPlugin<T>(T pm) where T : PluginManager
        {
            foreach (var command in pm.GetCommands())
            {
                UnregisterCommmand(command);
            }
            
            var name = pm.PluginName;
            _loadedPlugins.Remove(name);
            return true;
        }

        public bool RegisterCommand(BaseCommand command)
        {
            // LOG: Trying to register "command.Name"
            if (_registeredCommands.Any(rc => rc.ListensTo(command.Name)))
            {
                // LOG: Failed registering "command.Name"
                return false;
            }
            _registeredCommands.Add(command);
            // LOG: Succesfully loaded "command.Name"
            return true;
        }
        
        public void UnregisterCommmand(BaseCommand command)
        {
            _registeredCommands.Remove(command);
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

        public string[] GetLoadedPlugins()
        {
            return _loadedPlugins.ToArray();
        }
    }
}