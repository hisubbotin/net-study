using System;
using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Fact]
        public void TestAll()
        {
            var result = "bla bla wed\n qwe qwe\n".SplitToWords();
            Assert.Equal(5, result.Length);
            
            Assert.Equal("\\u0031", "1".CharsToCodes());
            
        }
    }
}
