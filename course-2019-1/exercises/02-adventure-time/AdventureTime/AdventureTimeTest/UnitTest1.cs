using System;
using System.Runtime.InteropServices;
using Xunit;




using AdventureTime;
using NodaTime.Calendars;


namespace AdventureTimeTest
{
    public class UnitTest1
    {
       

        [Fact]
        public void TestLocalTime()
        {
            Assert.InRange((Time.WhatTimeIsIt() - DateTime.Now).TotalMilliseconds, -1000, 1000);
        }
        
        [Fact]
        public void TestUtcTime()
        {
            Assert.InRange((Time.WhatTimeIsItInUtc() - DateTime.UtcNow).TotalMilliseconds, -1000, 1000);
        }
        
        
        [Theory]
        [InlineData(2010, 3, 28, DateTimeKind.Local)]
        [InlineData(2012, 3, 28, DateTimeKind.Local)]
        [InlineData(2013, 3, 28, DateTimeKind.Local)]
        public void TestKind(int year, int month, int day, DateTimeKind type)
        {
            var date = new DateTime(year, month, day, 0, 0, 0);
            Assert.Equal(Time.SpecifyKind(date, type), DateTime.SpecifyKind(date, type));
        }
        
        [Theory]
        [InlineData(2010, 3, 28, "2010-03-28T00:00:00.0000000")]
        [InlineData(2012, 3, 9, "2012-03-09T00:00:00.0000000")]
        [InlineData(2013, 8, 28, "2013-08-28T00:00:00.0000000")]
        public void TestStringFormat(int year, int month, int day, string answer)
        {
            Assert.Equal(Time.ToRoundTripFormatString(new DateTime(year, month, day)), answer);
        }
        
        [Theory]
        [InlineData(2010, 3, 28, "2010-03-28T00:00:00.0000000")]
        [InlineData(2012, 3, 9, "2012-03-09T00:00:00.0000000")]
        [InlineData(2013, 8, 28, "2013-08-28T00:00:00.0000000")]
        public void TestReverseStringFormat(int year, int month, int day, string answer)
        {
            Assert.Equal(Time.ParseFromRoundTripFormat(answer), new DateTime(year, month, day));
        }
        
        
        [Theory]
        [InlineData(2010, 3, 28, DateTimeKind.Local)]
        [InlineData(2010, 3, 28, DateTimeKind.Utc)]
        [InlineData(2010, 3, 28, DateTimeKind.Unspecified)]
        public void TestToUtc(int year, int month, int day, DateTimeKind type)
        {
            var date = new DateTime(year, month, day, 0, 0, 0, type);
            Assert.Equal(Time.ToUtc(date), date.ToUniversalTime());
        }
        
        [Theory]
        [InlineData(2010, 3, 28, 23, 59, 10, 2010, 3, 28, 23, 59, 20)]
        [InlineData(2010, 12, 31, 23, 59, 50, 2011, 1, 1, 0, 0, 0)]
        [InlineData(2010, 3, 28, 23, 59, 55, 2010, 3, 29, 0, 0, 5)]
        public void TestAddSecondsV1(int year1, int month1, int day1, int hour1, int minute1, int second1,
                                    int year2, int month2, int day2, int hour2, int minute2, int second2)
        {
            var date1 = new DateTime(year1, month1, day1, hour1, minute1, second1);
            var date2 = new DateTime(year2, month2, day2, hour2, minute2, second2);
            Assert.Equal(Time.AddTenSeconds(date1), date2);
        }
        
        [Theory]
        [InlineData(2010, 3, 28, 23, 59, 10, 2010, 3, 28, 23, 59, 20)]
        [InlineData(2010, 12, 31, 23, 59, 50, 2011, 1, 1, 0, 0, 0)]
        [InlineData(2010, 3, 28, 23, 59, 55, 2010, 3, 29, 0, 0, 5)]
        public void TestAddSecondsV2(int year1, int month1, int day1, int hour1, int minute1, int second1,
            int year2, int month2, int day2, int hour2, int minute2, int second2)
        {
            var date1 = new DateTime(year1, month1, day1, hour1, minute1, second1);
            var date2 = new DateTime(year2, month2, day2, hour2, minute2, second2);
            Assert.Equal(Time.AddTenSecondsV2(date1), date2);
        }
        
        [Theory]
        [InlineData(2010, 3, 28, 23, 59, 10, 2010, 3, 28, 23, 59, 20, 0)]
        [InlineData(2010, 12, 31, 23, 59, 50, 2011, 1, 1, 5, 0, 51, 5)]
        [InlineData(2010, 3, 28, 23, 59, 55, 2010, 3, 29, 0, 0, 5, 0)]
        public void TestHourDifference(int year1, int month1, int day1, int hour1, int minute1, int second1,
            int year2, int month2, int day2, int hour2, int minute2, int second2, int answer)
        {
            var date1 = new DateTime(year1, month1, day1, hour1, minute1, second1);
            var date2 = new DateTime(year2, month2, day2, hour2, minute2, second2);
            Assert.Equal(Time.GetHoursBetween(date1, date2), answer);
        }
        
        [Theory]
        [InlineData(2010, 3, 28)]
        [InlineData(2010, 5, 28)]
        [InlineData(2010, 8, 28)]
        public void Test3MonthDuration(int year, int month, int day)
        {
            var date1 = new DateTime(year, month, day);
            var date2 = new DateTime(year, month + 3, day);

            var minutes = (int) (date2.Subtract(date1)).TotalMinutes;
            
            Assert.InRange(Time.GetTotalMinutesInThreeMonths() - minutes, -5000, 5000);
        }
        
        #region Adventure time saga Test
    
        [Fact]
        public void TestGetAdventureTimeDuration0()
        {
            Assert.Equal(3 * 60, Time.GetAdventureTimeDurationInMinutes_ver0_Dumb());
        }
    
    
        [Fact]
        public void TestGetAdventureTimeDuration1()
        {
            Assert.Equal(60, Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb());
        }
        
        
        [Fact]
        public void TestGetAdventureTimeDuration2()
        {
            Assert.Equal(180, Time.GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter());
        }
        
        
       
            
        [Fact]
        public void TestGetAdventureTimeDuration5()
        {
            Assert.Equal(120, Time.GetAdventureTimeDurationInMinutes_ver3_NodaTime());
        }
        
        [Theory]
        [InlineData(2010, 4, 28, 23, 59, 10, DateTimeKind.Local, 2010, 3, 28, 23, 59, 20, DateTimeKind.Utc, false)]
        [InlineData(2010, 12, 31, 20, 59, 50, DateTimeKind.Utc, 2010, 12, 31, 5, 0, 51, DateTimeKind.Local, true)]
        [InlineData(2010, 3, 28, 23, 59, 55, DateTimeKind.Local, 2010, 3, 30, 0, 0, 5, DateTimeKind.Local, false)]
        public void TestBirthday(int year1, int month1, int day1, int hour1, int minute1, int second1, DateTimeKind kind1,
            int year2, int month2, int day2, int hour2, int minute2, int second2, DateTimeKind kind2, bool answer)
        {
            var date1 = new DateTime(year1, month1, day1, hour1, minute1, second1, kind1);
            var date2 = new DateTime(year2, month2, day2, hour2, minute2, second2, kind2);
            Assert.Equal(Time.AreEqualBirthdays(date1, date2), answer);
        }
    
        #endregion
    }
    
}