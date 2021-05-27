using System;
using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Fact]
        private static void Test_SplitToLines()
        {
            string text = "Hello\nWorld";
            var list = text.SplitToLines();
            Assert.Equal("Hello", list[0]);
            Assert.Equal("World", list[1]);
        }
        [Fact]
        private static void Test_SplitToWords()
        {
            string text = "Hello World";
            var list = text.SplitToWords();
            Assert.Equal("Hello", list[0]);
            Assert.Equal("World", list[1]);
        }
        [Fact]
        private static void Test_GetLeftHalf()
        {
            string text = "Hello World";
            Assert.Equal("Hello", text.GetLeftHalf());
        }
        [Fact]
        private static void Test_GetRightHalf()
        {
            string text = "Hello World";
            Assert.Equal(" World", text.GetRightHalf());
        }
        [Fact]
        private static void Test_GetRightHalf()
        {
            string text = "Hello World";
            Assert.Equal("He11o World", text.Replace("ll", "11"));
        }
        [Fact]
        private static void Test_CharsToCodes()
        {
            string text = "He";
            Assert.Equal("\\u0048\\u0065", text.CharsToCodes());
        }
        [Fact]
        private static void Test_GetReversed()
        {
            string text = "Hello";
            Assert.Equal("olleH", text.GetReversed());
        }
        [Fact]
        private static void Test_InverseCase()
        {
            string text = "Hello";
            Assert.Equal("hELLO", text.InverseCase());
        }
        [Fact]
        private static void Test_ShiftInc()
        {
            string text = "Hello";
            Assert.Equal("Ifmmp", text.InverseCase());
        }
        [Fact]
        private static void Test_GetUsedObjects()
        {
            string str = 
            @"// comment
            dead:beef
            /*
                Задача на поиграться с регулярками - вся сложность в том, чтобы аккуратно игнорировать комментарии.
                Экспериментировать онлайн можно, например, здесь: http://regexstorm.net/tester и https://regexr.com/
            */";

            Assert.Equal(3735928559, str.GetUsedObjects());
        }
    }
}
