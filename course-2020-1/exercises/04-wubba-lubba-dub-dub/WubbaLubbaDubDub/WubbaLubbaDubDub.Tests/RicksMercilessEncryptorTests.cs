using System;
using Xunit;
using System.Linq;

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
        [InlineData("139", @"\u0031\u0033\u0039")]
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

        [Theory]
        [InlineData("¶1234:0000¶ // ¶0000:0001¶ /* ¶0000:0002¶ \n ¶0000:0003¶ // ¶0000:0004¶ */ ¶0000:0005¶", new[] { 12340000L, 3L })]
        [InlineData("¶0000:0000¶ /* ¶0000:0001¶ \n ¶0000:0002¶ // ¶0000:0003¶ */ ¶0000:1234¶", new[] { 0L, 1234L })]
        private void TestGetUsedObjects(string text, long[] ids)
        {
            Assert.Equal(ids, text.GetUsedObjects().ToArray());
        }
    }
}
