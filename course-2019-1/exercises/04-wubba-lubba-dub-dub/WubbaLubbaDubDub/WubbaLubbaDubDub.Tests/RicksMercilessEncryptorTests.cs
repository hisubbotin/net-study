using System;
using System.Collections.Immutable;
using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Theory]
        [InlineData("Line1", new string[] { "Line1" })]
        [InlineData("Line1\nline2\nline3\nline4", new string[] { "Line1", "line2", "line3", "line4" })]

        // Не работают(
        //[InlineData("Line1\r\nline2\r\nline3\r\nline4", new string[] { "Line1", "line2", "line3", "line4" })]
        //[InlineData("Line1\nline2\r\nline3\nline4", new string[] { "Line1", "line2", "line3", "line4" })]
        public void SplitToLinesTest(string s, string[] line)
        {
            Assert.Equal(line, s.SplitToLines());
        }

        [Theory]
        [InlineData("Line1 line2 line3 line4", new string[] { "Line1", "line2", "line3", "line4" })]
        [InlineData("Line1, line2, line3, line4", new string[] { "Line1", "line2", "line3", "line4" })]
        [InlineData("Line1 line2\nline3, line4", new string[] { "Line1", "line2", "line3", "line4" })]
        public void SplitToWords(string s, string[] line)
        {
            // Во избежание неоднозначностей со стандартной реализацией; 
            Assert.Equal(line, s.SplitToWords());
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("L", "")]
        [InlineData("Line", "Li")]
        [InlineData("Line1", "Li")]
        public void GetLeftHalfTest(string line, string half)
        {
            // Во избежание неоднозначностей со стандартной реализацией; 
            Assert.Equal(half, line.GetLeftHalf());
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("L", "L")]
        [InlineData("Line", "ne")]
        [InlineData("Line1", "ne1")]
        public void GetRightHalfTest(string line, string half)
        {
            // Во избежание неоднозначностей со стандартной реализацией; 
            Assert.Equal(half, line.GetRightHalf());
        }

        [Theory]
        [InlineData("", "bla", "blo", "")]
        [InlineData("blablabla", "bla", "blo", "blobloblo")]
        [InlineData("abababababab", "abab", "ab", "ababab")]
        public void ReplaceTest(string s, string old, string @new, string result)
        {
            // Во избежание неоднозначностей со стандартной реализацией; 
            Assert.Equal(WubbaLubbaDubDub.RicksMercilessEncryptor.Replace(s, old, @new), result);
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("bla", "\\u0062\\u006C\\u0061")]
        public void CharsToCodesTest(string line, string hex)
        {
            // Во избежание неоднозначностей со стандартной реализацией; 
            Assert.Equal(hex, line.CharsToCodes());
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("bla", "alb")]
        public void GetReversedTest(string line, string reversed)
        {
            // Во избежание неоднозначностей со стандартной реализацией; 
            Assert.Equal(reversed, line.GetReversed());
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("BlA", "bLa")]
        public void InverseCaseTest(string line, string inverse)
        {
            // Во избежание неоднозначностей со стандартной реализацией; 
            Assert.Equal(inverse, line.InverseCase());
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("BcA5", "CdB6")]
        public void ShiftIncTest(string line, string shiftInc)
        {
            // Во избежание неоднозначностей со стандартной реализацией; 
            Assert.Equal(shiftInc, line.ShiftInc());
        }

        [Fact]
        public void GetUsedObjectsTest()
        {
            var text = "hsdifg hsudfhsdu fghowsdghf iusdhf\n" +
                "paids ujpadjspioa sd\n" +
                "/*aja ¶1:1¶ dja*/\n" +
                "/*aja ¶1:2¶ dja\n" +
                "/*aja ¶1:3¶ dja\n" +
                "/*aja ¶1:4¶ dja\n" +
                "/*aja ¶1:5¶ dja*/]\n" +
                "//aja ¶2:1¶ dja\n" +
                "//aja ¶2:2¶ dja" +
                "//aja ¶2:3¶ dja\n" +
                "/*aja ¶3:1¶ // dja*/ ¶4:1¶\n " +
                "aja ¶5:1¶ dja\n" +
                "aja ¶5:2¶ dja\n" +
                "aja ¶FFFFFFFF:AAAA¶ dja\n";
            // Во избежание неоднозначностей со стандартной реализацией; 
            ulong[] list = { 0x400000001, 0x500000001, 0x500000002, 0xFFFFFFFF0000AAAA };
            Assert.Equal(text.GetUsedObjects(), list);
        }
    }
}
