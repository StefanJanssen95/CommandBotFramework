using System.Collections.Generic;

namespace CommandBotFramework.Abstracts
{
    public abstract class PluginManager
    {
        protected BotManager _botManager;
        protected List<BaseCommand> _commands = new List<BaseCommand>();
        public abstract bool Load();
        public abstract void Unload();
    }
}