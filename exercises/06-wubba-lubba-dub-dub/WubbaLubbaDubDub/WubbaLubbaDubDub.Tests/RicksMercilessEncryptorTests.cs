using System;
using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Fact]
        public void Test_SpitToLines_ReturnsCorrectLinesCount()
        {
            var text = "Wakakak alala\n" +
                "buka wuka\n" +
                "kek";
            Assert.Equal(text.SplitToLines().Length, 3);
        }

        [Fact]
        public void Test_SplitToWords_ReturnsCorrectWords()
        {
            var words = "This    is banan.And it's  tasty! ".SplitToWords();
            string[] correct_words = { "This", "is", "banan", "And", "it's", "tasty" };
            Assert.Equal(correct_words, words);
        }

        [Theory]
        [InlineData("aaaabbbb", "aaaa")]
        [InlineData("aaaabbbbb", "aaaa")]
        public void Test_GetLeftHalf_ReturnsCorrectValue(string line, string answer)
        {
            Assert.Equal(answer, line.GetLeftHalf());
        }

        [Theory]
        [InlineData("aaaabbbb", "bbbb")]
        [InlineData("aaaabbbbb", "bbbbb")]
        public void Test_GetRightHalf_ReturnsCorrectValue(string line, string answer)
        {
            Assert.Equal(answer, line.GetRightHalf());
        }

        [Fact]
        public void Test_Replace_ReturnsCorrectValue()
        {
            string line = "I have a lot of money and I will spend them";
            string correct_line = "We have a lot of money and We will spend them";
            Assert.Equal(correct_line, RicksMercilessEncryptor.Replace(line, "I", "We"));
        }

        [Fact]
        public void Test_CharsToCodes_CorrectSequence()
        {
            string line = "abcde";
            var converted_line = line.CharsToCodes();
            var elements = converted_line.Split("u");
            // Проверяем, что полученная последовательность является восходящей с шагом 1
            // нулевой элемент не проверяем - там пусто
            for (var i = 1; i < elements.Length - 1; i++)
            {
                Assert.Equal(int.Parse(elements[i]), int.Parse(elements[i + 1]) - 1);
            }
        }

        [Theory]
        [InlineData("abcde", "edcba")]
        [InlineData("a", "a")]
        public void Test_GetReversed_ReturnsCorrectValue(string line, string correct_line)
        {
            Assert.Equal(line.GetReversed(), correct_line);
        }

        [Theory]
        [InlineData("a", "A")]
        [InlineData("A", "a")]
        [InlineData("03a", "03A")]
        [InlineData("aBc", "AbC")]
        public void Test_InverseCase_ReturnsCorrectValue(string line, string correct_line)
        {
            Assert.Equal(line.InverseCase(), correct_line);
        }

        [Theory]
        [InlineData("abc", "bcd")]
        [InlineData("0", "1")]
        public void Test_ShiftInc_ReturnsCorrectValue(string line, string correct_line)
        {
            Assert.Equal(line.ShiftInc(), correct_line);
        }

        [Fact]
        public void Test_GetUsedObjects_ReturnsCorrectObjectsCount()
        {
            var objects = ("This    is banan.And it's ¶FFF6:FFF3¶ tasty! \n " +
                " dssdlgsdlgsldgl \n" +
                "// lolololo ¶F00F:FFF3¶\n" +
                "kok ¶FFFF:FFF3¶ \n" +
                "/* sdfgsdgsdg  \n" +
                "sdgsdg ¶FF5F:FFF3¶ sdgsdg \n" +
                "sdgsdgsdgsdgsdgsdgsdg \n" +
                "*/").GetUsedObjects();
            var objects_count = 0;
            foreach (var obj in objects)
            {                
                objects_count++;
            }
            Assert.Equal(2, objects_count);
        }
    }
}
