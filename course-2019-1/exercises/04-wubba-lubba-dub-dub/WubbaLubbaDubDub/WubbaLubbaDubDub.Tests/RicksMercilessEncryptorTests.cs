using System;
using System.Collections.Immutable;
using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Fact]
        public void Test()
        {
            string line = "HEllo my dear";
            string[] p = line.SplitToWords();
            Assert.Equal(p, line.SplitToWords());
        }

        [Fact]
        public void TestHalf()
        {
            string line = "hubahuba";
            string p = line.GetLeftHalf();
            Assert.Equal(p, line.GetRightHalf());
        }

        [Fact]
        public void TestReplace()
        {
            string line = "hubahuba";
            string p = line.Replace("ba","hu");
            Assert.Equal(p, "huhuhuhu");
        }

        [Fact]
        public void TestInverseCase()
        {
            string line = "HuBaHuBa";
            string p = line.InverseCase();
            Assert.Equal(p, "hUbAhUbA");
        }

        [Theory]
        [InlineData("0000:0001 // 0000:0000 0000:0002 \n", new[] { 1L })]
        [InlineData("0000:0005 /* 0000:0000 */ 0000:0002", new[] { 5L, 2L })]
        public void TestGetUsedObjects(string lhs, long[] rhs)
        {
            Assert.Equal(lhs.GetUsedObjects(), rhs);
        }



    }
}
