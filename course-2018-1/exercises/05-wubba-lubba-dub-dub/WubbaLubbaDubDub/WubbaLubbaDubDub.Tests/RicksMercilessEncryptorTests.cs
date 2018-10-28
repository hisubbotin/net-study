using System;
using System.Linq;
using System.Net.Mime;
using System.Text.RegularExpressions;
using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests {
        [Fact]
        private void TestSplitToLines() {
            string[] split1 = {"abc", "def", "ghi"};
            Assert.Equal(split1, "abc\ndef\nghi".SplitToLines());

            string[] split2 = {"abc", "def", "ghi"};
            Assert.Equal(split2, "abc\n\ndef\nghi".SplitToLines());


            string[] split3 = {"abc", "def", "ghi"};
            Assert.Equal(split3, "\nabc\n\ndef\nghi\n".SplitToLines());

            string[] split4 = {"abcdefghi"};
            Assert.Equal(split4, "abcdefghi".SplitToLines());
        }

        [Fact]
        private void TestSplitToWords() {
            string[] split1 = {"abc", "def", "ghi"};
            Assert.Equal(split1, "abc def ghi".SplitToWords());

            string[] split2 = {"abc", "def", "ghi"};
            Assert.Equal(split2, "abc  def ghi".SplitToWords());


            string[] split3 = {"abc", "def", "ghi"};
            Assert.Equal(split3, " abc  def ghi ".SplitToWords());

            string[] split4 = {"abcdefghi"};
            Assert.Equal(split4, "abcdefghi".SplitToWords());
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("a", "")]
        [InlineData("ab", "a")]
        private void TestGetLeftHalf(string source, string target) {
            Assert.Equal(target, source.GetLeftHalf());
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("a", "a")]
        [InlineData("ab", "b")]
        private void TestGetRightHalf(string source, string target) {
            Assert.Equal(target, source.GetRightHalf());
        }
        
        [Theory]
        [InlineData("", "x", @"", "")]
        [InlineData("a", "a", @"b", "b")]
        [InlineData("a", "b", @"c", "a")]
        [InlineData("a", "b", @"c", "a")]
        [InlineData("a", "b", @"c", "a")]
        [InlineData("ababa", "aba", @"bab", "babba")]
        private void TestReplace(string source, string before, string @after, string target) {
            Assert.Equal(target, source.ReplaceWith(before, @after));
        }
        
        [Theory]
        [InlineData("october", "\\u006F\\u0063\\u0074\\u006F\\u0062\\u0065\\u0072")]
        [InlineData("2018", "\\u0032\\u0030\\u0031\\u0038")]
        private void TestCharsToCodes(string source, string target) {
            Assert.Equal(target, source.CharsToCodes());
        }
        
        [Theory]
        [InlineData("", "")]
        [InlineData("a", "a")]
        [InlineData("ab", "ba")]
        private void TestGetReversed(string source, string target) {
            Assert.Equal(target, source.GetReversed());
        }
        
        [Theory]
        [InlineData("", "")]
        [InlineData("abbyy", "ABBYY")]
        [InlineData("AbByY", "aBbYy")]
        private void TestInverseCase(string source, string target) {
            Assert.Equal(target, source.InverseCase());
        }
        
        [Theory]
        [InlineData("", "")]
        [InlineData("string", "tusjoh")]
        [InlineData("12345", "23456")]
        private void TestShiftInc(string source, string target) {
            Assert.Equal(target, source.ShiftInc());
        }
        
        [Theory]
        [InlineData("0:0 // 0:1 /* 0:2 \n 0:3 // 0:4 */ 0:5", "0:0  0:3 ")]
        [InlineData("0:0 /* 0:1 \n 0:2 // 0:3 */ 0:4", "0:0  0:4")]
        private void TestRemoveComments(string text, string target) {
            Assert.Equal(target, text.RemoveComments());
        }

        [Theory]
        [InlineData("0000:0000 // 0000:0001 /* 0000:0002 \n 0000:0003 // 0000:0004 */ 0000:0005", new[] {0L, 3L})]
        [InlineData("0000:0000 /* 0000:0001 \n 0000:0002 // 0000:0003 */ 0000:0004", new[] {0L, 4L})]
        private void TestGetUsedObjects(string text, long[] ids) {
            Assert.Equal(ids, text.GetUsedObjects().ToArray());
        }
    }
}
