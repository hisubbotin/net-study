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
        private readonly string _filePath;

        /// <summary>
        /// Load text from a file as the data source for a theory
        /// </summary>
        /// <param name="filePath">The absolute or relative path to the file to load</param>
        public TextFileDataAttribute(string filePath)
        {
            _filePath = filePath;
        }

        /// <inheritDoc />
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            if (testMethod == null)
            {
                throw new ArgumentNullException(nameof(testMethod));
            }

            // Get the absolute path to the file
            var path = Path.IsPathRooted(_filePath)
                ? _filePath
                : Path.GetRelativePath(Directory.GetCurrentDirectory(), _filePath);

            if (!File.Exists(path))
            {
                throw new ArgumentException($"Could not find file at path: {path}");
            }

            // Load the file
            var fileData = File.ReadAllText(_filePath);
            return new List<object[]> {new object[] {fileData}};
        }
    }

    public class RicksMercilessEncryptorTests
    {
        [Theory]
        [TextFileData("Data/Text.txt")]
        public void Test_TextFileData(string text)
        {
            Assert.Equal(text, "Hello, World!");
        }

        [Theory]
        [TextFileData("Data/BigText.txt")]
        public void Test_SplitToLines(string text)
        {
            Assert.Equal(text.SplitToLines().Length, 40);
        }

        [Theory]
        [InlineData(
            "Мама мыла раму",
            new string[] {"Мама", "мыла", "раму"}
        )]
        [InlineData(
            "Мама, а ты мыла раму?",
            new string[] {"Мама", "а", "ты", "мыла", "раму"}
        )]
        public void Test_SplitToWords(string line, string[] result)
        {
            Assert.Equal(line.SplitToWords(), result);
        }

        [Theory]
        [InlineData(
            "abce",
            "ab"
        )]
        [InlineData(
            "abcde",
            "ab"
        )]
        [InlineData(
            "Мама мыла раму",
            "Мама мы"
        )]
        public void Test_GetLeftHalf(string line, string result)
        {
            Assert.Equal(line.GetLeftHalf(), result);
        }

        [Theory]
        [InlineData(
            "abce",
            "ce"
        )]
        [InlineData(
            "abcde",
            "cde"
        )]
        [InlineData(
            "Мама мыла раму",
            "ла раму"
        )]
        public void Test_GetRightHalf(string line, string result)
        {
            Assert.Equal(line.GetRightHalf(), result);
        }

        [Theory]
        [InlineData(
            "Мама мыла раму",
            "ам",
            "ап",
            "Мапа мыла рапу"
        )]
        public void Test_Replace(string line, string old, string replaceWith, string result)
        {
            Assert.Equal(line.Replace(old, replaceWith), result);
        }

        [Theory]
        [InlineData(
            "A",
            "\\u0041"
        )]
        [InlineData(
            "Мама мыла раму",
            "\\u041C\\u0430\\u043C\\u0430\\u0020\\u043C\\u044B\\u043B\\u0430\\u0020\\u0440\\u0430\\u043C\\u0443"
        )]
        public void Test_CharsToCodes(string line, string result)
        {
            Assert.Equal(line.CharsToCodes(), result);
        }

        [Theory]
        [InlineData(
            "abce",
            "ecba"
        )]
        [InlineData(
            "Мама мыла раму",
            "умар алым амаМ"
        )]
        public void Test_GetReversed(string line, string result)
        {
            Assert.Equal(line.GetReversed(), result);
        }

        [Theory]
        [InlineData(
            "abce 43",
            "ABCE 43"
        )]
        [InlineData(
            "Мама мыла раму",
            "мАМА МЫЛА РАМУ"
        )]
        public void Test_InverseCase(string line, string result)
        {
            Assert.Equal(line.InverseCase(), result);
        }

        [Theory]
        [InlineData(
            "abce 43",
            "bcdf!54"
        )]
        [InlineData(
            "Мама мыла раму",
            "Нбнб!ньмб!сбнф"
        )]
        public void Test_ShiftInc(string line, string result)
        {
            Assert.Equal(line.ShiftInc(), result);
        }

        [Theory]
        [TextFileData("Data/IdText.txt")]
        public void Test_GetUsedObjects(string text)
        {
            Assert.Equal(text.GetUsedObjects(), new long[] {4038984096L, 4037935265L});
        }
    }
}