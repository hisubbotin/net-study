using System;
using Xunit;

namespace AdventureTime.Tests
{
    public class AdventureTimeSagaTests
    {
        [Fact]
        public void Test_MaleDumbVersions()
        {
            Assert.Equal(Time.GetAdventureTimeDurationInMinutes_ver0_Dumb(), Time.GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter());
        }

        [Fact]
        public void Test_SmartVersionsWork()
        {
            Assert.NotEqual(Time.GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter(), 
                Time.GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());

            Assert.NotEqual(Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb(), 
                Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());
        }

    }

}
