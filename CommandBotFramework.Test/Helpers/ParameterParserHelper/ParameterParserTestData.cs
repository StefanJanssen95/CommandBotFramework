using System.Collections;
using System.Collections.Generic;
using CommandBotFramework.Enums;

namespace CommandBotFramework.Test.Helpers.ParameterParserHelper
{
    public class ParameterParserTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { ParameterType.String, "1", "1", true };
            yield return new object[] { ParameterType.String, "random", "random", true };

            yield return new object[] { ParameterType.Unknown, "random", "random", true };

            yield return new object[] { ParameterType.Number, "1", 1, true };
            yield return new object[] { ParameterType.Number, "1.1", 1.1m, true };
            yield return new object[] { ParameterType.Number, null, null, false };

            yield return new object[] { ParameterType.Bool, "1", true, true };
            yield return new object[] { ParameterType.Bool, "y", true, true };
            yield return new object[] { ParameterType.Bool, "true", true, true };
            yield return new object[] { ParameterType.Bool, "yes", true, true };

            yield return new object[] { ParameterType.Bool, "0", false, true };
            yield return new object[] { ParameterType.Bool, "n", false, true };
            yield return new object[] { ParameterType.Bool, "false", false, true };
            yield return new object[] { ParameterType.Bool, "no", false, true };

            yield return new object[] { ParameterType.Bool, "whoops", null, false };

            yield return new object[] { (ParameterType)5, "whoops", null, false };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
