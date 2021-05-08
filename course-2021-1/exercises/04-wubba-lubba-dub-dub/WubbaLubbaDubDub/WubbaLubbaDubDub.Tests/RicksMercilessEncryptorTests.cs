using System;
using System.Collections.Immutable;
using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        String m_TestText = "AAaa, bbbb, ssss.//jkljsdfjjdscovk\n" +
                            "LKLjmlksdjfm/*sdsd\n" +
                            "sdfnk_mlskmdcm: ls,dl,*/" +
                            "\n //fdf'sdfds, jnfdk odlfdv lkncdn";

        [Fact]
        public void Test_SplitToLines()
        {
            String[] expected =
            {
                "AAaa, bbbb, ssss.//jkljsdfjjdscovk",
                "LKLjmlksdjfm/*sdsd",
                "sdfnk_mlskmdcm: ls,dl,*/",
                " //fdf'sdfds, jnfdk odlfdv lkncdn"
            };
            Assert.Equal(expected, RicksMercilessEncryptor.SplitToLines(m_TestText));
        }

        [Fact]
        public void Test_SplitToWords()
        {
            String[] expected =
            {
                "AAaa", "bbbb", "ssss", "jkljsdfjjdscovk",
                "LKLjmlksdjfm", "sdsd",
                "sdfnk_mlskmdcm", "ls", "dl",
                "fdf", "sdfds", "jnfdk", "odlfdv", "lkncdn"
            };
            foreach (string word in RicksMercilessEncryptor.SplitToWords(m_TestText))
            {
                Console.WriteLine(word);
            }

            Assert.Equal(expected, RicksMercilessEncryptor.SplitToWords(m_TestText));
        }

        [Theory]
        [InlineData("123456789", "1234")]
        [InlineData("1234567890", "12345")]
        public void Test_GetLeftHalf(String s, String expected)
        {
            Assert.Equal(expected, RicksMercilessEncryptor.GetLeftHalf(s));
        }

        [Theory]
        [InlineData("123456789", "56789")]
        [InlineData("1234567890", "67890")]
        public void Test_GetRightHalf(String s, String expected)
        {
            Assert.Equal(expected, RicksMercilessEncryptor.GetRightHalf(s));
        }

        [Fact]
        public void Test_Replace()
        {
            Assert.Equal("I am right", RicksMercilessEncryptor.Replace("I am left", "left", "right"));
        }

        [Fact]
        public void Test_CharsToCodes()
        {
            Assert.Equal(@"\u0067\u0068\u0062\u0064\u0074\u006e\u0032\u0033\u0033",
                RicksMercilessEncryptor.CharsToCodes("ghbdtn233"));
        }

        [Fact]
        public void Test_GetReversed()
        {
            Assert.Equal("Hello, world!", RicksMercilessEncryptor.GetReversed("!dlrow ,olleH"));
        }

        [Fact]
        public void Test_InverceCase()
        {
            Assert.Equal("AbsoLUTe1y N0RmAl tEXt", RicksMercilessEncryptor.InverseCase("aBSOlutE1Y n0rMaL TexT"));
        }

        [Fact]
        public void Test_ShiftInc()
        {
            Assert.Equal("TextforteST233", RicksMercilessEncryptor.ShiftInc("SdwsenqsdRS122"));
        }

        [Fact]
        public void Test_GetUsedObjects()
        {
            String testText = "Its test, its object - ¶1234:0000¶ \n" +
                              "its test with object in comment //¶1234:5341¶, that can't be found\n" +
                              "Its object in the middle - ¶2303:2000¶" +
                              "And this is test with /* multiline comment \n" +
                              "¶1004:0010¶ //¶7896:0150¶ ¶1234:3975¶\n" +
                              "*/\n" +
                              "And this is object in the end - ¶1220:2330¶";
            long[] expected = {12340000, 23032000, 12202330};
            Assert.Equal(expected, RicksMercilessEncryptor.GetUsedObjects(testText));
        }
    }
}