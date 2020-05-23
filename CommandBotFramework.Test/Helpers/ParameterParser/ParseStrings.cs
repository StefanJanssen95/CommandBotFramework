using System;
using CommandBotFramework.Enums;
using Xunit;

namespace CommandBotFramework.Test.Helpers.ParameterParser
{
    public class ParseStrings
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
    }
}