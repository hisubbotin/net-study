using System;
using Xunit;

namespace TestProject1
{
    public class TimeTest
    {
        [Fact]
        public void TestSpecifyKind()
        {
            var st_date = new DateTime(2018, 01, 1, 12, 0, 15);
            var fin_date = new DateTime(2018, 01, 1, 12, 0, 15, DateTimeKind.Utc);
            var kind = DateTimeKind.Utc;
            Assert.Equal(Time.SpecifyKind);
        }
    }
}