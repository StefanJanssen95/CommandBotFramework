using System;
using CommandBotFramework.Enums;
using Xunit;

namespace CommandBotFramework.Test.Helpers.ParameterParser
{
    public class ParseBooleans
    {
        // True
        [Fact]
        public void RunValidTrueLowercase()
        {
            var input = "true";
            var success = CommandBotFramework.Helpers.ParameterParser.TryParseParameter(ParameterType.Bool, input, out var output);
            Assert.True(success);
            Assert.IsType<bool>(output);
            Assert.True((bool)output);
        }
        
        [Fact]
        public void RunValidTrueUppercase()
        {
            var input = "TRUE";
            var success = CommandBotFramework.Helpers.ParameterParser.TryParseParameter(ParameterType.Bool, input, out var output);
            Assert.True(success);
            Assert.IsType<bool>(output);
            Assert.True((bool)output);
        }
        
        [Fact]
        public void RunValidTruePartialUppercase()
        {
            var input = "TruE";
            var success = CommandBotFramework.Helpers.ParameterParser.TryParseParameter(ParameterType.Bool, input, out var output);
            Assert.True(success);
            Assert.IsType<bool>(output);
            Assert.True((bool)output);
        }
        
        [Fact]
        public void RunValidYesLowercase()
        {
            var input = "yes";
            var success = CommandBotFramework.Helpers.ParameterParser.TryParseParameter(ParameterType.Bool, input, out var output);
            Assert.True(success);
            Assert.IsType<bool>(output);
            Assert.True((bool)output);
        }
        
        [Fact]
        public void RunValidYesUppercase()
        {
            var input = "Yes";
            var success = CommandBotFramework.Helpers.ParameterParser.TryParseParameter(ParameterType.Bool, input, out var output);
            Assert.True(success);
            Assert.IsType<bool>(output);
            Assert.True((bool)output);
        }
        
        [Fact]
        public void RunValidYUppercase()
        {
            var input = "Y";
            var success = CommandBotFramework.Helpers.ParameterParser.TryParseParameter(ParameterType.Bool, input, out var output);
            Assert.True(success);
            Assert.IsType<bool>(output);
            Assert.True((bool)output);
        }
        
        [Fact]
        public void RunValid1()
        {
            var input = "1";
            var success = CommandBotFramework.Helpers.ParameterParser.TryParseParameter(ParameterType.Bool, input, out var output);
            Assert.True(success);
            Assert.IsType<bool>(output);
            Assert.True((bool)output);
        }
        
        //False
        [Fact]
        public void RunValidFalseLowercase()
        {
            var input = "false";
            var success = CommandBotFramework.Helpers.ParameterParser.TryParseParameter(ParameterType.Bool, input, out var output);
            Assert.True(success);
            Assert.IsType<bool>(output);
            Assert.False((bool)output);
        }
        
        [Fact]
        public void RunValidFalseUppercase()
        {
            var input = "FALSE";
            var success = CommandBotFramework.Helpers.ParameterParser.TryParseParameter(ParameterType.Bool, input, out var output);
            Assert.True(success);
            Assert.IsType<bool>(output);
            Assert.False((bool)output);
        }
        
        [Fact]
        public void RunValidFalsePartialUppercase()
        {
            var input = "fAlSe";
            var success = CommandBotFramework.Helpers.ParameterParser.TryParseParameter(ParameterType.Bool, input, out var output);
            Assert.True(success);
            Assert.IsType<bool>(output);
            Assert.False((bool)output);
        }
        
        [Fact]
        public void RunValidNoLowercase()
        {
            var input = "no";
            var success = CommandBotFramework.Helpers.ParameterParser.TryParseParameter(ParameterType.Bool, input, out var output);
            Assert.True(success);
            Assert.IsType<bool>(output);
            Assert.False((bool)output);
        }
        
        [Fact]
        public void RunValidNoUppercase()
        {
            var input = "No";
            var success = CommandBotFramework.Helpers.ParameterParser.TryParseParameter(ParameterType.Bool, input, out var output);
            Assert.True(success);
            Assert.IsType<bool>(output);
            Assert.False((bool)output);
        }
        
        [Fact]
        public void RunValidNUppercase()
        {
            var input = "N";
            var success = CommandBotFramework.Helpers.ParameterParser.TryParseParameter(ParameterType.Bool, input, out var output);
            Assert.True(success);
            Assert.IsType<bool>(output);
            Assert.False((bool)output);
        }
        
        [Fact]
        public void RunValid0()
        {
            var input = "0";
            var success = CommandBotFramework.Helpers.ParameterParser.TryParseParameter(ParameterType.Bool, input, out var output);
            Assert.True(success);
            Assert.IsType<bool>(output);
            Assert.False((bool)output);
        }
        
        [Fact]
        public void RunInValidString()
        {
            var input = "ThisIsAString123";
            var success = CommandBotFramework.Helpers.ParameterParser.TryParseParameter(ParameterType.Bool, input, out var output);
            Assert.False(success);
        }
    }
}