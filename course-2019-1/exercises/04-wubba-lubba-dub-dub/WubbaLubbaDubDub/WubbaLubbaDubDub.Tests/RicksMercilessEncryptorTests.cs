using System;
using Xunit;
using System.Collections.Immutable;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Fact]
        public void Test()
        {
            string line = "izvinite ya probila dealines";
            string[] p = line.SplitToWords();
            Assert.Equal(p, line.SplitToWords());
        }

        [Fact]
        public void TestSplitToLines()
        {
            string text = "this is\nlupa\nthis is\npupa";
            string[] result = new[] { "this is", "lupa", "this is", "pupa"};
            Assert.Equal(text.SplitToLines(), result);
        }

         public void TestSplitToWords(string test, string[] result)
        {
            Assert.Equal(test.SplitToWords(), result);
        }

        [Fact]
        public void TestHalf()
        {
            string line = "cheburek";
            string p = line.GetLeftHalf();
            Assert.Equal(p, line.GetRightHalf());
        }

        [Fact]
        public void TestReplace()
        {
            string line = "lupa poluchil za sebya";
            string p = line.Replace("sebya","pupu");
            Assert.Equal(p, "lupa poluchil za pupu");
        }

        [Fact]
        public void TestInverseCase()
        {
            string line = "HuBaHuBa";
            string p = line.InverseCase();
            Assert.Equal(p, "hUbAhUbA");
        }
        
    }
}
