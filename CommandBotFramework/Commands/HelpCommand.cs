using System.Collections.Generic;
using CommandBotFramework.Abstracts;
using CommandBotFramework.Attributes.Commands;
using CommandBotFramework.Helpers;

namespace CommandBotFramework.Commands
{
    [CommandHelp("Displays available commands")]
    [CommandName("help")]
    public class HelpCommand : BaseCommand
    {
        private BotManager _botManager;

        public HelpCommand(BotManager botManager)
        {
            _botManager = botManager;
        }

        [CommandSignature("")]
        [CommandHelp("Display a list of all commands")]
        public override string Execute()
        {
            var dictionary = new Dictionary<string, string>();
            BaseCommand[] commands = _botManager.GetRegisteredCommands();
            foreach (var command in commands)
            {
                dictionary.Add(command.Name, command.GetBaseHelp());
            }

            return Formatter.FormatTable(dictionary);
        }

        [CommandSignature("{command:string}")]
        [CommandHelp("Display a more detailed about a single command")]
        public string Execute(string commandName)
        {
            BaseCommand command = _botManager.FindCommandByName(commandName);
            return command == null ? $"Could not find a command called {commandName}." : command.Help();
        }
    }
}