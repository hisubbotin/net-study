using System;
using System.Collections.Immutable;
using System.Linq;
using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        
        [Theory]
        [InlineData("Something\nto be splitted on\ndifferent\nlines",
        "Something", "to be splitted on", "different", "lines")]
        public void TestSplitToLines(string input, params string[] answer)
        {
            Assert.Equal(input.SplitToLines(), answer);
        }


        [Theory]
        [InlineData("Something \n to be splitted   on\ndifferent      \nlines",
            "Something", "to", "be", "splitted", "on", "different", "lines")]
        public void TestSplitToWords(string input, params string[] words)
        {
            Assert.Equal(input.SplitToWords(), words);
        }
        
        [Theory]
        [InlineData("12345", "123")]
        [InlineData("1234", "12")]
        public void TestGetLeftHalf(string input, string output)
        {
            Assert.Equal(input.GetLeftHalf(), output);
        }
        
        [Theory]
        [InlineData("12345", "345")]
        [InlineData("1234", "34")]
        public void TestGetRightHalf(string input, string output)
        {
            Assert.Equal(input.GetRightHalf(), output);
        }
        
        
        [Theory]
        [InlineData("12345", "1", "2", "22345")]
        [InlineData("Lorem ipsum ipsum lorem", "ipsum", "Lorem", "Lorem Lorem Lorem lorem")]
        public void TestReplace(string input, string toDel, string replacement, string output)
        {
            Assert.Equal(
                WubbaLubbaDubDub.RicksMercilessEncryptor.Replace(input, toDel, replacement), 
                output);
        }
        
        [Theory]
        [InlineData("STUVVV", @"\u0053\u0054\u0055\u0056\u0056\u0056")]
        [InlineData("$©λ", @"\u0024\u00A9\u03BB")]
        public void TestCharsToCodes(string input, string output)
        {
            Assert.Equal(input.CharsToCodes(), output);
        }
        
        
        [Theory]
        [InlineData("STUVVV", "VVVUTS")]
        [InlineData("Аргентина манит негра", "арген тинам анитнегрА")]
        public void TestGetReversed(string input, string output)
        {
            Assert.Equal(input.GetReversed(), output);
        }
        
        [Theory]
        [InlineData("STUVVVasas11", "stuvvvASAS11")]
        [InlineData("Аргентина манит негра", "аРГЕНТИНА МАНИТ НЕГРА")]
        public void TestInverseCase(string input, string output)
        {
            Assert.Equal(input.InverseCase(), output);
        }
        
        [Theory]
        [InlineData(@"STUUU", @"TUVVV")]
        [InlineData(@"εξΓ", @"ζοΔ")]
        public void TestShiftInc(string input, string output)
        {
            Assert.Equal(input.ShiftInc(), output);
        }

        [Theory]
        [InlineData(" 0:1 sdfsdfsdf // saddasd\n sadasda \n  0:1 /* sfds sf     0:1         0:2    */ 0:3 0:2 0:5 0:38 0:39  ", 1L, 2L, 3L, 5L, 38L, 39L)]
        [InlineData("//dfsdf sdf sdf sdf sdfs sdfsdfsdf  \n   0:2     \n sd /* 0:1  */     :    ", 2L)]
        public void TestGetUsedObjects(string input, params long[] array)
        {
            Assert.Equal(input.GetUsedObjects().ToImmutableSortedSet().ToArray(), array);
        }
    }
}
