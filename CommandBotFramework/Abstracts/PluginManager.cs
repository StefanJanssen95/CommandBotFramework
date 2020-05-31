using System.Collections.Generic;

namespace CommandBotFramework.Abstracts
{
    public abstract class PluginManager
    {
        public string PluginName => GetType().FullName;
        protected BotManager _botManager;
        protected List<BaseCommand> _commands = new List<BaseCommand>();
        
        public bool IsSuccessfullyLoaded { get; private set; }

        protected PluginManager(BotManager botManager)
        {
            _botManager = botManager;
            LoadPlugin();
        }

        public BaseCommand[] GetCommands()
        {
            return _commands.ToArray();
        }

        public bool LoadPlugin()
        {
            IsSuccessfullyLoaded = _botManager.LoadPlugin(this);
            return IsSuccessfullyLoaded;
        }
        

        public void UnloadPlugin()
        {
            IsSuccessfullyLoaded = !_botManager.UnloadPlugin(this);
        }
        
    }
}