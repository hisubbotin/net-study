using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        public void Test_SplitToLines(string text)
        {
            Assert.True(text == "Hello, World!");
        }
    }
}