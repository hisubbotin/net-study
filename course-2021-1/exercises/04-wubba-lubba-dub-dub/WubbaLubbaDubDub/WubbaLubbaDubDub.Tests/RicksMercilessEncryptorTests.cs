using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Theory]
        [InlineData("йоу", new [] { "йоу" })]
        [InlineData("й\n\nо\nу\n", new [] { "й", "", "о", "у", "" })] 
        public void SplitToLines(string text, string[] expected)
        {
            Assert.Equal(expected, RicksMercilessEncryptor.SplitToLines(text));
        }
        
        [Theory]
        [InlineData("йоу", new [] { "йоу" })]
        [InlineData("й           о        у", new [] { "й", "о", "у" })]
        public void SplitToWords(string line, string[] expected)
        {
            Assert.Equal(expected, RicksMercilessEncryptor.SplitToWords(line));
        }
        
        [Theory]
        [InlineData("йоу", "й")]
        [InlineData("йоуйоу", "йоу")]
        public void GetLeftHalf(string s, string expected)
        {
            Assert.Equal(expected, RicksMercilessEncryptor.GetLeftHalf(s));
        }
        
        [Theory]
        [InlineData("йоу", "оу")]
        [InlineData("йоууой", "уой")]
        public void GetRightHalf(string s, string expected)
        {
            Assert.Equal(expected, RicksMercilessEncryptor.GetRightHalf(s));
        }
        
        [Theory]
        [InlineData("ха-ха-ха", "ха", "йоу", "йоу-йоу-йоу")]
        [InlineData("", "йоу", "йоуйоу", "")]
        public void Replace(string s, string old, string @new, string expected)
        {
            Assert.Equal(expected, RicksMercilessEncryptor.Replace(s, old, @new));
        }
        
        [Theory]
        [InlineData("йоу", "\\u0439\\u043E\\u0443")]
        public void CharsToCodes(string s, string expected)
        {
            Assert.Equal(expected, RicksMercilessEncryptor.CharsToCodes(s));
        }
        
        [Theory]
        [InlineData("йоу", "уой")]
        [InlineData("", "")]
        public void GetReversed(string s, string expected)
        {
            Assert.Equal(expected, RicksMercilessEncryptor.GetReversed(s));
        }
        
        [Theory]
        [InlineData("ЙоУйййоооооУуУ", "йОуЙЙЙОООООуУу")]
        [InlineData("", "")]
        public void InverseCase(string s, string expected)
        {
            Assert.Equal(expected, RicksMercilessEncryptor.InverseCase(s));
        }
        
        [Theory]
        [InlineData("йоу", "кпф")]
        [InlineData("", "")]
        public void ShiftInc(string s, string expected)
        {
            Assert.Equal(expected, RicksMercilessEncryptor.ShiftInc(s));
        }
        
        [Theory]
        [InlineData("Тралала - ¶1234:5678¶ \n" +
                    "А вот и комментарий //¶1111:1111¶\n" +
                    "/* И другой - ¶0000:0000¶" +
                    "Всё ещё комментарий  \n" +
                    "¶2222:22222¶ */\n" +
                    "А теперь комментарий кончился" +
                    "И напоследок: ¶3333:3333¶",
            new long[] {12345678, 33333333})]
        public void GetUsedObjects(string text, long[] expected)
        {
            Assert.Equal(expected, RicksMercilessEncryptor.GetUsedObjects(text));
        }

    }
}
