using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Theory]
        [InlineData("This\nis\na\ntest", new[] { "This", "is", "a", "test" })]
        public void TestSplitToLines_ReturnsCorrectValue(string text, string[] lines)
        {
            Assert.Equal(text.SplitToLines(), lines);
        }

        [Theory]
        [InlineData("This is a simple test", new[] {"This", "is", "a", "simple", "test"})]
        public void TestSplitToWords_ReturnsCorrectValue(string line, string[] words)
        {
            Assert.Equal(line.SplitToWords(), words);
        }

        [Theory]
        [InlineData("test", "te")]
        public void TestGetLeftHalf_ReturnsCorrectValue(string line, string leftHalf)
        {
            Assert.Equal(line.GetLeftHalf(), leftHalf);
        }

        [Theory]
        [InlineData("test", "st")]
        public void TestGetRightHalf_ReturnsCorrectValue(string line, string rightHalf)
        {
            Assert.Equal(line.GetRightHalf(), rightHalf);
        }

        [Theory]
        [InlineData("te__", "test")]
        public void TestReplace_ReturnsCorrectValue(string line, string changedLine)
        {
            Assert.Equal(RicksMercilessEncryptor.Replace(line, "__", "st"), changedLine);
        }

        [Theory]
        [InlineData("abc", "\\u0061\\u0062\\u0063")]
        public void TestCharsToCodes_ReturnsCorrectValue(string line, string lineOfCodes)
        {
            Assert.Equal(line.CharsToCodes(), lineOfCodes);
        }

        [Theory]
        [InlineData("test", "tset")]
        public void TestGetReversed_ReturnsCorrectValue(string line, string reversedLine)
        {
            Assert.Equal(line.GetReversed(), reversedLine);
        }

        [Theory]
        [InlineData("TeSt", "tEsT")]
        public void TestInverseCase_ReturnsCorrectValue(string line, string inversedLine)
        {
            Assert.Equal(line.InverseCase(), inversedLine);
        }

        [Theory]
        [InlineData("abc", "bcd")]
        public void TestShiftInc_ReturnsCorrectValue(string line, string shiftedLine)
        {
            Assert.Equal(line.ShiftInc(), shiftedLine);
        }

        [Theory]
        [InlineData("//Well \n /* it's \n stolen AAAA:5555 \n */ BBBB:4444", new[] { 3149612100L })]
        public void TestGetUsedObjects_ReturnsCorrectValue(string line, long[] ids)
        {
            Assert.Equal(line.GetUsedObjects(), ids);
        }
    }
}
