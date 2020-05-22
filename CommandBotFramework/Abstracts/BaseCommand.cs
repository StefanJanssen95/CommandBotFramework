using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using CommandBotFramework.Attributes.Commands;
using CommandBotFramework.Enums;
using CommandBotFramework.Helpers;

namespace CommandBotFramework.Abstracts
{
    public abstract class BaseCommand
    {
        public string Name { get; private set; }
        private string _checkName;
        protected BaseCommand()
        {
            MemberInfo info = GetType();
            var attr = (CommandNameAttribute)info.GetCustomAttribute(typeof(CommandNameAttribute), true);
            if (attr != null)
            {
                Name = attr.Name;
                _checkName = attr.CheckName;
            }
        }
        
        public string GetBaseHelp()
        {
            var help = "";
            MemberInfo info = GetType();
            var attr = (CommandHelpAttribute)info.GetCustomAttribute(typeof(CommandHelpAttribute), true);
            if (attr != null)
            {
                help += attr.HelpText;
                help += Environment.NewLine;
            }

            return help;
        }

        private string GetMethodHelp()
        {
            
            var dictionary = new Dictionary<string, string>();
            var methods = GetType().GetMethods();
            foreach (var method in methods)
            {
                var helpAttribute = (CommandHelpAttribute) method.GetCustomAttribute(typeof(CommandHelpAttribute));
                var signatureAttribute = (CommandSignatureAttribute) method.GetCustomAttribute(typeof(CommandSignatureAttribute), true);
                if (signatureAttribute != null && helpAttribute != null)
                {
                    dictionary.Add($"{Name} {signatureAttribute.Signature}", helpAttribute.HelpText);
                }
            }

            return Formatter.FormatTable(dictionary);
        }
        
        public string Help()
        {
            var help = "";

            help += GetBaseHelp();
            help += GetMethodHelp();
            
            return help;
        }

        public abstract string Execute();

        public bool ListensTo(string commandName)
        {
            return commandName.ToLower() == _checkName;
        }

        public MethodInfo FindMethod(List<string> parameters, out object[] parsedParameters)
        {
            var parsedParameterList = new List<object>();
            var methods = GetType().GetMethods().Where(m => m.Name.ToLower().StartsWith("execute"));
            foreach (var method in methods)
            {
                var signatureAttribute = (CommandSignatureAttribute) method.GetCustomAttribute(typeof(CommandSignatureAttribute), true);
                if (signatureAttribute != null)
                {
                    if (signatureAttribute.Parameters.Count != parameters.Count)
                        continue;

                    var valid = true;
                    for (var i = 0; i < signatureAttribute.Parameters.Count; i++)
                    {
                        var paramDefinition = signatureAttribute.Parameters[i];
                        if (ParameterParser.TryParseParameter(paramDefinition.Value, parameters[i], out var newValue))
                        {
                            parsedParameterList.Add(newValue);
                        }
                        else
                        {
                            valid = false;
                            break;
                        }
                    }

                    if (!valid)
                        break;

                    parsedParameters = parsedParameterList.ToArray();
                    return method;
                }
            }

            parsedParameters = new object[0];
            return null;
        }
    }
}