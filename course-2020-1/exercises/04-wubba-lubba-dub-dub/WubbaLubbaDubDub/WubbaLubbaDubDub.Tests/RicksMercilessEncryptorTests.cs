using System;
using System.Runtime.InteropServices;
using Xunit;
using WubbaLubbaDubDub;

namespace WubbaLubbaDubDub.Tests 
{
    public class RicksMercilessEncryptorTests
    {
        [Theory]
        [InlineData("Вот\nтакой\nтекстик\nтут\n", new[] {"Вот", "такой", "текстик", "тут", ""})]
        [InlineData("\n\n\n\n\n\n", new[] {"", "", "", "", "", "", ""})]
        public void Test_SplitToLines(string text, string[] answer)
        {
            Assert.Equal(answer, text.SplitToLines());
        }

        [Theory]
        [InlineData("Вот такой текстик тут", new[] {"Вот", "такой", "текстик", "тут"})]
        [InlineData("Вот\t\nтакой,   текстик тут", new[] {"Вот", "такой", "текстик", "тут"})]
        public void Test_SplitToWords(string line, string[] answer)
        {
            Assert.Equal(answer, line.SplitToWords());
        }

        [Theory]
        [InlineData("перваяполовинавтораяполовина", "перваяполовина")]
        [InlineData("перваяполовина_втораяполовина", "перваяполовина")]
        public void Test_GetLeftHalf(string s, string answer)
        {
            Assert.Equal(answer, s.GetLeftHalf());
        }

        [Theory]
        [InlineData("перваяполовинавтораяполовина", "втораяполовина")]
        [InlineData("перваяполовина_втораяполовина", "_втораяполовина")]
        public void Test_GetRightHalf(string s, string answer)
        {
            Assert.Equal(answer, s.GetRightHalf());
        }

        [Theory]
        [InlineData("это_заменить_надо", "это_заменить", "на_это", "на_это_надо")]
        [InlineData("не_здесь_,_а_тут", "тут", "здесь", "не_здесь_,_а_здесь")]
        [InlineData("это_и_это_и_это_и_это", "это", "то", "то_и_то_и_то_и_то")]
        public void Test_Replace(string s, string old_str, string new_str, string answer)
        {
            Assert.Equal(answer, WubbaLubbaDubDub.RicksMercilessEncryptor.Replace(s, old_str, new_str));
        }

        [Theory]
        [InlineData("jhestko", @"\u6A\u68\u65\u73\u74\u6B\u6F")]
        [InlineData("12345 \n", @"\u31\u32\u33\u34\u35\u20\uA")]
        public void Test_CharsToCodes(string s, string answer)
        {
            Assert.Equal(answer, s.CharsToCodes());
        }

        [Theory]
        [InlineData("SOSIPISOS", "SOSIPISOS")]
        [InlineData("ne_polindrom(((", "(((mordnilop_en")]
        public void Test_Reverse(string s, string answer)
        {
            Assert.Equal(answer, s.GetReversed());
        }

        [Theory]
        [InlineData("sosipisos", "SOSIPISOS")]
        [InlineData("ТУТ_ВЫСОКО_тут_низко", "тут_высоко_ТУТ_НИЗКО")]
        [InlineData("РаНдОмНеНьКо", "рАнДоМнЕнЬкО")]
        public void Test_InverseCase(string s, string answer)
        {
            Assert.Equal(answer, s.InverseCase());
        }

        [Fact]
        public void Test_ShiftInc()
        {
            var strochka = "aBaCabA";
            var strochkaShifted = strochka.ShiftInc();
            Assert.Equal("bCbDbcB", strochkaShifted);
        }
    }
}