using System;
using Xunit;

namespace GarbageLimits.Test
{
    public class GarbageTest
    {
        [Theory]
        [InlineData(TAllocationType.AT_Char, 1024, 0)]
        [InlineData(TAllocationType.AT_Char, 2048, 0)]
        [InlineData(TAllocationType.AT_Char, 4096, 0)]
        [InlineData(TAllocationType.AT_Char, 8192, 0)]
        [InlineData(TAllocationType.AT_Char, 16384, 0)]
        [InlineData(TAllocationType.AT_Char, 32768, 0)]
        [InlineData(TAllocationType.AT_Char, 65536, 2)]
        [InlineData(TAllocationType.AT_Char, 49152, 2)]
        [InlineData(TAllocationType.AT_Char, 40960, 0)]
        [InlineData(TAllocationType.AT_Char, 45056, 2)]
        [InlineData(TAllocationType.AT_Char, 43008, 2)]
        [InlineData(TAllocationType.AT_Char, 41948, 0)]
        [InlineData(TAllocationType.AT_Char, 42496, 2)]
        [InlineData(TAllocationType.AT_Char, 42487, 0)]
        [InlineData(TAllocationType.AT_Char, 42488, 2)]
        [InlineData(TAllocationType.AT_Int, 21244, 2)]
        [InlineData(TAllocationType.AT_Int, 21243, 0)]
        [InlineData(TAllocationType.AT_Double, 10622, 2)]
        [InlineData(TAllocationType.AT_Double, 10621, 0)]
        public void GenerationTest(TAllocationType type, int count, int generation)
        {
            Assert.Equal(generation, GarbageUtils.AllocateAndGetGeneration(type, count));
            GC.Collect(2, GCCollectionMode.Forced);
        }
    }
}
