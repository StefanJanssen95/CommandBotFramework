using System;
using Xunit;

namespace CommandBotFramework.Test.Attributes.Commands.CommandName
{
    public class CommandName
    {
        [Fact]
        public void RunValidName()
        {
            var name = "thisIsAValidName";
            var nameAttr = new CommandBotFramework.Attributes.Commands.CommandNameAttribute(name);
            Assert.Equal(name, nameAttr.Name);
            Assert.Equal(name.ToLower(), nameAttr.CheckName);
        }
        
        [Fact]
        public void RunInValidName()
        {
            var name = "thisIsAnInvalidName123";
            Assert.Throws<FormatException>(() => new CommandBotFramework.Attributes.Commands.CommandNameAttribute(name));
        }
    }
}