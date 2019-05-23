using System;
using Xunit;
using System.Collections.Immutable;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Fact]
        void Test_SplitToLines()
        {
            string s = "a\nb\n\narr";
            Assert.Equal(s.SplitToLines(), new string[] { "a", "b", "", "arr" });
        }

        [Fact]
        void Test_SplitToWords()
        {
            string s = "a b c   \td\nno words\n\narr";
            Assert.Equal(s.SplitToWords(), new string[] { "a", "b", "c", "d", "no", "words", "arr" });
        }

        [Theory]
        [InlineData("1234567890", "12345")]
        [InlineData("12345678901", "12345")]
        void Test_GetLeftHalf(string s, string result)
        {
            Assert.Equal(s.GetLeftHalf(), result);
        }

        [Theory]
        [InlineData("1234567890", "67890")]
        [InlineData("12345678901", "678901")]
        void Test_GetRightHalf(string s, string result)
        {
            Assert.Equal(s.GetRightHalf(), result);
        }

        [Theory]
        [InlineData("tau kita", "a", "ty", "ttyu kitty")]
        void Test_Replace(string s, string old, string @new, string result)
        {
            Assert.Equal(RicksMercilessEncryptor.Replace(s, old, @new), result);
        }

        [Theory]
        [InlineData("acdc113", @"\u0061\u0063\u0064\u0063\u0031\u0031\u0033")]
        [InlineData("$5%^@", @"\u0024\u0035\u0025\u005E\u0040")]
        void Test_CharsToCodes(string s, string result)
        {
            Assert.Equal(s.CharsToCodes(), result);
        }

        [Theory]
        [InlineData("acdc113", "311cdca")]
        [InlineData("abracadabra\n", "\narbadacarba")]
        void Test_GetReversed(string s, string result)
        {
            Assert.Equal(s.GetReversed(), result);
        }

        [Theory]
        [InlineData("acdc113", "ACDC113")]
        [InlineData("R u SuRe AboUT iT?", "r U sUrE aBOut It?")]
        void Test_InverseCase(string s, string result)
        {
            Assert.Equal(s.InverseCase(), result);
        }

        [Theory]
        [InlineData("acdc113", "bded224")]
        [InlineData("?huh!", "@ivi\"")]
        void Test_ShiftInc(string s, string result)
        {
            Assert.Equal(s.ShiftInc(), result);
        }

        [Fact]
        void Test_GetUsedObjects()
        {
            string text = "Hello World! My age is ¶00000000:00000014¶ // Yes, not ¶00000000:00000013¶\n" +
                "/*looong\n" +
                "multiline\n" +
                "comment*/\n//\n" +
                "Mr. ¶/*huge number*/abcba011:0030acdc¶, I don't feel so ¶abcdef00:12345678¶. #¶ed:aa¶\n" +
                "/*¶00000000:00000001¶*/¶00000000:00000001¶/*¶00000000:00000001¶*/";
            var ids = ImmutableList.CreateRange(new long[] { 20, -6067580078073533220, -6066930339413731720, 1 });
            Assert.Equal(text.GetUsedObjects(), ids);
        }


    }
}
