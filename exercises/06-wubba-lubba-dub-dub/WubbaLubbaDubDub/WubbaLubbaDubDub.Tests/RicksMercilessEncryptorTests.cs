using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Theory]
        [InlineData("\n",
            new[] { "", "" })]

        [InlineData("Text with only one line",
         new[] { "Text with only one line" })]

        [InlineData("Line 1\nLine 2\r\nLine 3",
            new[] { "Line 1", "Line 2", "Line 3" })]
        public void TestSplitToLines(string line, string[] result)
        {
            Assert.Equal(result, line.SplitToLines());
        }


        [Theory]
        [InlineData("\n \n",
            new string[] { })]

        [InlineData("Text with only one line and many simple words",
            new[] { "Text", "with", "only", "one", "line", "and", "many", "simple", "words"})]

        [InlineData("Multiline text\nwith simple \r\nwords",
            new[] { "Multiline", "text", "with", "simple", "words" })]

        [InlineData("Text with com.plic@ted a-nd !weird Words",
            new[] { "Text", "with", "com.plic@ted", "a-nd", "!weird", "Words" })]

        [InlineData("Test. if? we... take!!! punctuation* and_more)",
            new[] { "Test", "if", "we", "take", "punctuation", "and_more" })]
        public void TestSplitToWords(string line, string[] result)
        {
            Assert.Equal(result, line.SplitToWords());
        }


        [Theory]
        [InlineData("", "")]
        [InlineData("Oddstring", "Odds")]
        [InlineData("Evenstring", "Evens")]
        [InlineData("String\nwithspecial", "String\nwi")]
        public void TestGetLeftHalf(string line, string result)
        {
            Assert.Equal(result, line.GetLeftHalf());
        }


        [Theory]
        [InlineData("", "")]
        [InlineData("Oddstring", "tring")]
        [InlineData("Evenstring", "tring")]
        [InlineData("String\nwithspecial", "thspecial")]
        public void TestGetRightHalf(string line, string result)
        {
            Assert.Equal(result, line.GetRightHalf());
        }


        [Theory]
        [InlineData("", "nothing", "", "")]
        [InlineData("nothing", "nothing", "something", "something")]
        [InlineData("something", "something", "", "")]
        [InlineData("something", "nothing", "anything", "something")]
        [InlineData("“акого как ѕутин полного сил “акого как ѕутин чтобы не пил “акого как ѕутин чтоб не обижал “акого как ѕутин чтоб не убежал", 
            "ѕутин", "Ќэвэльный",
            "“акого как Ќэвэльный полного сил “акого как Ќэвэльный чтобы не пил “акого как Ќэвэльный чтоб не обижал “акого как Ќэвэльный чтоб не убежал")]
        public void TestReplace(string line, string old, string @new, string result)
        {
            Assert.Equal(result, RicksMercilessEncryptor.Replace(line, old, @new));
        }


        [Theory]
        [InlineData("", "")]
        [InlineData("аргентинаманитнегра", "аргентинаманитнегра")]
        [InlineData("123456789", "987654321")]
        [InlineData("String\nwithspecial", "laicepshtiw\ngnirtS")]
        public void TestGetReversed(string line, string result)
        {
            Assert.Equal(result, line.GetReversed());
        }


        [Theory]
        [InlineData("", "")]
        [InlineData("?!?!!!", "?!?!!!")]
        [InlineData("это маленькие буквы", "Ё“ќ ћјЋ≈Ќ№ »≈ Ѕ” ¬џ")]
        [InlineData("Ё“ќ  јѕ—", "это капс")]
        [InlineData("ѕр»в≈т»к  а  д≈л»ш и?", "п–и¬е“и  кјк ƒеЋиЎк»?")]
        public void TestInverseCase(string line, string result)
        {
            Assert.Equal(result, line.InverseCase());
        }


        [Theory]
        [InlineData("", "")]
        [InlineData("abcdABCD", "bcdeBCDE")]
        [InlineData("012345678", "123456789")]
        [InlineData("абвгд≈®∆«»", "бвгде∆А«»…")]  // from ј-яа-€ with love
        public void TestShiftInc(string line, string result)
        {
            Assert.Equal(result, line.ShiftInc());
        }

        [Theory]
        [InlineData("", new long[]{})]
        [InlineData("Just string without ids\r\nAnd another boring string", new long[] { })]
        [InlineData("String with single-line comment //AAAA:0000 ", new long[] { })]
        [InlineData("String with multiline comment  /*AAAA:0000*/ and only one string", new long[] { })]
        [InlineData("String with multiline comment /* AAAA:0000 \r\n BACA:1234 */", new long[] { })]
        [InlineData("1000:1234", new[] { 268440116L })]
        [InlineData("//String with single-line comment \r\n 0000:1234 ", new[] { 4660L })]
        public void GetUsedObjects(string line, long[] result)
        {
            Assert.Equal(result, line.GetUsedObjects());
        }
    }
}
