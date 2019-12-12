using System;
using Xunit;

namespace Weknow_BasicExtensions_Tests
{
    public class StringExtensionsTests
    {
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
            Assert.Equal(expected, result);
        }

        #endregion // String_ToSCREAMING_Test_Succeed

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
            Assert.Equal(expected, result);
        }

        #endregion // String_ToCamelCase_Test_Succeed
    }
}
