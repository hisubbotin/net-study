using System;
using System.Runtime.InteropServices;
using Xunit;
using WubbaLubbaDubDub;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Theory]
        [InlineData("Lorem\nipsum\n", new[] {"Lorem", "ipsum", ""})]
        [InlineData("\n\n\n\n", new[] {"", "", "", "", ""})]
        public void Test_SplitToLines(string text, string[] answer)
        {
            Assert.Equal(answer, text.SplitToLines());
        }

        [Theory]
        [InlineData("Lorem ipsum", new[] {"Lorem", "ipsum"})]
        [InlineData("Lorem\t\nipsum,   abacaba?", new[] {"Lorem", "ipsum", "abacaba"})]
        public void Test_SplitToWords(string line, string[] answer)
        {
            Assert.Equal(answer, line.SplitToWords());
        }

        [Theory]
        [InlineData("abacaba", "aba")]
        [InlineData("keklol", "kek")]
        public void Test_GetLeftHalf(string s, string answer)
        {
            Assert.Equal(answer, s.GetLeftHalf());
        }

        [Theory]
        [InlineData("abacaba", "caba")]
        [InlineData("keklol", "lol")]
        public void Test_GetRightHalf(string s, string answer)
        {
            Assert.Equal(answer, s.GetRightHalf());
        }
        
        [Theory]
        [InlineData("abacaba", "aba", "go", "gocgo")]
        [InlineData("keklol", "lol", "kek", "kekkek")]
        [InlineData("aaaa", "a", "b", "bbbb")]
        public void Test_Replace(string s, string old_str, string new_str, string answer)
        {
            Assert.Equal(answer, WubbaLubbaDubDub.RicksMercilessEncryptor.Replace(s, old_str, new_str));
        }
        
        [Theory]
        [InlineData("abaCaba", @"\u0061\u0062\u0061\u0043\u0061\u0062\u0061")]
        [InlineData("ab1\n", @"\u0061\u0062\u0031\u000a")]
        public void Test_CharsToCodes(string s, string answer)
        {
            Assert.Equal(answer, s.CharsToCodes());
        }
        
        [Theory]
        [InlineData("abacaba", "abacaba")]
        [InlineData("keklol", "lolkek")]
        public void Test_Reverse(string s, string answer)
        {
            Assert.Equal(answer, s.GetReversed());
        }
        
        [Theory]
        [InlineData("abacaba", "ABACABA")]
        [InlineData("KekloL", "kEKLOl")]
        [InlineData("haHa1", "HAhA1")]
        public void Test_InverseCase(string s, string answer)
        {
            Assert.Equal(answer, s.InverseCase());
        }
        
        [Theory]
        [InlineData("AbacAbA", "BcbdBcB")]
        [InlineData("ABc123\"", "BCd234#")]
        public void Test_ShiftInc(string s, string answer)
        {
            Assert.Equal(answer, s.ShiftInc());
        }

        [Theory]
        [InlineData("1234:5678\n1234:5679", new long[] { 12345678, 12345679 })]
        [InlineData("1234:5678\n1234:5678", new long[] {12345678})]
        [InlineData("//1234:5678\nhello, world:1234:5679\n11234:9876", new long[] {12345679, 12349876})]
        [InlineData("/*ar1234:5698\n1235:5566\n\n32323:5648*/\n22:456:7564:7895\t", new long[] { 75647895 })]
        public static void TestGetUsedObjects(string str, long[] right_result)
        {
            Assert.Equal(right_result, str.GetUsedObjects());
        }
        
    }
}
