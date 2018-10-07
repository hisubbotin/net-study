using System;
using Xunit;

namespace AdventureTime.Test
{
    public class UnitTest1
    {
        [Fact]
        public void TestSpecifyKind()
        {
            var st_date = new DateTime(2018, 01, 1, 12, 0, 15);
            var fin_date = new DateTime(2018, 01, 1, 12, 0, 15, DateTimeKind.Utc);
            var kind = DateTimeKind.Utc;
            Assert.Equal(Time.SpecifyKind(st_date, kind), fin_date);
        }

        [Fact]
        public void TestRoundTrip()
        {
            var date_1 = new DateTime(2018, 01, 1, 12, 0, 15, DateTimeKind.Local);
            var date_2 = new DateTime(2018, 01, 1, 12, 0, 15, DateTimeKind.Utc);
            var date_3 = new DateTime(2018, 01, 1, 12, 0, 15, DateTimeKind.Unspecified);
            Assert.Equal(Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(date_1)), date_1);
            Assert.Equal(Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(date_2)), date_2);
            Assert.Equal(Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(date_3)), date_3);
        }

        [Fact]
        public void TestToUtc()
        {
            var date_1 = new DateTime(2018, 01, 1, 12, 0, 15, DateTimeKind.Local);
            var date_2 = new DateTime(2018, 01, 1, 12, 0, 15, DateTimeKind.Utc);
            var date_3 = new DateTime(2018, 01, 1, 12, 0, 15, DateTimeKind.Unspecified);
            Assert.NotEqual(Time.ToUtc(date_1), date_1);
            Assert.Equal(Time.ToUtc(date_2), date_2);
            Assert.Equal(Time.ToUtc(date_3), Time.ToUtc(date_1));
        }
        
        [Fact]
        public void TestAddTenSeconds()
        {
            var date = new DateTime(2010, 1, 1, 1, 1, 59);
            var date_1 = new DateTime(2010, 1, 1, 1, 2, 9);
            var date_2 = new DateTime(2010, 1, 1, 1, 1, 48);
            Assert.Equal(Time.AddTenSeconds(date), date_1);
            Assert.Equal(Time.AddTenSecondsV2(date), date_1);
            Assert.NotEqual(Time.AddTenSeconds(date), date_2);
        }

        [Fact]
        public void TestGetHoursBetween()
        {
            var date_1 = new DateTime(2010, 1, 1, 1, 1, 59, DateTimeKind.Utc);
            var date_2 = new DateTime(2010, 1, 1, 10, 2, 9, DateTimeKind.Unspecified);
            Assert.Equal(Time.GetHoursBetween(date_1, date_2), 9);
        }

        [Fact]
        public void TestMoscowLondon()
        {
            Assert.Equal(Time.GetAdventureTimeDurationInMinutes_ver0_Dumb(), 180);
            Assert.Equal(Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb(), 60);
            Assert.Equal(Time.GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter(), 180);
            //Assert.Equal(Time.GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience(), 180);
            //Assert.Equal(Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience(), 60);
        }

        [Fact]
        public void TestBirthdays()
        {
            var birth_1 = new DateTime(2010, 1, 15, 17, 28, 00);
            var birth_2 = new DateTime(2010, 1, 15, 10, 28, 00);
            Assert.True(Time.AreEqualBirthdays(birth_1, birth_2));
        }
    }
}