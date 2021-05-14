using System;
using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Theory]
        [InlineData(" \nHello, \nworld", new string[] { " ", "Hello, ", "world" })]
        public void Test_SplitToLine(string s, string[] lines)
        {
            Assert.Equal(s.SplitToLines(), lines);
        }

        [Theory]
        [InlineData("Hello, world", new string[] { "Hello", "world" })]
        public void Test_SplitToWords(string s, string[] words)
        {
            Assert.Equal(s.SplitToWords(), words);
        }

        [Theory]
        [InlineData("Hello", "He")]
        [InlineData("Hell", "He")]
        public void Test_GetLeftHalf(string s, string half)
        {
            Assert.Equal(s.GetLeftHalf(), half);
        }

        [Theory]
        [InlineData("Hello", "llo")]
        [InlineData("Hell", "ll")]
        public void Test_GetRightHalf(string s, string half)
        {
            Assert.Equal(s.GetRightHalf(), half);
        }

        [Theory]
        [InlineData("Hello", "ll", "a", "Heao")]
        [InlineData("Hell", "ll", "a", "Hea")]
        public void Test_Replace(string s, string old, string @new, string replacing)
        {
            Assert.Equal(s.Replace(old, @new), replacing);
        }

        [Theory]
        [InlineData("Hello", "olleH")]
        public void Test_GetReversed(string s, string reversed)
        {
            Assert.Equal(s.GetReversed(), reversed);
        }

        [Theory]
        [InlineData("Hello", "hELLO")]
        public void Test_InverseCase(string s, string inversed)
        {
            Assert.Equal(s.InverseCase(), inversed);
        }

        [Theory]
        [InlineData("Hello", "Ifmmp")]
        public void Test_ShiftInc(string s, string shifted)
        {
            Assert.Equal(s.ShiftInc(), shifted);
        }

        [Theory]
        [InlineData("¶1234:5678¶ ¶1234:5678¶", new long[] { 0x12345678 })]
        [InlineData("¶1234:5678¶//¶1111:1111¶", new long[] { 0x12345678 })]
        [InlineData("¶1234:5678¶/*¶1111:1111\n¶2222:2222¶*/", new long[] { 0x12345678 })]
        public void Test_GetUsedObjects(string s, long[] objects)
        {
            Assert.Equal(s.GetUsedObjects(), objects);
        }
    }
}
