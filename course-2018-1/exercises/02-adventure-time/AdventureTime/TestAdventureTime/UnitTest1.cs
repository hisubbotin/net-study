using System;
using Xunit;

namespace TestAdventureTime
{
    public class UnitTest1
    {
        static DateTimeKind[] Kinds = {DateTimeKind.Local, DateTimeKind.Unspecified, DateTimeKind.Utc};
        
        [Fact]
        public void TestWhatTimeIsIt()
        {
            var dt = Time.WhatTimeIsIt();
            foreach (var kind in Kinds)
            {
                Console.WriteLine(Time.ToRoundTripFormatString(Time.SpecifyKind(dt, kind)));
            }
        }
        
        [Fact]
        public void TestWhatTimeIsItInUtc()
        {
            var dt = Time.WhatTimeIsItInUtc();
            foreach (var kind in Kinds)
            {
                Console.WriteLine(Time.ToRoundTripFormatString(Time.SpecifyKind(dt, kind)));
            }
        }
    }
}