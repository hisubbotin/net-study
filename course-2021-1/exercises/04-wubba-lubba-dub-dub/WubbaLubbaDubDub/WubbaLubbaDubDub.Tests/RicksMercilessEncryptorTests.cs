using Xunit;
using System.Collections.Generic;
using System.Collections.Immutable;


namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Fact]
        public void SplitToLinesTest()
        {
            var expected = new string[] {"for i in range(10):", "   print(i)"};
            Assert.Equal(RicksMercilessEncryptor.SplitToLines("for i in range(10):\n   print(i)"), expected);
        }

        [Fact]
        public void SplitToWordsTest()
        {
            var expected = new string[] {"", "My", "name", "is", "C", ""};
            Assert.Equal(RicksMercilessEncryptor.SplitToWords("! My name is C#!"), expected);
        }

        [Fact]
        public void GetLeftHalfTest()
        {
            Assert.Equal(RicksMercilessEncryptor.GetLeftHalf("string"), "str");
            Assert.Equal(RicksMercilessEncryptor.GetLeftHalf("strings"), "str");
        }

        [Fact]
        public void GetRightHalfTest()
        {
            Assert.Equal(RicksMercilessEncryptor.GetRightHalf("string"), "ing");
            Assert.Equal(RicksMercilessEncryptor.GetRightHalf("strings"), "ings");
        }

        [Fact]
        public void ReplaceTest()
        {
            Assert.Equal(RicksMercilessEncryptor.Replace("Svyatoslav", "a", "#"), "Svy#tosl#v");
        }

        [Fact]
        public void CharsToCodesTest()
        {
            Assert.Equal(RicksMercilessEncryptor.CharsToCodes("АБВ"), "\\u0410\\u0411\\u0412");
        }

        [Fact]
        public void GetReversedTest()
        {
            Assert.Equal(RicksMercilessEncryptor.GetReversed("string"), "gnirts");
        }

        [Fact]
        public void InverseCaseTest()
        {
            Assert.Equal(RicksMercilessEncryptor.InverseCase("SvyatoSlav"), "sVYATOsLAV");
        }

        [Fact]
        public void ShiftIncTest()
        {
            Assert.Equal(RicksMercilessEncryptor.ShiftInc("abc"), "bcd");
        }

        [Fact]
        public void GetUsedObjectsTest()
        {
            var expected = (new List<long>() {12341234}).ToImmutableList();
            Assert.Equal(RicksMercilessEncryptor.GetUsedObjects("¶1234:1234¶"), expected);
            Assert.Equal(RicksMercilessEncryptor.GetUsedObjects("¶1234:1234¶ //some stuff ¶1111:1111¶"), 
                expected);
            Assert.Equal(RicksMercilessEncryptor.GetUsedObjects("¶1234:1234¶ /*some stuff ¶1111:1111¶ \n ¶1212:1212¶*/"), 
                expected);
        }
    }
}
