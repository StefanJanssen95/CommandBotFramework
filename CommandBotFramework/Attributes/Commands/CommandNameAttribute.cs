using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using CommandBotFramework.Enums;

namespace CommandBotFramework.Attributes.Commands
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CommandNameAttribute : Attribute
    {
        public string Name { get; private set; }
        public string CheckName { get; private set; }
        
        public CommandNameAttribute(string name)
        {
            var regex = new Regex("^[a-zA-Z]+$");
            if (regex.IsMatch(name))
            {
                Name = name;
                CheckName = name.ToLower();
            }
            else
            {
                throw new FormatException($"The name of an command can only contain letters. Invalid: {name}");
            }

        }
    }
}