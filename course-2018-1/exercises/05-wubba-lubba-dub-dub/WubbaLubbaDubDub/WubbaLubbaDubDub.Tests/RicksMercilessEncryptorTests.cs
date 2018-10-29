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

    }
}
