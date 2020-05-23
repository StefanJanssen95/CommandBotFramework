using System;
using System.Globalization;
using CommandBotFramework.Abstracts;
using CommandBotFramework.Attributes.Commands;

namespace CommandBotFramework.Calendar.Commands
{
    [CommandHelp("Show the date in the Netherlands")]
    [CommandName("DateTime")]
    public class DateTimeCommand : BaseCommand
    {
        [CommandHelp("Show the full datetime in English")]
        [CommandSignature("")]
        public override string Execute()
        {
            return DateTime.Now.ToString("d MMM hh:mm tt",CultureInfo.CreateSpecificCulture("en-US"));
        }
        
        [CommandHelp("Get the time in either a 12 or 24 hour format")]
        [CommandSignature("{hourFormat:number}")]
        public string Execute(int hourFormat)
        {
            return DateTime.Now.ToString(hourFormat == 12 ? "hh:mm tt" : "HH:mm", CultureInfo.InvariantCulture);
        }
    }
}