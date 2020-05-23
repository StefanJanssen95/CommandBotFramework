using System;
using CommandBotFramework.Calendar;

namespace CommandBotFramework.ManualTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var stop = false;
            var botManager = new BotManager();
            var cpm = new CalendarPluginManager(botManager);
            botManager.Load(cpm);
            
            while (!stop)
            {
                var chatLine = Console.ReadLine();

                if (botManager.IsCommand(chatLine))
                {
                    Console.WriteLine(botManager.RunCommand(chatLine));
                }

                if (chatLine == "q" || chatLine == "quit" || chatLine == "exit")
                {
                    Console.WriteLine("Shutting down manual test");
                    stop = true;
                }
            }
        }
    }
}