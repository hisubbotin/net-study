using System;
using Xunit;

namespace AdventureTime.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test_GetAdventureTimeDurationInMinutes_ver0_Dumb()
        {
            Assert.Equal(180, Time.GetAdventureTimeDurationInMinutes_ver0_Dumb());
        }

        [Fact]
        public void Test_GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb()
        {
            Assert.Equal(60, Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb());
        }

        [Fact]
        public void Test_GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter()
        {
            Assert.Equal(180, Time.GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter());
        }

        [Fact]
        public void Test_GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience()
        {
            Assert.Equal(Time.GetAdventureTimeDurationInMinutes_ver3_NodaTime(),
                Time.GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());
        }

        [Fact]
        public void Test_GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience()
        {
            Assert.Equal(Time.GetAdventureTimeDurationInMinutes_ver3_NodaTime(),
                Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());
        }

        [Theory]
        [InlineData("1999-01-16T02:00:00", "1996-01-16T05:28:34", true)]
        [InlineData("1999-04-16T02:00:00", "1996-04-16T05:28:34", true)]
        [InlineData("1999-04-17T02:00:00", "1996-04-16T05:28:34", false)]
        public void Test_AreEqualBirthdays(string person1Birthday, string person2Birthday, bool answer)
        {
            Assert.Equal(answer, Time.AreEqualBirthdays(DateTime.Parse(person1Birthday), DateTime.Parse(person2Birthday)));
        }
    }
}
