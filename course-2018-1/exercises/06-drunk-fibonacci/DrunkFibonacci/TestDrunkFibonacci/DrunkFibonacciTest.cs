using System;
using System.Linq;
using Xunit;
using DrunkFibonacci;
using System.Collections.Generic;

namespace TestDrunkFibonacci
{
    public class UnitTest1
    {
        [Fact]
        public void CreateIntArrayTest()
        {
            Assert.Equal(DrunkFibonacci.DrunkFibonacci.CreateIntArray(3), new int[3]);
        }
        
        [Fact]
        public void FillIntArrayTest()
        {
            var testArr = new int[6];
            DrunkFibonacci.DrunkFibonacci.FillIntArray(testArr, 1, 2);
            Assert.Equal(testArr, new int[6]{1, 3, 5, 7, 9, 11});
        }
        
        [Fact]
        public void GetFirstFiveFibonacciTest()
        {
            Assert.Equal(DrunkFibonacci.DrunkFibonacci.GetFirstFiveFibonacci(), new int[5]{1, 1, 2, 3, 5});
        }
        
        [Fact]
        public void GetDeterministicRandomSequenceTest()
        {
            Assert.Equal(DrunkFibonacci.DrunkFibonacci.GetDeterministicRandomSequence().Take(5), new int[5]{1786119601, 1588339109, 1375889406, 689600630, 850721626});
        }
        
        [Fact]
        public void GetFibonacciOriginalTest()
        {
            Assert.Equal(DrunkFibonacci.DrunkFibonacci.GetFibonacciOriginal().Take(5), new int[5]{1, 1, 2, 3, 5});
        }
        
        [Fact]
        public void GetDrunkFibonacciTest()
        {
            Assert.Equal(DrunkFibonacci.DrunkFibonacci.GetDrunkFibonacci().Take(11), new int[11]{1,1,2,300,5,13,21,34,300,89,233});
        }
        
        [Fact]
        public void GetMaxOnRangeTest()
        {
            Assert.Equal(DrunkFibonacci.DrunkFibonacci.GetMaxOnRange(5, 10), 570);
        }
        
        [Fact]
        public void GetNextNegativeRangeTest()
        {
            Assert.Equal(DrunkFibonacci.DrunkFibonacci.GetNextNegativeRange(5), new int[3]{-1553037953, -1411470381, -1269902843});
        }
        
        [Fact]
        public void GetXoredWithLaggedItselfTest()
        {
            Assert.Equal(DrunkFibonacci.DrunkFibonacci.GetXoredWithLaggedItself().Take(5), new int[5]{1613594073, 301, 1957285271, -36705749, -2030696324});
        }
        
        [Fact]
        public void GetInChunksTest()
        {
            Assert.Equal(DrunkFibonacci.DrunkFibonacci.GetInChunks().Take(2), new []{new []{1,1,2,300,5,13,21,34,300,89,233,337,570,300,1477,3861}
                    ,
                    new []{6245,10106,300,26449,69249,112017,181266,300,474549,1242381,2010213,3252594,300,8515393,22293585,36071785}
            });
        }
        
        [Fact]
        public void FlattenChunkedSequenceTest()
        {
            Assert.Equal(DrunkFibonacci.DrunkFibonacci.FlattenChunkedSequence().Take(5), new int[5]{1, 1, 2, 300, 300});
        }
        
        [Fact]
        public void GetGroupSizesTest()
        {
            var testDictionary = new Dictionary<int, int> {{1, 1034}, {2, 215}, {4, 2302}, {5, 995}};
            Assert.Equal(DrunkFibonacci.DrunkFibonacci.GetGroupSizes().Take(4), testDictionary);
        }
    }
}