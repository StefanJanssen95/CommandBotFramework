using System;

namespace CommandBotFramework.Attributes.Commands
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method)]
    public class CommandHelpAttribute : Attribute
    {
        public string HelpText { get; private set; }
        public CommandHelpAttribute(string helpText)
        {
            HelpText = helpText;
        }
    }
}