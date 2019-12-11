using System;
using Xunit;

namespace Weknow_BasicExtensions_Tests
{
    public class StringExtensionsTests
    {
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
        public void StringExtensionsTest_Succeed(string input, string expected)
        {
            string result = input.ToSCREAMING();
            Assert.Equal(expected, result);
        }
    }
}
