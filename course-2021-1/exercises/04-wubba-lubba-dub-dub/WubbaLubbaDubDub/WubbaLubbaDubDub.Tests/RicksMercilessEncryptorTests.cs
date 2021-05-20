using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Xunit;
using WubbaLubbaDubDub;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Fact]
        public void SplitToLinesTest()
        {
            string[] expected = new[] {"line 1", "line2"};
            Assert.Equal(RicksMercilessEncryptor.SplitToLines("line 1\nline2"), expected);
        }

        [Fact]
        public void SplitToWordsTest()
        {
            string[] expected = new[] {"word", "and", "word", "and", "word"};
            Assert.Equal(RicksMercilessEncryptor.SplitToWords("word and word and word"), expected);
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
            Assert.Equal(RicksMercilessEncryptor.Replace("baccabbaccabbac", "bac", "cab"), "cabcabcabcabcab");
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
            Assert.Equal(RicksMercilessEncryptor.InverseCase("WorD"), "wORd");
        }
        
        [Fact]
        public void ShiftIncTest()
        {
            Assert.Equal(RicksMercilessEncryptor.ShiftInc("АБВ"), "БВГ");
        }

        [Fact]
        public void GetUsedObjectsTest()
        {
            List<long> expected = new List<long>();
            expected.Add(305402420);
            Assert.Equal(RicksMercilessEncryptor.GetUsedObjects("1234:1234"), expected.ToImmutableList());
            Assert.Equal(RicksMercilessEncryptor.GetUsedObjects("1234:1234 //some stuff 1111:1111"), expected.ToImmutableList());
            Assert.Equal(RicksMercilessEncryptor.GetUsedObjects("1234:1234 /**/some stuff 1111:1111 \n 1212:1212 \n /**/"), 
                expected.ToImmutableList());
        }
    }
}
