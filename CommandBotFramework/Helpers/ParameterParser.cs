using System;
using CommandBotFramework.Enums;

namespace CommandBotFramework.Helpers
{
    public class ParameterParser
    {
        static object ParseParameter(ParameterType type, string value)
        {
            switch (type)
            {
                case ParameterType.String: return value;
                case ParameterType.Unknown: return value;
                case ParameterType.Number:
                {
                    return value.Contains(".") ? Decimal.Parse(value) : int.Parse(value);
                }
                case ParameterType.Bool:
                {
                    var val = value.ToLower();
                    if (val == "1" || val == "y" || val == "true" || val == "yes") return true;
                    if (val == "0" || val == "n" || val == "false" || val == "no") return false;
                    throw new FormatException($"Could not recognize {value} as boolean");
                }
                default:
                {
                    throw new NotImplementedException($"No parser implemented for {type.ToString()}");
                }
            }
        }

        public static bool TryParseParameter(ParameterType type, string value, out object newValue)
        {
            try
            {
                newValue = ParseParameter(type, value);
                return true;
            }
            catch
            {
                newValue = null;
                return false;
            }
        }
    }
}