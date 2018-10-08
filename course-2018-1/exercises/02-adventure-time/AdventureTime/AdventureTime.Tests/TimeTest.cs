using System;
using Xunit;

namespace AdventureTime.Tests {
    public class TimeTest {
        private static readonly DateTimeKind[] Kinds = {DateTimeKind.Local, DateTimeKind.Unspecified, DateTimeKind.Utc};

        [Fact]
        public void NowTimeTest() {
            var dt = Time.WhatTimeIsIt();
            Assert.Equal(dt, dt);
        }

        [Fact]
        public void UtcNowTest() {
            var dt = Time.WhatTimeIsItInUtc();
            Assert.Equal(dt, dt);
        }

        [Fact]
        public void ToRoundTripFormatStringAndReverseTest() {
            var rnd = new Random();
            foreach (var kind in Kinds) {
                for (var i = 0; i < 100; ++i) {
                    var dt = Time.SpecifyKind(Time.WhatTimeIsIt().AddMinutes(rnd.Next(-600000, 600000)), kind);
                    Assert.Equal(Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(dt)), dt);
                }
            }
        }
        
        [Fact]
        public void TotalMinutesInThreeMonthsTest() {
            Assert.Equal(Time.GetTotalMinutesInThreeMonths(), 60 * 24 * (31 + 28 + 31));
        }
        
        [Fact]
        public void AreEqualBirthdaysTest() {
            var dt1 = new DateTime(2018, 06, 21, 00, 00, 00);
            var dt2 = new DateTime(2018, 06, 21, 3, 00, 00);
            Assert.True(Time.AreEqualBirthdays(dt1, dt2));
            Assert.False(Time.AreEqualBirthdays(dt1.ToUniversalTime(), dt2.ToUniversalTime()));
            
            dt1 = new DateTime(2018, 06, 20, 23, 00, 00);
            dt2 = new DateTime(2018, 06, 21, 3, 00, 00);
            Assert.False(Time.AreEqualBirthdays(dt1, dt2));
        }
    }
}
