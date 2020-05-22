using System;

namespace CommandBotFramework.ManualTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var stop = false;
            var botManager = new BotManager();;
            
            while (!stop)
            {
                var chatLine = Console.ReadLine();

                if (botManager.IsCommand(chatLine))
                {
                    Console.WriteLine(botManager.RunCommand(chatLine));
                }
                
                if (chatLine == "!q")
                    stop = true;
            }
        }
    }
}