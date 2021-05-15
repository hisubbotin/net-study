using System;
using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Theory]
        [InlineData("Hello, world!   \n    Hello, Russia\n Hi!", new[] { "Hello, world!   ", "    Hello, Russia", " Hi!" })]
        [InlineData("Hi\n\n\n", new[] { "Hi", "", "", "" })]
        public static void TestSplitToLines(string str, string[] right_result)
        {
            Assert.Equal(right_result, str.SplitToLines());
        }

        [Theory]
        [InlineData("Hello, world!", new[] { "Hello,", "world!",})]
        [InlineData("Hi  hi   hh ", new[] { "Hi", "hi", "hh" })]
        [InlineData("123 1-2 1,1 1.3 ", new[] { "123", "1-2", "1,1", "1.3" })]
        public static void TestSplitToWords(string str, string[] right_result)
        {
            Assert.Equal(right_result, str.SplitToWords());
        }

        [Theory]
        [InlineData("1234567890", "12345" )]
        [InlineData("123456789",  "1234" )]
        public static void TestGetLeftHalf(string str, string right_result)
        {
            Assert.Equal(right_result, str.GetLeftHalf());
        }

        [Theory]
        [InlineData("1234567890",  "67890")]
        [InlineData("123456789", "56789")]
        public static void TestGetRightHalf(string str, string right_result)
        {
            Assert.Equal(right_result, str.GetRightHalf());
        }


        [Theory]
        [InlineData("He lo lo low", "lo", "o", "He o o ow")]
        [InlineData("Abacaba cabaaba", "ba", "ca", "Acacaca cacaaca")]
        public static void TestReplace(string str, string old, string new_str, string right_result)
        {
            Assert.Equal(right_result, str.Replace(old, new_str ));
        }

        [Theory]
        [InlineData("b1\n", @"\u0062\u0031\u000a")]
        [InlineData("fff3", @"\u0066\u0066\u0066\u0033")]
        public static void TestCharsToCodes(string str, string right_result)
        {
            Assert.Equal(right_result, str.CharsToCodes());
        }


        [Theory]
        [InlineData("topot", "topot")]
        [InlineData("abcd", "dcba")]
        [InlineData("abcde", "edcba")]
        public static void TestGetReversed(string str, string right_result)
        {
            Assert.Equal(right_result, str.GetReversed());
        }


        [Theory]
        [InlineData("HellO", "hELLo")]
        [InlineData("aB56Cd", "Ab56cD")]
        public static void TestInverseCase(string str, string right_result)
        {
            Assert.Equal(right_result, str.InverseCase());
        }

        [Theory]
        [InlineData("HellO", "IfmmP")]
        [InlineData("aB56Cd", "bC67De")]
        public static void TestShiftInc(string str, string right_result)
        {
            Assert.Equal(right_result, str.ShiftInc());
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
