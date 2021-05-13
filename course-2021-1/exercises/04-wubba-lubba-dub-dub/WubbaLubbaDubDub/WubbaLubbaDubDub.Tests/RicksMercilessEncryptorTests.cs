using System;
using System.Linq;
using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Theory]
        [InlineData("abc\nd\tef\n", new string[] { "abc", "d\tef", "" })]
        public void Test_SplitToLine(string s, string[] expected)
        {
            Assert.Equal(expected, s.SplitToLines());
        }


        [Theory]
        [InlineData("ab\tcd\n ef\n", new string[]{"ab", "cd", "ef"})]
        public void Test_SplitToWords(string s, string[] expected)
        {
            Assert.Equal(expected, s.SplitToWords());
        }

        [Theory]
        [InlineData("abcdefg", "abc")]
        [InlineData("", "")]
        public void Test_GetLeftHalf(string s, string expected)
        {
            Assert.Equal(expected, s.GetLeftHalf());
        }

        [Theory]
        [InlineData("abcdefg", "defg")]
        [InlineData("", "")]
        public void Test_GetRightHalf(string s, string expected)
        {
            Assert.Equal(expected, s.GetRightHalf());
        }

        [Theory]
        [InlineData("abcdefgabcdabbc", "abc", "cum", "cumdefgcumdabbc")]
        public void Test_Replace(string s, string oldVal, string newVal, string expected)
        {
            Assert.Equal(expected, s.Replace(oldVal, newVal));
        }

        [Theory]
        [InlineData("abc", "\\u0061\\u0062\\u0063")]
        public void Test_CharsToCodes(string s, string res)
        {
            Assert.Equal(s.CharsToCodes(), res);
        }

        [Theory]
        [InlineData("ab", "ba")]
        [InlineData("ab12", "21ba")]
        [InlineData("", "")]
        public void Test_GetReversed(string s, string expected)
        {
            Assert.Equal(expected, s.GetReversed());
        }

        [Theory]
        [InlineData("abCdE12", "ABcDe12")]
        [InlineData("", "")]
        public void Test_InverseCase(string s, string expected)
        {
            Assert.Equal(expected,s.InverseCase());
        }

        [Theory]
        [InlineData("abCdE12", "bcDeF23")]
        [InlineData("", "")]
        public void Test_ShiftInc(string s, string expected)
        {
            Assert.Equal(expected, s.ShiftInc());
        }
        [Theory]
        [InlineData("¶ABCD:1234¶/*//¶BCDE:2345¶*/¶CDEF:3456¶//¶AAAA:1234¶", new long[] { 0xABCD1234, 0xCDEF3456 })]
        public void Test_GetUsedObjects(string s, long[] expected)
        {
            Assert.Equal(expected, s.GetUsedObjects().ToArray()); 
        }
    }
}
