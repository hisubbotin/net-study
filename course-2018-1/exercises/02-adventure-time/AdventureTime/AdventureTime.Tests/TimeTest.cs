using System;
using Xunit;

namespace AdventureTime.Tests
{
    public class TimeTest
    {
        [Fact]
        public void Test_WhatTimeIsIt()
        {
            Assert.Equal(Time.WhatTimeIsIt().Kind, DateTimeKind.Local);
        }
        
        [Fact]
        public void Test_WhatTimeIsItUtc()
        {
            Assert.Equal(Time.WhatTimeIsItInUtc().Kind, DateTimeKind.Utc);
        }

        [Theory]
        [InlineData(DateTimeKind.Unspecified)]
        [InlineData(DateTimeKind.Local)]
        [InlineData(DateTimeKind.Utc)]
        public void Test_RoundTripFormatingTrue(DateTimeKind kind)
        {
            var dt = Time.SpecifyKind(new DateTime(2008, 6, 12, 18, 45, 15), kind);
            var newDt = Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(dt));
            Assert.True(dt.Equals(newDt));
        }

        [Fact]
        public void Test_RoundTripFormatingFalse()
        {
            var dt = new DateTime(2008, 6, 12, 18, 45, 15);
            var dt1 = Time.SpecifyKind(dt, DateTimeKind.Local);
            var dt2 = Time.SpecifyKind(dt, DateTimeKind.Unspecified);
            Assert.False(Time.ToRoundTripFormatString(dt1).Equals(Time.ToRoundTripFormatString(dt2)));
            
            dt1 = Time.SpecifyKind(dt, DateTimeKind.Local);
            dt2 = Time.SpecifyKind(dt, DateTimeKind.Utc);
            Assert.False(Time.ToRoundTripFormatString(dt1).Equals(Time.ToRoundTripFormatString(dt2)));
            
            dt1 = Time.SpecifyKind(dt, DateTimeKind.Unspecified);
            dt2 = Time.SpecifyKind(dt, DateTimeKind.Utc);
            Assert.False(Time.ToRoundTripFormatString(dt1).Equals(Time.ToRoundTripFormatString(dt2)));
        }

        [Theory]
        [InlineData(DateTimeKind.Unspecified)]
        [InlineData(DateTimeKind.Local)]
        [InlineData(DateTimeKind.Utc)]
        public void Test_ToUtc(DateTimeKind kind)
        {
            var dt = Time.SpecifyKind(new DateTime(2008, 6, 12, 18, 45, 15), kind);
            Assert.True(DateTimeKind.Utc.Equals(Time.ToUtc(dt).Kind));
        }

        [Fact]
        public void Test_AddTenSeconds()
        {
            var dt1 = new DateTime(2008, 6, 12, 18, 45, 15);
            var dt2 = new DateTime(2008, 6, 12, 18, 45, 25);

            Assert.Equal(Time.AddTenSeconds(dt1), dt2);
            Assert.Equal(Time.AddTenSecondsV2(dt1), dt2);
        }
    }
}