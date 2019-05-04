using System;
using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {

        [Fact]
        public void TestSplitToLines()
        {
            string text = "this is\na multiline\nexample\ntext";
            string[] result = new[] { "this is", "a multiline", "example", "text"};
            Assert.Equal(text.SplitToLines(), result);
        }

        [Fact]
        public void TestSplitToWords()
        {
            string line = "this is a multiword line";
            string[] result = new[] {"this", "is", "a",  "multiword", "line" };
            Assert.Equal(line.SplitToWords(), result);
        }

        [Fact]
        public void TestGetHalf()
        {
            string line = "1234";
            Assert.Equal(line.GetLeftHalf(), "12");
            Assert.Equal(line.GetRightHalf(), "12");

            string lline = "12345";
            Assert.Equal(lline.GetLeftHalf(), "12");
            Assert.Equal(lline.GetRightHalf(), "123");
        }

        [Fact]
        public void TestReplace()
        {
            string s = "1234";
            Assert.Equal(s.Replace("2", "abra cadabra"), "1abra cadabra34");
        }

        [Fact]
        public void TestCharsToCodes()
        {
            string s = "abra cadabra";
            string res = "\\u0061\\u0062\\u0072\\u0061\\u0020\\u0063\\u0061\\u0064\\u0061\\u0062\\u0072\\u0061";
            Assert.Equal(s.CharsToCodes(), res);
        }

        [Fact]
        public void TestGetReversed()
        {
            string s = "abra cadabra";
            string res = "arbadac arba";
            Assert.Equal(s.GetReversed(), res);
        }

        [Fact]
        public void TestInverseCase()
        {
            string s = "Abra CadabrA";
            string res = "aBRA cADABRa";
            Assert.Equal(s.InverseCase(), res);
        }

        [Fact]
        public void TestShiftInc()
        {
            string s = "abra cadabra";
            string res = "bcsb!dbebcsb";
            Assert.Equal(s.ShiftInc(), res);
        }

        [Fact]
        public void TestGetUsedObjects()
        {
            string s = @" start line
// comment 5678:4321
id 18FA:B11A /* comment 2 4685:9867 
1234:5678 abra cadabra */ 1234:5678 text";

            var res = new[] { 419082522L, 305419896L };
            Assert.Equal(s.GetUsedObjects(), res);
        }
    }
}
