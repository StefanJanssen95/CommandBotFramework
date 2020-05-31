using System.Security.Cryptography;
using CommandBotFramework.Calendar;
using Xunit;

namespace CommandBotFramework.Test.BotManager
{
    public class BotManagerTest
    {
        [Fact]
        public void LoadPlugin()
        {
            //Arrange
            var botManager = new CommandBotFramework.BotManager();
            
            //Act
            var pm = new CalendarPluginManager(botManager);

            //Assert
            Assert.True(pm.IsSuccessfullyLoaded);
            Assert.Contains(pm.GetType().FullName, botManager.GetLoadedPlugins());
        }
        
        [Fact]
        public void UnloadPlugin()
        {
            //Arrange
            var botManager = new CommandBotFramework.BotManager();
            var pm = new CalendarPluginManager(botManager);
            
            //Act
            pm.UnloadPlugin();
            
            //Assert
            Assert.False(pm.IsSuccessfullyLoaded);
            Assert.Empty(botManager.GetLoadedPlugins());
        }
    }
}