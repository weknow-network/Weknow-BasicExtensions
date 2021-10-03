using System;

using Xunit;
using Xunit.Abstractions;

namespace Weknow_BasicExtensions_Tests
{
    public class StringExtensionsTests
    {
        private readonly ITestOutputHelper _outputHelper;

        #region Ctor

        public StringExtensionsTests(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        #endregion Ctor

        #region String_ToSCREAMING_Test_Succeed

        [Theory]
        [InlineData("BnayaEshet", "BNAYA_ESHET")]
        [InlineData("Bnaya_Eshet", "BNAYA_ESHET")]
        [InlineData("Bnaya_ESHET", "BNAYA_ESHET")]
        [InlineData("Bnaya1234Eshet", "BNAYA1234_ESHET")]
        [InlineData("Bnaya Eshet", "BNAYA_ESHET")]
        [InlineData(" Bnaya Eshet", "BNAYA_ESHET")]
        [InlineData("Bnaya Eshet ", "BNAYA_ESHET")]
        [InlineData("Bnaya  Eshet", "BNAYA_ESHET")]
        [InlineData("Bnay$a  Eshet", "BNAY$A_ESHET")]
        [InlineData("Bnaya$  Eshet", "BNAYA$_ESHET")]
        [InlineData("Bnaya$Eshet", "BNAYA$_ESHET")]
        [InlineData("Bnaya__Eshet", "BNAYA_ESHET")]
        [InlineData("Bnaya_ _Eshet", "BNAYA_ESHET")]
        [InlineData("Bnaya _ _Eshet", "BNAYA_ESHET")]
        [InlineData("Bnaya_ _ Eshet", "BNAYA_ESHET")]
        [InlineData("", "")]
        [InlineData(null, "")]
        public void String_ToSCREAMING_Test_Succeed(string input, string expected)
        {
            string result = input.ToSCREAMING();
            _outputHelper.WriteLine($"'{input}' = '{result}'");
            Assert.Equal(expected, result);
        }

        #endregion // String_ToSCREAMING_Test_Succeed

        #region String_ToDash_Test_Succeed

        [Theory]
        [InlineData("BnayaEshet", "bnaya-eshet")]
        [InlineData("Bnaya_Eshet", "bnaya-eshet")]
        [InlineData("Bnaya_ESHET", "bnaya-eshet")]
        [InlineData("Bnaya1234Eshet", "bnaya1234-eshet")]
        [InlineData("Bnaya Eshet", "bnaya-eshet")]
        [InlineData(" Bnaya Eshet", "bnaya-eshet")]
        [InlineData("Bnaya Eshet ", "bnaya-eshet")]
        [InlineData("Bnaya  Eshet", "bnaya-eshet")]
        [InlineData("Bnay$a  Eshet", "bnay-a-eshet")]
        [InlineData("Bnaya$  Eshet", "bnaya-eshet")]
        [InlineData("Bnaya$Eshet", "bnaya-eshet")]
        [InlineData("Bnaya--Eshet", "bnaya-eshet")]
        [InlineData("Bnaya- -Eshet", "bnaya-eshet")]
        [InlineData("Bnaya__Eshet", "bnaya-eshet")]
        [InlineData("Bnaya_ _Eshet", "bnaya-eshet")]
        [InlineData("Bnaya _ _Eshet", "bnaya-eshet")]
        [InlineData("Bnaya_ _ Eshet", "bnaya-eshet")]
        [InlineData("", "")]
        [InlineData(null, "")]
        public void String_ToDash_Test_Succeed(string input, string expected)
        {
            string result = input.ToDash();
            _outputHelper.WriteLine($"'{input}' = '{result}'");
            Assert.Equal(expected, result);
        }

        #endregion // String_ToDash_Test_Succeed

        #region String_ToPascalCase_Test_Succeed

        [Theory]
        [InlineData("BnayaEshet", "BnayaEshet")]
        [InlineData("bnayaEshet", "BnayaEshet")]
        [InlineData("bnaya Eshet", "Bnaya Eshet")]
        [InlineData("", "")]
        [InlineData(null, "")]
        public void String_ToPascalCase_Test_Succeed(string input, string expected)
        {
            string result = input.ToPascalCase();
            _outputHelper.WriteLine($"'{input}' = '{result}'");
            Assert.Equal(expected, result);
        }

        #endregion // String_ToPascalCase_Test_Succeed

        #region String_ToCamelCase_Test_Succeed

        [Theory]
        [InlineData("BnayaEshet", "bnayaEshet")]
        [InlineData("bnayaEshet", "bnayaEshet")]
        [InlineData("bnaya Eshet", "bnaya Eshet")]
        [InlineData("", "")]
        [InlineData(null, "")]
        public void String_ToCamelCase_Test_Succeed(string input, string expected)
        {
            string result = input.ToCamelCase();
            _outputHelper.WriteLine($"'{input}' = '{result}'");
            Assert.Equal(expected, result);
        }

        #endregion // String_ToCamelCase_Test_Succeed
    }
}
