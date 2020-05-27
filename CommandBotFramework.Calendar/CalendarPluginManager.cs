using System;
using System.Collections.Generic;
using CommandBotFramework.Abstracts;
using CommandBotFramework.Calendar.Commands;

namespace CommandBotFramework.Calendar
{
    public class CalendarPluginManager : PluginManager
    {
        public CalendarPluginManager(BotManager botManager)
        {
            _commands.Add(new DateTimeCommand());
            _botManager = botManager;
        }
        
        public override bool Load()
        {
            var success = true;
            foreach (var command in _commands)
            {
                if (!_botManager.Register(command))
                {
                    success = false;
                    Unload();
                    break;
                }
            }

            return success;
        }

        public override void Unload()
        {
            foreach (var command in _commands)
            {
                _botManager.Unregister(command);
            }
        }
    }
}