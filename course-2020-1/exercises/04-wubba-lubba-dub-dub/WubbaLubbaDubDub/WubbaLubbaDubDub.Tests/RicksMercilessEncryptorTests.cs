using System;
using Xunit;
using System.Runtime.InteropServices;
using WubbaLubbaDubDub;


namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Theory]
        [InlineData("Arman\nStepanyan\n", new[] {"Arman", "Stepanyan", ""})]
        [InlineData("\n\n\n", new[] {"", "", "", ""})]
        public void TestSplitToLines(string text, string[] answer)
        {
            Assert.Equal(answer, text.SplitToLines());
        }

        [Theory]
        [InlineData("Arman Stepanyan", new[] {"Arman", "Stepanyan"})]
        [InlineData("Lorem\t\nipsum,   abacaba", new[] {"Lorem", "ipsum", "abacaba"})]
        public void TestSplitToWords(string line, string[] answer)
        {
            Assert.Equal(answer, line.SplitToWords());
        }

        [Theory]
        [InlineData("abccabc", "abc")]
        [InlineData("testtest", "test")]
        public void TestGetLeftHalf(string s, string answer)
        {
            Assert.Equal(answer, s.GetLeftHalf());
        }

        [Theory]
        [InlineData("gcdcgcd", "cgcd")]
        [InlineData("aharon", "aron")]
        public void TestGetRightHalf(string s, string answer)
        {
            Assert.Equal(answer, s.GetRightHalf());
        }

        [Theory]
        [InlineData("abacaba", "aba", "cd", "cdccd")]
        [InlineData("rastvor", "vor", "kac", "rastkac")]
        public void TestReplace(string s, string old_str, string new_str, string answer)
        {
            Assert.Equal(answer, WubbaLubbaDubDub.RicksMercilessEncryptor.Replace(s, old_str, new_str));
        }

        [Theory]
        [InlineData("abaaba", @"\u0061\u0062\u0061\u0061\u0062\u0061")]
        public void TestCharsToCodes(string s, string answer)
        {
            Assert.Equal(answer, s.CharsToCodes());
        }

        [Theory]
        [InlineData("abacaba", "abacaba")]
        [InlineData("keklol", "lolkek")]
        public void TestReverse(string s, string answer)
        {
            Assert.Equal(answer, s.GetReversed());
        }

        [Theory]
        [InlineData("arman", "ARMAN")]
        public void TestInverseCase(string s, string answer)
        {
            Assert.Equal(answer, s.InverseCase());
        }

        [Theory]
        [InlineData("AbacAbA", "BcbdBcB")]
        public void TestShiftInc(string s, string answer)
        {
            Assert.Equal(answer, s.ShiftInc());
        }
    }
}
