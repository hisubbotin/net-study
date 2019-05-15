using System;
using Xunit;
using WubbaLubbaDubDub;
using System.Linq;
using System.Text.RegularExpressions;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {

        [Fact]
        public void TestSplitToLines()
        {
            string text = "aaa\n\n\nb\n";
            string[] splited_text = new string[] {"aaa", "", "", "b", ""};
            var splited_text2 = text.SplitToLines();
            Assert.True(splited_text.SequenceEqual(splited_text2));
        }

        [Fact]
        public void testSplitToWords()
        {
            string text = "aaa b!!!? caaac, \"da\"!m.";
            string[] splited_text = new string[] { "aaa", "b", "caaac", "da", "m" };
            var splited_text2 = text.SplitToWords();

            Assert.True(splited_text.SequenceEqual(splited_text2));
        }
        [Fact]
        public void testGetLeftHalf()
        {
            string text = "aaaa acaa";
            string half = "aaaa";
            var half2 = text.GetLeftHalf();

            Assert.True(half.Equals(half2));

            text = "aaaabbacaa";
            half = "aaaab";
            half2 = text.GetLeftHalf();

            Assert.True(half.Equals(half2));
        }

        [Fact]
        public void testGetRightHalf()
        {
            string text = "acaa aaaa";
            string half = "aaaa";
            var half2 = text.GetRightHalf();

            Assert.True(half.Equals(half2));

            text = "acaabbaaaa";
            half = "baaaa";
            half2 = text.GetRightHalf();

            Assert.True(half.Equals(half2));
        }

        [Fact]
        public void testReplace()
        {
            string text = "acaa aaaa";
            string old = "aaaa";
            string @new = "bbbb";
            var repl = text.Replace2(old, @new);

            Assert.True("acaa bbbb".Equals(repl));
        }

        [Fact]
        public void testCharsToCodes()
        {
            string text = "abc";
            var a = text.CharsToCodes();
            Assert.True(@"\u0061\u0062\u0063".Equals(a));
        }

        [Fact]
        public void testGetReversed()
        {
            string text = "abc";
            var a = text.GetReversed();
            Assert.True("cba".Equals(a));
        }
        [Fact]
        public void testInverseCase()
        {
            string text = "abcABC";
            var a = text.InverseCase();
            Assert.True("ABCabc".Equals(a));
        }

        [Fact]
        public void testShiftInc()
        {
            string text = "abc";
            var a = text.ShiftInc();
            Assert.True("bcd".Equals(a));
        }
        [Fact]
        public void testGetUsedObjects()
        {
        }

    }
}
