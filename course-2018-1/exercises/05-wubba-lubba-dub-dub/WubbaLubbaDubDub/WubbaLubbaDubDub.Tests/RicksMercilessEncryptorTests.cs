using System;
using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Theory]
        [InlineData("a . a. a. b. b. ppp. ttt.", new string[] {"a", "a", "a", "b", "b", "ppp", "ttt"})]
        void Test_SplitToLines(string text, params string[] result)
        {
            string[] splited = RicksMercilessEncryptor.SplitToLines(text);
            for (int i = 0; i < splited.Length; i++)
            {
                Console.WriteLine(splited[i]);
                Assert.True(String.Equals(splited[i] ,result[i]));
            }
        }
        
        [Theory]
        [InlineData("a . ,,a. b. ppp, : \" \" , ,, , , , , , , ttt.", new string[] {"a", "a", "b", "ppp", "ttt"})]
        void Test_SplitToWords(string text, params string[] result)
        {
            string[] splited = RicksMercilessEncryptor.SplitToLines(text);
            for (int i = 0; i < splited.Length; i++)
            {
                Console.WriteLine(splited[i]);
                Assert.True(String.Equals(splited[i] ,result[i]));
            }
        }
    }
}
