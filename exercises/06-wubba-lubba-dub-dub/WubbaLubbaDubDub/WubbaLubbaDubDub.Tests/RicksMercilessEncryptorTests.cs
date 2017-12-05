using System;
using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Theory]
        [InlineData("Wubba\r\nLubba\r\n\r\nDub\r\nDub",
            "Wubba", "Lubba", "", "Dub", "Dub")]
        public void StlitToLinesTest(string text,
            string res1, string res2, string res3, 
            string res4, string res5)
        {
            var res = text.SplitToLines();
            Assert.Equal(res1, res[0]);
            Assert.Equal(res2, res[1]);
            Assert.Equal(res3, res[2]);
            Assert.Equal(res4, res[3]);
            Assert.Equal(res5, res[4]);
        }

        [Theory]
        [InlineData("very easy test case", 
            "very", "easy", "test", "case")]
        public void SplitToWordsTest(string text,
            string w1, string w2, string w3, string w4)
        {
            var res = text.SplitToWords();
            Assert.Equal(res[0], w1);
            Assert.Equal(res[1], w2);
            Assert.Equal(res[2], w3);
            Assert.Equal(res[3], w4);
        }

        [Theory]
        [InlineData("halfstrr", "longhalflongstrr", "half", "longhalf")]
        public void GetLeftHalfTest(string s1, string s2,
            string half1, string half2)
        {
            Assert.Equal(half1, s1.GetLeftHalf());
            Assert.Equal(half2, s2.GetLeftHalf());
        }

        [Theory]
        [InlineData("halfstrr", "longhalflongstrr", "strr", "longstrr")]
        public void GetRightHalfTest(string s1, string s2,
            string half1, string half2)
        {
            Assert.Equal(half1, s1.GetLeftHalf());
            Assert.Equal(half2, s2.GetLeftHalf());
        }

        [Theory]
        [InlineData("Putin putin medved putin", "utin", "resident", 
            "President president medved president")]
        public void ReplaceTest(string s, string sub, string repl, string res)
        {
            Assert.Equal(res, s.Replace(sub, repl));
        }

        [Theory]
        [InlineData("Hi, C#!", "\\u0048\\u0069\\u002C\\u0020\\u0043\\u0023\\u0021")]
        public void CharsToCodeTest(string s, string chars)
        {
            Assert.Equal(chars, s.CharsToCodes());
        }

        [Theory]
        [InlineData("dot net tests are infinite", "etinifini era stset ten tod")]
        public void ReverseTest(string s, string reversed)
        {
            Assert.Equal(reversed, s.GetReversed());
            Assert.Equal(s, s.GetReversed().GetReversed());
        }

        [Theory]
        [InlineData("ZaBorTCHick", "zAbORtchICK")]
        public void InverseCaseTest(string s, string inverted)
        {
            Assert.Equal(s.InverseCase(), inverted);
            Assert.Equal(s, inverted.InverseCase());
        }

        [Theory]
        [InlineData("abcdef", "bcdefg")]
        public void ShiftIncTest(string s, string res)
        {
            Assert.Equal(res, s.ShiftInc());
        }

        [Theory]
        // Тут мне уже лень было подбирать пример, взял у @Kholopov
        [InlineData("Unbalanced scales.svg\n" +
                    "The neutrality of this article is disputed. Relevant discussion may be found on the talk page. Please do not remove this message until conditions to do so are met. (February 2016) (Learn how and when to remove this template message)\n" +
                    "Moscow Ins//titute of Physics and Technology (State University) Московский Физико-Технический институт0fA45:67DD (государственный университет)\n" +
                    "//Mosc0a45:67bbow //Institute of Physics and Technology logo.jpg\n" +
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
        857282389, 4294945450)]
        public void UsedObjectsTest(string text,
            long res0, long res1, long res2)
        {
            var result = text.GetUsedObjects();
            Assert.Equal(2, result.Count);
            Assert.Equal(res0, result[0]);
            Assert.Equal(res1, result[1]);
        }
    }
}
