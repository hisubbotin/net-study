using System;
using System.Runtime.InteropServices;
using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Theory]
        [InlineData("Hi!\nMy name is Daniil.\nI'm from Moscow.\n", new string[] {"Hi!", "My name is Daniil.", "I'm from Moscow.", ""})]
        [InlineData("Wow\nSo amazing!", new string[] {"Wow", "So amazing!"})]
        public void SplitToLinesTest(string text, string[] answer)
        {
            string[] my_lines = RicksMercilessEncryptor.SplitToLines(text);
            Assert.Equal(my_lines, answer);
        }
        
        [Theory]
        [InlineData("Hi!\nMy name is Daniil.\nI'm from Moscow.\n", new string[] {"Hi!", "My", "name", "is", "Daniil.", "I'm", "from", "Moscow."})]
        public void SplitToWordsTest(string line, string[] answer)
        {
            string[] my_lines = RicksMercilessEncryptor.SplitToWords(line);
            Assert.Equal(my_lines, answer);
        }

        [Theory]
        [InlineData("Abacaba", "Aba")]
        [InlineData("Abacabab", "Abac")]
        public void GetLeftHalfTest(string line, string left_half)
        {
            string my_line = RicksMercilessEncryptor.GetLeftHalf(line);
            Assert.Equal(my_line, left_half);
        }

        [Theory]
        [InlineData("Abacaba", "caba")]
        [InlineData("Abacabab", "abab")]        
        public void GetRightHalfTest(string line, string right_half)
        {
            string my_line = RicksMercilessEncryptor.GetRightHalf(line);
            Assert.Equal(my_line, right_half);
        }

        [Theory]
        [InlineData("the small, the right, the short", "the", "a", "a small, a right, a short")]
        public void ReplaceTest(string line, string old, string @new, string replaced)
        {
            string my_line = RicksMercilessEncryptor.Replace(line, old, @new);
            Assert.Equal(my_line, replaced);
        }
        
        [Theory]
        [InlineData("Aeroplane", "enalporeA")]
        public void GetReversedTest(string line, string reversed)
        {
            string my_line = RicksMercilessEncryptor.GetReversed(line);
            Assert.Equal(my_line, reversed);
        }
        
        [Theory]
        [InlineData("Aeroplane", "aEROPLANE")]
        [InlineData("WoW, VeRy CoOl!", "wOw, vErY cOoL!")]
        public void InversedCaseTest(string line, string inversed)
        {
            string my_line = RicksMercilessEncryptor.InverseCase(line);
            Assert.Equal(my_line, inversed);
        }        
        
        [Theory]
        [InlineData("Aeroplane", "Bfspqmbof")]
        [InlineData("abc", "bcd")]
        public void ShiftIncTest(string line, string inversed)
        {
            string my_line = RicksMercilessEncryptor.ShiftInc(line);
            Assert.Equal(my_line, inversed);
        }
        
        [Theory]
        [InlineData("//First comment \n /* Long \n comment AAAA:5555 \n */ My string F0BE:01A0 \n Second string AC10:0115", new long[] {4038984096, 2886730005})]
        public void GetUsedObjectsTest(string text, long[] result)
        {
            Assert.Equal(result, text.GetUsedObjects());
        }
    }
}
