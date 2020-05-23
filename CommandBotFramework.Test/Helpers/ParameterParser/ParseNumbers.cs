using System;
using CommandBotFramework.Enums;
using Xunit;

namespace CommandBotFramework.Test.Helpers.ParameterParser
{
    public class ParseNumbers
    {
        [Fact]
        public void RunValidInt()
        {
            var input = "123";
            var success = CommandBotFramework.Helpers.ParameterParser.TryParseParameter(ParameterType.Number, input, out var output);
            Assert.True(success);
            Assert.IsType<int>(output);
            Assert.Equal(123, output);
        }
        
        [Fact]
        public void RunValidDecimal()
        {
            var input = "123.456";
            var success = CommandBotFramework.Helpers.ParameterParser.TryParseParameter(ParameterType.Number, input, out var output);
            Assert.True(success);
            Assert.IsType<decimal>(output);
            Assert.Equal(123.456m, output);
        }
        
        [Fact]
        public void RunInValidString()
        {
            var input = "ThisIsAString123";
            var success = CommandBotFramework.Helpers.ParameterParser.TryParseParameter(ParameterType.Number, input, out var output);
            Assert.False(success);
        }
    }
}