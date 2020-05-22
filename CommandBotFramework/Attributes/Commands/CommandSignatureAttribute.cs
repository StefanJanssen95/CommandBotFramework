using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using CommandBotFramework.Enums;

namespace CommandBotFramework.Attributes.Commands
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CommandSignatureAttribute : Attribute
    {
        public List<KeyValuePair<string, ParameterType>> Parameters { get; } = new List<KeyValuePair<string, ParameterType>>();
        public string Signature { get; private set; }

        // Format: {name:type} {name:type}
        public CommandSignatureAttribute(string signature)
        {
            if (string.IsNullOrWhiteSpace(signature))
            {
                Signature = "";
                return;
            }

            var regex = new Regex("{([a-zA-Z0-9]+)(?::(number|string|bool))?} ?");
            if (!regex.IsMatch(signature))
            {
                throw new FormatException($"{signature} does not match {regex}");
            }

            var matchCollection = regex.Matches(signature);
            foreach (Match match in matchCollection)
            {
                var groupValues = match.Groups.Values.Select(b => b.Value).ToList();
                var paramName = groupValues[1];
                var paramType = ParameterType.Unknown;
                if (groupValues.Count >= 2 && !string.IsNullOrWhiteSpace(groupValues[2]))
                {
                    switch (groupValues[2])
                    {
                        case "number":
                            paramType = ParameterType.Number;
                            break;
                        case "string":
                            paramType = ParameterType.String;
                            break;
                        case "bool":
                            paramType = ParameterType.Bool;
                            break;
                        default: throw new FormatException($"Not supported type {groupValues[2]}");
                    }
                }

                Parameters.Add(new KeyValuePair<string, ParameterType>(paramName, paramType));
            }

            Signature = signature;
        }
    }
}