using CommandBotFramework.Enums;
using CommandBotFramework.Helpers;
using Xunit;

namespace CommandBotFramework.Test.Helpers.ParameterParserHelper
{
    public class ParameterParserTests
    {
        [Theory]
        [ClassData(typeof(ParameterParserTestData))]
        public void TryParseTests(ParameterType type, string inputValue, object expectedOutput, bool expectedResult)
        {
            //Arrange

            //Act
            var actualResult = ParameterParser.TryParseParameter(type, inputValue, out object actualOutput);

            //Assert
            Assert.Equal(expectedResult, actualResult);
            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}