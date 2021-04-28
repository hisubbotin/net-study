using System;
using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Theory]
        [InlineData("aaaaa\naaaa\naa\n", new string[]{"aaaaa", "aaaa", "aa", ""})]
        public void Test_SplitToLines(string x, string[] result)
        {
            Assert.Equal(RicksMercilessEncryptor.SplitToLines(x), result);
        }


        [Theory]
        [InlineData("aaaaa aaaa aa", new string[]{"aaaaa", "aaaa", "aa"})]
        [InlineData("Weddings Are Basically Funerals With A Cake", 
        new string[]{"Weddings", "Are", "Basically", "Funerals", "With", "A", "Cake"})]

        [InlineData("Let's go. In and out. Twenty minute adventure.", 
        new string[]{"Let", "s", "go", "In", "and", "out", "Twenty", "minute", "adventure", ""})]
        public void Test_SplitToWords(string line, string[] result)
        {
            // string[] res = RicksMercilessEncryptor.SplitToWords(line);
            // for (int i = 0; i < res.Length; ++i) {
            //   Console.WriteLine(res[i], " ");   
            // }
            // Console.WriteLine();
            Assert.Equal(RicksMercilessEncryptor.SplitToWords(line), result);
        }

        [Theory]
        [InlineData("aaaaabbbbb", "aaaaa")]
        [InlineData("aaaaabbbbbb", "aaaaa")]
        public void Test_GetLeftHalf(string line, string result)
        {
            string local_res = RicksMercilessEncryptor.GetLeftHalf(line); 
            Console.WriteLine(local_res);
            
            Assert.Equal(local_res, result);
        }

        [Theory]
        [InlineData("aaaaabbbbb", "bbbbb")]
        [InlineData("aaaaabbbbbb", "bbbbbb")]
        public void Test_GetRightHalf(string line, string result)
        {
            string local_res = RicksMercilessEncryptor.GetRightHalf(line); 
            Assert.Equal(local_res, result);
        }


        [Theory]
        [InlineData("WubbaLubbaDubDub", "Dub", "Wubba", "WubbaLubbaWubbaWubba")]
        [InlineData("abaabababbbababb", "b", "a", "aaaaaaaaaaaaaaaa")]
        public void Test_Replace(string s, string old, string @new, string result)
        {
            string local_res = RicksMercilessEncryptor.Replace(s, old, @new); 
            Console.WriteLine(local_res);
            
            Assert.Equal(local_res, result);
        }
    }
}
