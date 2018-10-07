using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace AdventureTime.Tests
{
    public class TestDataGeneratorTenSeconds : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {new DateTime(2010, 3, 28, 2, 15, 0), new DateTime(2010, 3, 28, 2, 15, 10)},
            new object[] {new DateTime(2011, 3, 28, 2, 15, 0), new DateTime(2011, 3, 28, 2, 15, 10)},
            new object[] {new DateTime(2011, 3, 10, 1, 15, 17), new DateTime(2011, 3, 10, 1, 15, 27)},
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    
    public class TestDataGeneratorKind : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {new DateTime(2010, 3, 28, 2, 15, 0), DateTimeKind.Local, DateTimeKind.Local},
            new object[] {new DateTime(2011, 3, 28, 2, 15, 0), DateTimeKind.Unspecified, DateTimeKind.Unspecified},
            new object[] {new DateTime(2011, 3, 10, 1, 15, 17), DateTimeKind.Utc, DateTimeKind.Utc},
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    
    public class TestDataGeneratorRoundTripFormatString : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {new DateTime(2010, 3, 28, 2, 15, 0), "2010-03-28T02:15:00.0000000"},
            new object[] {new DateTime(2011, 3, 28, 2, 15, 0), "2011-03-28T02:15:00.0000000"},
            new object[] {new DateTime(2011, 3, 10, 1, 15, 17), "2011-03-10T01:15:17.0000000"},
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    
    public class TestDataGeneratorParseFromRoundTripFormat : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {"2010-03-28T02:15:00.0000000", new DateTime(2010, 3, 28, 2, 15, 0)},
            new object[] {"2011-03-28T02:15:00.0000000", new DateTime(2011, 3, 28, 2, 15, 0)},
            new object[] {"2011-03-10T01:15:17.0000000", new DateTime(2011, 3, 10, 1, 15, 17)},
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    
    public class TestDataGeneratorToUtc : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {new DateTime(2010, 3, 28, 2, 15, 0), new DateTime(2010, 3, 27, 23, 15, 0)},
            new object[] {new DateTime(2011, 3, 28, 2, 15, 0), new DateTime(2011, 3, 27, 22, 15, 0)},
            new object[] {new DateTime(2011, 3, 10, 1, 15, 17), new DateTime(2011, 3, 9, 22, 15, 17)},
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    
    public class FunctionsTest
    {
        [Fact]
        public void Test_WhatTimeIsIt()
        {
            Assert.NotNull(Time.WhatTimeIsIt());
        }
        
        [Fact]
        public void Test_WhatTimeIsItInUtc()
        {
            Assert.NotNull(Time.WhatTimeIsItInUtc());
        }
        
        [Theory]
        [ClassData(typeof(TestDataGeneratorTenSeconds))]
        public void Test_AddTenSeconds(DateTime prev, DateTime next)
        {
            Assert.Equal(Time.AddTenSeconds(prev), next);
        }
        
        [Theory]
        [ClassData(typeof(TestDataGeneratorTenSeconds))]
        public void Test_AddTenSecondsV2(DateTime prev, DateTime next)
        {
            Assert.Equal(Time.AddTenSecondsV2(prev), next);
        }
        
        [Theory]
        [ClassData(typeof(TestDataGeneratorKind))]
        public void Test_SpecifyKind(DateTime dt, DateTimeKind kind, DateTimeKind trueKind)
        {
            Assert.Equal(Time.SpecifyKind(dt, kind).Kind, trueKind);
        }
        
        [Theory]
        [ClassData(typeof(TestDataGeneratorRoundTripFormatString))]
        public void Test_ToRoundTripFormatString(DateTime dt, string representation)
        {
            Assert.Equal(Time.ToRoundTripFormatString(dt), representation);
        }
        
        [Theory]
        [ClassData(typeof(TestDataGeneratorParseFromRoundTripFormat))]
        public void Test_ParseFromRoundTripFormat(string dtStr, DateTime dt)
        {
            Assert.Equal(Time.ParseFromRoundTripFormat(dtStr), dt);
        }
        
        [Theory]
        [ClassData(typeof(TestDataGeneratorToUtc))]
        public void Test_ToUtc(DateTime dt, DateTime dtUtc)
        {
            Assert.Equal(Time.ToUtc(dt), dtUtc);
        }
    }
}