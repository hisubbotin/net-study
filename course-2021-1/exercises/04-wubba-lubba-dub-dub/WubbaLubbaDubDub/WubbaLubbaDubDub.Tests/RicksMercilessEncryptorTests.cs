using System;
using Xunit;
using System.Collections.Immutable;
using System.Linq;

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
            // Console.WriteLine(local_res);
            
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
            // Console.WriteLine(local_res);
            Assert.Equal(local_res, result);
        }

        [Theory]
        [InlineData("jj", "\\u006a\\u006a")]
        [InlineData("ç", "\\u00e7")]
        [InlineData("👽", "\\ud83d\\udc7d")]
        public void Test_CharsToCodes(string old, string result)
        {
            string local_res = old.CharsToCodes(); 
            // Console.WriteLine(local_res);
            Assert.Equal(local_res, result);
        }

        [Theory]
        [InlineData("WubbaLubbaDubDub", "buDbuDabbuLabbuW")]
        [InlineData("Let's go. In and out. Twenty minute adventure.", ".erutnevda etunim ytnewT .tuo dna nI .og s'teL")]
        [InlineData("EvacanignitevirtuososoutrivetinginacavE", "EvacanignitevirtuososoutrivetinginacavE")]
        public void Test_GetReversed(string old, string result)
        {
            string local_res = old.GetReversed();
            Assert.Equal(local_res, result);
        }

        [Theory]
        [InlineData("WubbaLubbaDubDub", "wUBBAlUBBAdUBdUB")]
        [InlineData("aaaAAAAbbbBBB", "AAAaaaaBBBbbb")]
        public void Test_InverseCase(string old, string result)
        {
            string local_res = old.InverseCase();
            Assert.Equal(local_res, result);
        }

        [Theory]
        [InlineData("WubbaLubbaDubDub", "XvccbMvccbEvcEvc")]
        [InlineData("aaaAAAAbbbBBB", "bbbBBBBcccCCC")]
        public void Test_ShiftInc(string old, string result)
        {
            string local_res = old.ShiftInc();
            Assert.Equal(local_res, result);
        }

        [Theory]
        

        [InlineData("//WubbaLubbaDubDub\naaaa\n/*\nbbbbb\n*/\nccccc\naaaa\n¶1525:1525¶\n", 
        new long[] { 15251525 })]

        [InlineData("//WubbaLubbaDubDub\naaaa\n/*\nbbbbb\n*/\nccccc\naaaa\n¶1525:1525¶\n\n¶0000:1525¶\n\n¶1525:1525¶\n\n¶4242:4242¶\n", 
        new long[] { 15251525, 1525, 42424242})]
        public void Test_GetUsedObjects(string text, long[] result)
        {
            var result_checking = ImmutableList.CreateRange(result);
            var local_res = text.GetUsedObjects();
            Console.WriteLine(local_res);
            Assert.True(local_res.SequenceEqual(result_checking));
            // CollectionAssert.Equal(local_res, result_checking);
        }
    }
}
