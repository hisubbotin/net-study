using System;
using System.Linq;
using System.Text.RegularExpressions;
using Xunit;
using static WubbaLubbaDubDub.RicksMercilessEncryptor;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Theory]
        [InlineData("Hello there \t \n Here some \r\n new lines.\rNice Job team ",
            "Hello there \t ", " Here some ", " new lines.", "Nice Job team ")]
        public void Test_SplitToLines(string text,
            string res0, string res1, string res2, string res3)
        {
            var result = text.SplitToLines();
            Assert.Equal(4, result.Length);
            Assert.Equal(res0, result[0]);
            Assert.Equal(res1, result[1]);
            Assert.Equal(res2, result[2]);
            Assert.Equal(res3, result[3]);
        }
        
        [Theory]
        [InlineData("Hello there \t \n Here_some \r\n new lines.\rNice Job team ",
            "Hello", "there", "Here_some", "new", "lines", "Nice", "Job", "team")]
        public void Test_SplitToWords(string text,
            string res0, string res1, string res2, string res3,
            string res4, string res5, string res6, string res7)
        {
            var result = text.SplitToWords();
            Assert.Equal(8, result.Length);
            Assert.Equal(res0, result[0]);
            Assert.Equal(res1, result[1]);
            Assert.Equal(res2, result[2]);
            Assert.Equal(res3, result[3]);
            Assert.Equal(res4, result[4]);
            Assert.Equal(res5, result[5]);
            Assert.Equal(res6, result[6]);
            Assert.Equal(res7, result[7]);
        }
        
        [Theory]
        [InlineData("\r\t \n\t\n.<?,")]
        public void Test_SplitToWords_No_words(string text)
        {
            var result = text.SplitToWords();
            Assert.Empty(result);
        }
        
        [Theory]
        [InlineData("Hello_world", "Hello")]
        public void Test_GetLeftHalf_2n_plus_1(string text, string expected)
        {
            var result = text.GetLeftHalf();
            Assert.Equal(expected, result);
        }
        [Theory]
        [InlineData("Helloworld", "Hello")]
        public void Test_GetLeftHalf_2n_plus(string text, string expected)
        {
            var result = text.GetLeftHalf();
            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData("Hello_world", "_world")]
        public void Test_GetRightHalf_2n_plus_1(string text, string expected)
        {
            var result = text.GetRightHalf();
            Assert.Equal(expected, result);
        }
        [Theory]
        [InlineData("Helloworld", "world")]
        public void Test_GetRighHalf_2n_plus(string text, string expected)
        {
            var result = text.GetRightHalf();
            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData("replace\t\n.me", "\n.m", "not me", "replace\tnot mee")]
        public void Test_Replace(string text, string old, string @new, string expected)
        {
            var result = text.ReplaceExtended(old, @new);
            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData("Hi, C#!", "\\u0048\\u0069\\u002C\\u0020\\u0043\\u0023\\u0021")]
        public void Test_CharsToCode(string text, string expected)
        {
            var result = text.CharsToCodes();
            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData("Oh, hi Mark!", "!kraM ih ,hO")]
        public void Test_Reverse(string text, string expected)
        {
            var result = text.GetReversed();
            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData("$NaGibator_xXx$", "$nAgIBATOR_XxX$")]
        public void Test_Inverse(string text, string expected)
        {
            var result = text.InverseCase();
            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData("abcde", "bcdef")]
        public void Test_ShiftInc(string text, string expected)
        {
            var result = text.ShiftInc();
            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData("Unbalanced scales.svg\n" +
                    "The neutrality of this article is disputed. Relevant discussion may be found on the talk page. Please do not remove this message until conditions to do so are met. (February 2016) (Learn how and when to remove this template message)\n" +
                    "Moscow Ins//titute of Physics and Technology (State University) Московский Физико-Технический институт0fA45:67DD (государственный университет)\n" +
                    "Mosc0a45:67bbow //Institute of Physics and Technology logo.jpg\n" +
                    "Motto 	Sapere aude\n" +
                    "Motto in English\n" +
                    "Dare to know\n" +
                    "Type 	Public\n" +
                    "Established 	1946\n" +
                    "Rec/*tor 	Nikolay Kudryavtsev\n" +
                    "Undergraduates 	3319\n" +
                    "Postgraduafff:5555ates 	1758\n" +
                    "Location 	Dolgoprudn*/y, Moscow, Zhukovsky, Russia\n" +
                    "Website 	www.mipt.ru, www.phystech.edu\n" +
                    "\n" +
                    "Coordinates: 55°55′46″N 37°31′17″E Moscow Institute 3319:1755of Physics and Technology (Russian: Московский Физико-Технический институт), known informally as PhysTech (Физтех), is a leading Russian university, originally established during the Soviet Union. It prepares specialists in theoretical and applied physics, applied mathematics, and related disciplines.\n" +
                    "MIPT is famous in the countries of the former Soviet Union, but is lFFFF:AAAAess known abroad. This is largely due to the specifics of the MIPT educational process (see \"Phystech System\" below). University rankings such as The Times Higher Education Supplement are based primarily on publications and citations. With its emphasis on embedding research in the educational process, MIPT \"outsources\" education and research beyond the first two or three years of study to institutions of the Russian Academy of Sciences. MIPT's own faculty is relatively small, and many of its distinguished lecturers are visiting professors from those institutions. Student research is typically performed outside of MIPT, and research papers do not identify the authors as MIPT students. This effectively hides MIPT from the academic radar, an effect not unwelcome during the Cold War era when leading scientists and engineers of the Soviet arms and space programs studied there.\n"
        +
        "The word \"phystech,\" without the capital P, is also used in Russian to refer to Phystech students and graduates.\n",
        172320699, 857282389, 4294945450)]
        public void Test_UsedObjects(string text, 
            long res0, long res1, long res2)
        {
            var result = text.GetUsedObjects();
            Assert.Equal(3, result.Count);
            Assert.Equal(res0, result[0]);
            Assert.Equal(res1, result[1]);
            Assert.Equal(res2, result[2]);
        }
    }
}
