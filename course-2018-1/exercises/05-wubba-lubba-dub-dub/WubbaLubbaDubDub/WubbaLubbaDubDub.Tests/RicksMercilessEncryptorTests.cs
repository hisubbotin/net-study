using System;
using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Theory]
        [InlineData("rhkgf\nishto\nklewhf\n_", new[] { "rhkgf", "ishto", "klewhf", "_" })]
        public void TestSplitToLines(string s,string[] gt)
        {
            Assert.Equal(s.SplitToLines(), gt);
        }

        [Theory]
        [InlineData("rhkgf\nishto\nklewhf\n_", new[] { "rhkgf", "ishto", "klewhf", "_" })]
        public void TestSplitToWords(string s, string[] gt)
        {
            Assert.Equal(s.SplitToWords(), gt);
        }

        [Theory]
        [InlineData("12345678", "1234")]
        [InlineData("123456789", "1234")]
        public void TestGetLeftHalf(string s, string gt)
        {
            Assert.Equal(s.GetLeftHalf(), gt);
        }

        [Theory]
        [InlineData("12345678", "5678")]
        [InlineData("123456789", "56789")]
        public void TestGetRightHalf(string s, string gt)
        {
            Assert.Equal(s.GetRightHalf(), gt);
        }

        [Theory]
        [InlineData("12345678", "1234", "0", "05678")]
        [InlineData("123456789", "12345", "0", "06789")]
        public void TestReplace(string s, string old, string str_new, string gt)
        {
            Assert.Equal(RicksMercilessEncryptor.Replace(s, old, str_new), gt);
        }
        
        [Theory]
        [InlineData("A", @"\u0041")]
        public void TestCharsToCodes(string s, string gt)
        {
            Assert.Equal(s.CharsToCodes(), gt);
        }

        [Theory]
        [InlineData("asd", "dsa")]
        public void TestGetReversed(string s, string gt)
        {
            Assert.Equal(s.GetReversed(), gt);
        }

        [Theory]
        [InlineData("asd", "dsa")]
        public void TestInverseCase(string s, string gt)
        {
            Assert.Equal(s.GetReversed(), gt);
        }

        [Theory]
        [InlineData("a-+1\t", "b.,2\n")]
        public void TestShiftInc(string s, string gt)
        {
            Assert.Equal(s.ShiftInc(), gt);
        }

        [Theory]
        [InlineData("7890:1234\n7890:1234", new long[] { 78901234 })]
        [InlineData("//0123:4567\n7890:1234", new long[] { 78901234 })]
        [InlineData("/*\n7890:1234\n*/\n0123:4567\n asd 8901:2345", new long[] { 1234567, 89012345 })]
        public static void Test_GetUsedObjects(string s, long[] ans)
        {
            Assert.Equal(ans, s.GetUsedObjects());
        }
    }
}
