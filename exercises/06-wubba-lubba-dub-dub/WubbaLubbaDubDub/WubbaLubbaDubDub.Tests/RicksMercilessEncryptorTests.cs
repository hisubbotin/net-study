using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Theory]
        [InlineData("Some simple text\nwithout windows\n\\n"
            , new[] {"Some simple text", "without windows", "\\n"})]
        [InlineData("Another text\r\nwith windows\r\nlinebreaks"
            , new[] {"Another text\r", "with windows\r", "linebreaks"})]
        public void TestSplitToLines(string text, string[] result)
        {
            Assert.Equal(result, text.SplitToLines());
        }
        
        [Theory]
        [InlineData("Some simple text\nwithout windows\n\\n"
            , new[] {"Some", "simple", "text", "without", "windows", "n"})]
        [InlineData("Another text\r\nwith windows\r\nlinebreaks"
            , new[] {"Another", "text", "with", "windows", "linebreaks"})]
        [InlineData("Not so trivial text, with\t tabs,   commas and many spaces\t\t\n"
            , new[] {"Not", "so", "trivial", "text", "with", "tabs", "commas", "and", "many", "spaces"})]
        public void TestSplitToWords(string text, string[] result)
        {
            Assert.Equal(result, text.SplitToWords());
        }
        
        [Theory]
        [InlineData("Some string", "Some ")]
        [InlineData("", "")]
        [InlineData("!?", "!")]
        public void TestGetLeftHalf(string text, string result)
        {
            Assert.Equal(result, text.GetLeftHalf());
        }
        
        [Theory]
        [InlineData("Some string", "string")]
        [InlineData("", "")]
        [InlineData("!?", "?")]
        public void TestGetRightHalf(string text, string result)
        {
            Assert.Equal(result, text.GetRightHalf());
        }

        [Theory]
        [InlineData("Very good text, replace all `, ` to `123`", ", ", "123"
            , "Very good text123replace all `123` to `123`")]
        [InlineData("Finally replace\r\nall windows\r\nlinebreaks", "\r\n", "\n"
            , "Finally replace\nall windows\nlinebreaks")]
        public void TestReplace(string text, string old, string @new, string result)
        {
            Assert.Equal(result, RicksMercilessEncryptor.Replace(text, old, @new));
        }
        
        [Theory]
        [InlineData("Text", @"\u0054\u0065\u0078\u0074")]
        [InlineData("", "")]
        [InlineData("123", @"\u0031\u0032\u0033")]
        public void TestCharsToCodes(string text, string result)
        {
            Assert.Equal(result, text.CharsToCodes());
        }

        [Theory]
        [InlineData("12345", "54321")]
        [InlineData("abacaba", "abacaba")]
        public void TestGetReversed(string text, string result)
        {
            Assert.Equal(result, text.GetReversed());
        }
        
        [Theory]
        [InlineData("Just another interesting text with\r\nwindows \r\nlinebreaks"
            , "jUST ANOTHER INTERESTING TEXT WITH\r\nWINDOWS \r\nLINEBREAKS")]
        [InlineData("simPlel111l", "SIMpLEL111L")]
        public void TestInverseCase(string text, string result)
        {
            Assert.Equal(result, text.InverseCase());
        }
        
        [Theory]
        [InlineData("abacaba", "bcbdbcb")]
        [InlineData("\u0000\u1111", "\u0001\u1112")]
        public void TestShiftInc(string text, string result)
        {
            Assert.Equal(result, text.ShiftInc());
        }
        
        [Theory]
        [InlineData("0000:0001, // first comment 1111:1111\n"
            , new[] {1L})]
        [InlineData("asd bqwd asd 0001:0000 /*1123:1231\n//1234:1234\n*/"
            , new[] {65536L})]
        public void TestGetUsedObjects(string text, long[] result)
        {
            Assert.Equal(result, text.GetUsedObjects());
        }
    }
}
