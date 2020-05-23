using System;
using CommandBotFramework.Enums;
using Xunit;

namespace CommandBotFramework.Test.Helpers.ParameterParser
{
    public class ParseUnknown
    {
        [Fact]
        public void RunTestString()
        {
            var input = "09pTF*()^OKL:@K$(@)*%#V<VLVJOMIUMR()I#)I%OI$#PO#";
            var success = CommandBotFramework.Helpers.ParameterParser.TryParseParameter(ParameterType.String, input, out var output);
            Assert.True(success);
            Assert.IsType<string>(output);
            Assert.Equal(input, output);
        }

        [Fact]
        public void RunTestNumber()
        {
            var input = "5.4";
            var success = CommandBotFramework.Helpers.ParameterParser.TryParseParameter(ParameterType.String, input, out var output);
            Assert.True(success);
            Assert.IsType<string>(output);
            Assert.Equal(input, output);
        }
    }
}