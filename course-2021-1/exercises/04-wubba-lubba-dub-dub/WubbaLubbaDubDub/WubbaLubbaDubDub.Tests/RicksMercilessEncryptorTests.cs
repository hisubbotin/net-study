using System;
using System.Runtime.InteropServices;
using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Theory]
        [InlineData("abcde", new [] { "abcde" })]
        [InlineData("a\na\na\n", new [] { "a", "a", "a", "" })]
        [InlineData("a\n\na", new [] { "a", "", "a" })]
        public void SplitToLines(string text, string[] expected)
        {
            Assert.Equal(expected, RicksMercilessEncryptor.SplitToLines(text));
        }
        
        [Theory]
        [InlineData("abcde", new [] { "abcde" })]
        [InlineData("a a a", new [] { "a", "a", "a" })]
        [InlineData("a  a", new [] { "a", "a" })]
        public void SplitToWords(string line, string[] expected)
        {
            Assert.Equal(expected, RicksMercilessEncryptor.SplitToWords(line));
        }

        [Theory]
        [InlineData("ab", "a")]
        [InlineData("abcde", "ab")]
        public void GetLeftHalf(string s, string expected)
        {
            Assert.Equal(expected, RicksMercilessEncryptor.GetLeftHalf(s));
        }
        
        [Theory]
        [InlineData("ab", "b")]
        [InlineData("abcde", "cde")]
        public void GetRightHalf(string s, string expected)
        {
            Assert.Equal(expected, RicksMercilessEncryptor.GetRightHalf(s));
        }
        
        [Theory]
        [InlineData("abd\ne", "d\n", "cd", "abcde")]
        [InlineData("arepeatbrepeatcrepeatdrepeate", "repeat", "", "abcde")]
        public void Replace(string s, string old, string @new, string expected)
        {
            Assert.Equal(expected, RicksMercilessEncryptor.Replace(s, old, @new));
        }
        
        [Theory]
        [InlineData("abcde", "\\u0061\\u0062\\u0063\\u0064\\u0065")]
        public void CharsToCodes(string s, string expected)
        {
            Assert.Equal(expected, RicksMercilessEncryptor.CharsToCodes(s));
        }

        [Theory]
        [InlineData("abcde", "edcba")]
        public void GetReversed(string s, string expected)
        {
            Assert.Equal(expected, RicksMercilessEncryptor.GetReversed(s));
        }

        [Theory]
        [InlineData("aAbBcC", "AaBbCc")]
        public void InverseCase(string s, string expected)
        {
            Assert.Equal(expected, RicksMercilessEncryptor.InverseCase(s));
        }

        [Theory]
        [InlineData("abcde", "bcdef")]
        public void ShiftInc(string s, string expected)
        {
            Assert.Equal(expected, RicksMercilessEncryptor.ShiftInc(s));
        }

    }
}
