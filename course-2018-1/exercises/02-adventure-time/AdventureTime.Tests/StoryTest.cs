using Xunit;

namespace AdventureTime.Tests
{
    public class StoryTest
    {
        [Fact]
        public void Test_GetAdventureTimeDurationInMinutes_ver0_Dumb()
        {
            Assert.Equal(Time.GetAdventureTimeDurationInMinutes_ver0_Dumb(), 180);
        }
        
        [Fact]
        public void Test_GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb()
        {
            Assert.Equal(Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb(), 60);
        }
        
        [Fact]
        public void Test_GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter()
        {
            Assert.Equal(Time.GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter(), 180);
        }
        
        [Fact]
        public void Test_GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience()
        {
            Assert.Equal(Time.GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience(), 120);
        }
        
        [Fact]
        public void Test_GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience()
        {
            Assert.Equal(Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience(), 120);
        }
    }
}