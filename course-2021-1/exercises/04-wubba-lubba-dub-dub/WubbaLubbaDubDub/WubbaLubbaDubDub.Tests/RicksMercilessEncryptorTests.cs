using System;
using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        
        [Theory]
        [InlineData("", "")]
        [InlineData(" ", "")]
        [InlineData("abcdefg", "abc")]
        [InlineData("\neven\n", "\nev")]
        public void Test_GetLeftHalf(string a, string b)
        {
            Assert.Equal(b, a.GetLeftHalf());
        }
        
        [Theory]
        [InlineData("", "")]
        [InlineData(" ", " ")]
        [InlineData("abcdefg", "defg")]
        [InlineData("\neven\n", "en\n")]
        public void Test_GetRightHalf(string a, string b)
        {
            Assert.Equal(b, a.GetRightHalf());
        }

        [Theory]
        [InlineData("abcdefg a again", 'a', '_', "_bcdefg _ _g_in")]
        [InlineData("No change", ' ', ' ', "No change")]
        [InlineData("", 'a', 'b', "")]
        [InlineData("\na\nb\nc\n", '\n', ' ', " a b c ")]
        public void Test_Replace(string a, char o, char n, string b)
        {
            Assert.Equal(b, a.Replace(o, n));
        }

        [Theory]
        [InlineData("", "")]
        [InlineData(" ", "\\u0020")]
        [InlineData("abcdefg", "\\u0061\\u0062\\u0063\\u0064\\u0065\\u0066\\u0067")]
        [InlineData("1\n_?\t'!%&\\", "\\u0031\\u000a\\u005f\\u003f\\u0009\\u0027\\u0021\\u0025\\u0026\\u005c")]
        public void Test_CharsToCodes(string a, string b)
        {
            Assert.Equal(b, a.CharsToCodes());
        }

        [Theory]
        [InlineData("", new string[] {""})]
        [InlineData("\n\n\n", new string[] {"", "", "", ""})]
        [InlineData("\n   \n\n", new string[] {"", "   ", "", ""})]
        [InlineData("Never gonna give you up\nNever gonna let you down\nNever gonna run around and desert you",
        new string[] {"Never gonna give you up", "Never gonna let you down", "Never gonna run around and desert you"})]
        public void Test_SplitToLines(string a, string[] b)
        {
            Assert.Equal(b, a.SplitToLines());
        }
        
        [Theory]
        [InlineData("", new string[] {})]
        [InlineData(" a b   cdef ", new string[] {"a", "b", "cdef"})]
        [InlineData("a    test     string", new string[] {"a", "test", "string"})]
        [InlineData("       ", new string[] {})]
        public void Test_SplitToWords(string a, string[] b)
        {
            Assert.Equal(b, a.SplitToWords());
        }
        
        [Theory]
        [InlineData("", "")]
        [InlineData(" ", " ")]
        [InlineData("abc", "cba")]
        [InlineData("Big\nFloppa", "appolF\ngiB")]
        public void Test_GetReversed(string a, string b)
        {
            Assert.Equal(b, a.GetReversed());
        }
        
        [Theory]
        [InlineData("", "")]
        [InlineData(" ", " ")]
        [InlineData("abc", "ABC")]
        [InlineData("Big\nFloppa", "bIG\nfLOPPA")]
        public void Test_InverseCase(string a, string b)
        {
            Assert.Equal(b, a.InverseCase());
        }

    }
}
