using System;
using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {

        [Fact]
        public void SplitToLines_test()
        {
            string[] substrs = { "uta", "kek", "opa ! 1", " 123 " };

            string s = String.Join("\n", substrs);
            string[] result = s.SplitToLines();

            Assert.Equal(result.Length, substrs.Length);
            for (int i = 0; i < result.Length; i++)
            {
                Assert.Equal(substrs[i], result[i]);
            }
        }

        [Fact]
        public void SplitToWords_test()
        {
            string[] substrs = { "uta", "kek", "opa1", " 123 ", "uta", ";;;!!NOO", " " };
            string[] realResult = { "uta", "kek", "opa", "uta", "NOO" };

            string s = String.Join(" ", substrs);

            string[] result = s.SplitToWords();

            Assert.Equal(result, realResult);
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("12345", "12")]
        [InlineData("1234", "12")]
        [InlineData("1", "")]
        public void GetLeftHalf_test(string arg, string result)
        {
            Assert.Equal(result, arg.GetLeftHalf());
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("12345", "345")]
        [InlineData("1234", "34")]
        [InlineData("1", "1")]
        public void GetRightHalf_test(string arg, string result)
        {
            Assert.Equal(result, arg.GetRightHalf());
        }

        [Theory]
        [InlineData("", "u", "u", "")]
        [InlineData("12345", "u", "u", "12345")]
        [InlineData("12345", "23", "32", "13245")]
        [InlineData("1111", "1", "11", "11111111")]
        [InlineData("1223", "2", "3", "1333")]
        [InlineData("12345", "12345", "", "")]
        public void Replace_test(string arg, string old, string @new, string result)
        {
            Assert.Equal(result, arg.Replace(old, @new));
        }

        [Theory]
        [InlineData(@"abc ABC 012 ÀÁÂ", @"\u0061\u0062\u0063\u0020\u0041\u0042\u0043\u0020\u0030\u0031\u0032\u0020\u0410\u0411\u0412")]
        public void CharsToCodes_test(string arg, string result)
        {
            Assert.Equal(result, arg.CharsToCodes());
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("1", "1")]
        [InlineData("abc", "cba")]
        [InlineData("ab ab ab", "ba ba ba")]
        public void GetReversed_test(string arg, string result)
        {
            Assert.Equal(arg.GetReversed(), result);
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("1", "1")]
        [InlineData("abc ABC 123 Àáâ", "ABC abc 123 àÁÂ")]
        public void InverseCase_test(string arg, string result)
        {
            Assert.Equal(result, arg.InverseCase());
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("1", "2")]
        [InlineData("abcABC123Àáâ", "bcdBCD234Áâã")]
        public void ShiftInc_test(string arg, string result)
        {
            Assert.Equal(result, arg.ShiftInc());
        }

        [Fact]
        public static void GetUsedObjects_test()
        {
            string[] lines = {
                "heh 00000000:0000000A /* useless code 00000000:0000001 // 00000000:0000002 more useless code",
                "*/",
                "var 00000000:00000011 // 00000000:00000005",
                "// 00000000:00000010/*/**/*/",
                "/*00000000:00000010 */ 00000000:00000010 /*00000000:00000010*/",
                ""
            };
            string text = String.Join("\n", lines);

            long[] result = { 10L, 17L, 16L};

            Assert.Equal(text.GetUsedObjects(), result);
        }
    }
}
