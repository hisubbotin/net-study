using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Xunit;
using Xunit.Sdk;

namespace WubbaLubbaDubDub.Tests
{
    public class TextFileDataAttribute : DataAttribute
    {
        
        public TextFileDataAttribute(string filePath)
        {
            path = filePath;
        }
        
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            String text;
            using (StreamReader sr = new StreamReader(path))
            {
                text = sr.ReadToEnd();
            }
            return new List<object[]> { new object[] { text } };
        }

        private readonly string path;
    }

    public class RicksMercilessEncryptorTests
    {

        [Theory]
        [TextFileData("Samples/Sample_01.txt")]
        public void Test_SplitToLines(string text)
        {
            Assert.Equal(text.SplitToLines().Length, 297);
        }

        [Theory]
        [InlineData(
            "Wir mussen der Fehler ausrotten",
            new string[] { "Wir", "mussen", "der", "Fehler", "ausrotten" }
        )]
        [InlineData(
            "Hurra die Welt geht unter",
            new string[] { "Hurra", "die", "Welt", "geht", "unter" }
        )]
        public void Test_SplitToWords(string line, string[] result)
        {
            Assert.Equal(line.SplitToWords(), result);
        }

        [Theory]
        [InlineData(
            "Normie",
            "Nor"
        )]
        [InlineData(
            "Normies",
            "Nor"
        )]
        [InlineData(
            "Normies get out",
            "Normies"
        )]
        public void Test_GetLeftHalf(string line, string result)
        {
            Assert.Equal(line.GetLeftHalf(), result);
        }

        [Theory]
        [InlineData(
            "Normie",
            "mie"
        )]
        [InlineData(
            "Normies",
            "mies"
        )]
        public void Test_GetRightHalf(string line, string result)
        {
            Assert.Equal(line.GetRightHalf(), result);
        }

        [Theory]
        [InlineData(
            "Wir mussen der Fehler ausrotten",
            "der Fehler",
            "die Volk",
            "Wir mussen die Volk ausrotten"
        )]
        public void Test_Replace(string line, string old, string replaceWith, string result)
        {
            Assert.Equal(line.Replace(old, replaceWith), result);
        }

        [Theory]
        [InlineData(
            "fugg",
            @"\u0066\u0075\u0067\u0067"
        )]
        public void Test_CharsToCodes(string line, string result)
        {
            Assert.Equal(line.CharsToCodes(), result);
        }

        [Theory]
        [InlineData(
            "Wir mussen der Fehler ausrotten",
            "nettorsua relheF red nessum riW"
        )]
        public void Test_GetReversed(string line, string result)
        {
            Assert.Equal(line.GetReversed(), result);
        }

        [Theory]
        [InlineData(
            "Wir mussen der Fehler ausrotten",
            "wIR MUSSEN DER fEHLER AUSROTTEN"
        )]
        public void Test_InverseCase(string line, string result)
        {
            Assert.Equal(line.InverseCase(), result);
        }

        [Theory]
        [InlineData(
            "Wir mussen der Fehler ausrotten",
            "Xjs!nvttfo!efs!Gfimfs!bvtspuufo"
        )]
        public void Test_ShiftInc(string line, string result)
        {
            Assert.Equal(line.ShiftInc(), result);
        }

        [Theory]
        [TextFileData("Samples/Sample_01.txt")]
        public void Test_GetUsedObjects(string text)
        {
            Assert.Equal(text.GetUsedObjects(), new long[] { 66, 2863315899 });
        }
    }
}
