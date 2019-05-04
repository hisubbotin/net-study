using System;
using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {

        [Fact]
        public void TestSplitToLines()
        {
            string[] strings_sample = {
            "aakklll788",
            "kmg fkbjg;u 2 mk",
            "34bh"
            };

            string s = String.Join(" ", strings_sample);
            string[] strings_splitted = s.SplitToLines();

            for (int i = 0; i < strings_sample.Length; i++)
            {
                Assert.Equal(strings_sample[i], strings_splitted[i]);
            }
        }

        [Fact]
        public void TestSplitToWords()
        {
            string[] strings_sample = {
                "Hello!!",
                " world",
                "HeHe))"
            };
            string new_string_sample = String.Join("\n", strings_sample);

            string[] to_compare = {
                "Hello",
                "world",
                "HeHe",
                ""
            };

            Assert.Equal(new_string_sample.SplitToWords(), to_compare);
        }

        [Fact]
        public void TestReplace()
        {
            string string_sample = "Hello World!";
            Assert.Equal(string_sample.Replace("o","0"), "Hell0 W0rld!");
        }

        [Fact]
        public void TestInverseCase()
        {
            string string_sample = "HelLo";
            Assert.Equal(string_sample.InverseCase(), "hELlO");
        }
    }
}
