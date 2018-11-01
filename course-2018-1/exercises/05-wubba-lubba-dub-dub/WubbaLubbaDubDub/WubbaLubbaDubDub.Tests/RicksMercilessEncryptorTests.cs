using System;
using System.Collections.Immutable;
using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Theory]
        [InlineData("hello\n\nmy\ndear", new[] {"hello", "my", "dear"})]
        public void Test_SplitToLines(string input, string[] output)
        {
            Assert.Equal(input.SplitToLines(), output);
        }
        
        [Theory]
        [InlineData("hello,  my dear", new[] {"hello", "my", "dear"})]
        public void Test_SplitToWords(string input, string[] output)
        {
            Assert.Equal(input.SplitToWords(), output);
        }
        
        [Theory]
        [InlineData("hello", "he")]
        [InlineData("hola", "ho")]
        public void Test_GetLeftHalf(string input, string output)
        {
            Assert.Equal(input.GetLeftHalf(), output);
        }
        
        [Theory]
        [InlineData("hello", "llo")]
        [InlineData("hola", "la")]
        public void Test_GetRightHalf(string input, string output)
        {
            Assert.Equal(input.GetRightHalf(), output);
        }
        
        [Theory]
        [InlineData("hello my dear helen", "he", "su", "sullo my dear sulen")]
        public void Test_Replace(string input, string old, string @new, string output)
        {
            Assert.Equal(input.Replace(old, @new), output);
        }
        
        [Theory]
        [InlineData("hello", "\\u0068\\u0065\\u006c\\u006c\\u006f")]
        public void Test_CharsToCodes(string input, string output)
        {
            Assert.Equal(input.CharsToCodes(), output);
        }
        
        [Theory]
        [InlineData("hello", "olleh")]
        [InlineData("atata", "atata")]
        public void Test_GetReversed(string input, string output)
        {
            Assert.Equal(input.GetReversed(), output);
        }
        
        [Theory]
        [InlineData("HeLlo My DeAr", "hElLO mY dEaR")]
        public void Test_InverseCase(string input, string output)
        {
            Assert.Equal(input.InverseCase(), output);
        }
        
        [Theory]
        [InlineData("abracadabra", "bcsbdbebcsb")]
        public void Test_ShiftInc(string input, string output)
        {
            Assert.Equal(input.ShiftInc(), output);
        }
        
        [Theory]
        [InlineData("H ¶00F0:0000¶ e /* rtgtrg \n rth¶0000:0000¶grtgrt*/ gfgfgd // gfbdf\n fd¶0000:000F¶fdg", 
            new[] {15728640L, 15L})]
        public void Test_GetUsedObjects(string input, long[] output)
        {
            Assert.Equal(input.GetUsedObjects(), output);
        }
    }
}
