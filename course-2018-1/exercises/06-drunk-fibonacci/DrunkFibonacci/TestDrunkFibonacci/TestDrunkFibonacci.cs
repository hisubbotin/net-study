using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Xunit;


namespace TestDrunkFibonacci
{
    public class TestDrunkFibonacci
    {
        public static IEnumerable<object[]> Data_GetDrunkFibonacci()
        {
            return new List<object[]>
            {
                new object[] {new List<int> {1, 1, 2, 300, 302}, 5},
                new object[] {new List<int> {1, 1, 2, 300, 302, 904, 1206, 2110 }, 8}
            };
        }

        [Theory]
        [MemberData(nameof(Data_GetDrunkFibonacci))]        
        public void Test_GetDrunkFibonacci(List<int> fibSeq, int seqLen)
        {
            int count = 0;
            foreach (var fib in DrunkFibonacci.DrunkFibonacci.GetDrunkFibonacci())
            {
                Console.WriteLine(fib);
                Assert.Equal(fibSeq[count], fib);
                count++;
                if (count == seqLen)
                {
                    break;
                }
            }
        }
        
        [Fact]
        public void Test_GetDeterministicRandomSequence()
        {
            /*var fstSeq = DrunkFibonacci.DrunkFibonacci.GetDeterministicRandomSequence();
            var scdSeq = DrunkFibonacci.DrunkFibonacci.GetDeterministicRandomSequence();
            Assert.True(fstSeq.SequenceEqual(scdSeq));*/
        }
    }
}