using System;
using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Theory]
        [InlineData("petr\nfeels\nlyoubovno\ni\nprelstivo", new[] { "petr", "feels" , "lyoubovno","i","prelstivo"})]
        public void SplitLinesTest(string text, string[] res)
        {
            Assert.Equal(text.SplitToLines(), res);
        }


        [Theory]
        [InlineData("petr  feels  lyoubovno  i nprelstivo", new[] { "petr", "feels", "lyoubovno", "i", "prelstivo" })]
        public void SplitWordsTest(string text, string[] res)
        {
            Assert.Equal(text.SplitToWords(), res);
        }


        [Theory]
        [InlineData("left right", "left ")]
        public void GetLeftHalfTest(string text, string res)
        {
            Assert.Equal(text.GetLeftHalf(), res);
        }

        [Theory]
        [InlineData("left right", "right")]
        public void GetRightHalfTest(string text, string res)
        {
            Assert.Equal(text.GetRightHalf(), res);
        }


        [Theory]
        [InlineData()]
        public void Test(string text, string res)
        {
            Assert.Equal(text , res);
        }


        [Theory]
        [InlineData("December is the best of all, snowflakes dance, snowflakes fall", "snowflakes", "leaves",
            "December is the best of all, leaves dance, leaves fall")]
        public void ReplaceTest(string text, string old, string @new, string res)
        {
            Assert.Equal(RicksMercilessEncryptor.Replace(text, old, @new), res);
        }


        [Theory]
        [InlineData("Happy New Year! Happy New Year!", "!raeY weN yppaH !raeY weN yppaH")]
        public void GetReversedTest(string text, string res)
        {
            Assert.Equal(text.GetReversed(), res);
        }


        [Theory]
        [InlineData("May we all have a vision now and then" , "mAY WE ALL HAVE A VISION NOW AND THEN")]
        public void InvertCaseTest(string text, string res)
        {
            Assert.Equal(text.InverseCase(), res);
        }

        [Theory]
        [InlineData("Of a world where every neighbor is a friend", "Pg!b!xpsme!xifsf!fwfsz!ofjhicps!jt!b!gsjfoe")]
        public void ShiftIncTest(string text, string res)
        {
            Assert.Equal(text.ShiftInc(), res);
        }

        [Theory]
        [InlineData("0000:0001,  May we all have our hopes, our will to try", new[] {1L})]
        [InlineData("0000:0002, //If we don't we might as well lay down and die", new[] { 2L })]
        [InlineData("0000:0003, /* You and I*/ ", new[] { 3L })]
        public void DetUsedObjectTest(string text, long[] res)
        {
            Assert.Equal(text.GetUsedObjects(), res);
        }
        
    }
    
}
