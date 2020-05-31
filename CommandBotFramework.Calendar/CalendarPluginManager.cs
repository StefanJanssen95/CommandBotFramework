using System;
using System.Collections.Generic;
using CommandBotFramework.Abstracts;
using CommandBotFramework.Calendar.Commands;

namespace CommandBotFramework.Calendar
{
    public class CalendarPluginManager : PluginManager
    {
        public CalendarPluginManager(BotManager botManager) : base(botManager)
        {
            _commands.Add(new DateTimeCommand());
        }
    }
}