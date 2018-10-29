using System;
using System.Collections.Immutable;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Theory]
        [InlineData("a . a. a. b. b. ppp. ttt.", new string[] {"a . a. a. b. b. ppp. ttt."})]
        [InlineData("  Moscow New_York Oslo \r\n\r\n\r\n llll", new string[] {"  Moscow New_York Oslo ", " llll"})]
        void Test_SplitToLines(string text, params string[] result)
        {
            string[] splited = RicksMercilessEncryptor.SplitToLines(text);
            for (int i = 0; i < splited.Length; i++)
            {
                string s = splited[i];
                string s2 = result[i];
                Assert.True(String.Equals(splited[i] ,result[i]));
            }
        }
        
        [Theory]
        [InlineData(". , ; a , \n \r\n , a , ; ; b ; ", new string[] {"a", "a", "b"})]
        [InlineData(". , ; a , \n \r\n , a , ; ; b ; ", new string[] {"a", "a", "b"})]
        void Test_SplitToWords(string text, params string[] result)
        {
            string[] splited = RicksMercilessEncryptor.SplitToLines(text);
            for (int i = 0; i < splited.Length; i++)
            {
                Console.WriteLine(splited[i]);
                Assert.True(String.Equals(splited[i] ,result[i]));
            }
        }

        [Theory]
        [InlineData("a", "")]
        [InlineData("ba", "b")]
        [InlineData("aa cdaa aa", "aa cd")]
        void Test_GetLeftHalf(string str, string leftHalf)
        {
            Assert.Equal(RicksMercilessEncryptor.GetLeftHalf(str), leftHalf);
        }
        
        [Theory]
        [InlineData("a", "a")]
        [InlineData("ba", "a")]
        [InlineData("aa cdaa aa", "aa aa")]
        void Test_GetRightHalf(string str, string rightHalf)
        {
            Assert.Equal(RicksMercilessEncryptor.GetRightHalf(str), rightHalf);
        }
        
        [Theory]
        [InlineData("aaa", "a", "b", "bbb")]
        [InlineData("aa bb cc ff", "a", "", " bb cc ff")]
        void Test_Replace(string s, string old, string @new, string result)
        {
            Assert.Equal(RicksMercilessEncryptor.Replace(s, old, @new), result);
        }
        
        [Theory]
        [InlineData("Paul", "\\u0050\\u0061\\u0075\\u006C")]
        [InlineData("John", "\\u004A\\u006F\\u0068\\u006E")]
        void Test_CharsToCodes(string test, string result)
        {
            string tmp = RicksMercilessEncryptor.CharsToCodes(test);
            Assert.Equal(tmp, result);
        }
        
        [Theory]
        [InlineData("aaaa", "aaaa")]
        [InlineData("aabb", "bbaa")]
        [InlineData("", "")]
        [InlineData("Hello John", "nhoJ olleH")]
        void Test_GetReversed(string test, string result)
        {
            Assert.Equal(RicksMercilessEncryptor.GetReversed(test), result);
        }
        
        [Theory]
        [InlineData("AbAbAbBBbA", "aBaBaBbbBa")]
        [InlineData("LKLmmnn", "lklMMNN")]
        void Test_InverseCase(string test, string result)
        {
            Assert.Equal(RicksMercilessEncryptor.InverseCase(test), result);
        }
        
        [Theory]
        [InlineData("pqrs", "qrst")]
        [InlineData("wxyz", "xyz{")]
        void Test_ShiftInc(string test, string result)
        {
            Assert.Equal(RicksMercilessEncryptor.ShiftInc(test), result);
        }

        [Theory]
        [InlineData("void f() { /*AA:BB*/  /* cc:DD */  // jkjnkjnjknn kjnkjnjknkj  \n  // \n // kk:ll \n tt:ii}", new long[] {1768518772})]
        void Test_GetUsedObjects(string text, long[] result)
        {   
            Assert.Equal(RicksMercilessEncryptor.GetUsedObjects(text), result);
        }
    }
}
