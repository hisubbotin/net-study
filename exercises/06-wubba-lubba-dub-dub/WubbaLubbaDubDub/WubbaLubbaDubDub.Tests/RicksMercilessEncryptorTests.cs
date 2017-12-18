using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Assert = Xunit.Assert;

namespace WubbaLubbaDubDub.Tests
{
    [DeploymentItem("TestText.txt")]
    public class RicksMercilessEncryptorTests
    {
        [Fact]
        public void Test_SplitToLines()
        {
            const string text = "1\n2\n3\n4\n5\n";
            var lines = text.SplitToLines();
            Assert.Equal(6, lines.Length);
        }

        [Fact]
        public void Test_SplitToWords()
        {
            string text = "s,  two- three      a\nbb\n";
            string[] actual = text.SplitToWords();
            string[] expected =
            {
                "s", "two", "three", "a", "bb"
            };

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void Test_GetReversed()
        {
            Assert.Equal("123_asd", "dsa_321".GetReversed());
        }

        [Fact]
        public void Test_Replace()
        {
            Assert.Equal("replace that, that and that with that",
                "replace this, this and this with that".ReplaceExt("this", "that"));
        }

        [Theory]
        [InlineData("\u0061\u0062\u0063", @"\u0061\u0062\u0063")]
        [InlineData("\uFFFF", @"\uFFFF")]
        [InlineData("", "")]
        public void Test_CharsToCodes(string s, string expected)
        {
            string actual = s.CharsToCodes();
            Assert.Equal(expected, actual);

        }

        [Theory]
        [InlineData("even", "ev")]
        [InlineData("odd", "o")]
        [InlineData("o", "")]
        [InlineData("", "")]
        public void Test_GetLeftHalf(string s, string expected)
        {
            Assert.Equal(expected, s.GetLeftHalf());
        }

        [Theory]
        [InlineData("even", "en")]
        [InlineData("odd", "dd")]
        [InlineData("o", "o")]
        [InlineData("", "")]
        public void Test_GetRightHalf(string s, string expected)
        {
            Assert.Equal(expected, s.GetRightHalf());
        }

        [Theory]
        [InlineData("lower", "LOWER")]
        [InlineData("UPPER", "upper")]
        [InlineData("MiXeD", "mIxEd")]
        [InlineData("", "")]
        public void Test_InverseCase(string s, string expected)
        {
            Assert.Equal(expected, s.InverseCase());
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("abc", "bcd")]
        [InlineData("\uFFFF", "\u0000")]
        public void Test_ShiftInc(string s, string expected)
        {
            Assert.Equal(expected, s.ShiftInc());   
        }

        [Fact]
        public void Test_GetUsedObjects()
        {
            const string text = @"first :¶0000:0001¶ // ignore ¶000F:A000¶
/*
also ¶AAAA:02BB¶
*/
some¶AAAA:BBBB¶text
/*
// also ¶AAAA:12BB¶
*/
incorrect ¶A100500:12aaaaaBB¶
";
            var expected = new long[]{ 1, 2863315899};
            Assert.Equal(expected, text.GetUsedObjects().ToArray());
        }
    }
}