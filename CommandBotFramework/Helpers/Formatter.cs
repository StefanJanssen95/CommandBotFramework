using System;
using System.Collections.Generic;
using System.Linq;

namespace CommandBotFramework.Helpers
{
    public static class Formatter
    {
        public static string FormatTable(Dictionary<string, string> dictionary, int spacing = 4)
        {
            var longestKey = dictionary.Select(kvp => kvp.Key).Max(k => k.Length);
            var help = "";
            foreach (var kvp in dictionary)
            {
                var spaces = new string(' ', (longestKey - kvp.Key.Length) + spacing);
                help += $"{kvp.Key}{spaces}{kvp.Value}";
                help += Environment.NewLine;
            }

            return help;
        }
    }
}