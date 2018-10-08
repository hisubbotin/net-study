using System;
using System.Collections.Generic;
using System.Linq;
using AdventureTime;
using Xunit;
using Xunit.Sdk;

namespace TestProject1
{
    
    public class TimeTest
    {
        List<DateTime> dates = new List<DateTime>();
        List<string> isoDates = new List<string>();
        DateTimeKind[] kinds = { DateTimeKind.Local, 
                                 DateTimeKind.Unspecified, 
                                 DateTimeKind.Utc};
        
        public TimeTest()
        {
            const int numDates = 5;
            for (int i = 0; i < numDates; i++)
            {
                dates.Append(new DateTime(2005 + i, 5 + i, 10 + i, 1 + i,13 + i, 10 * i));
            }
            for (int i = 0; i < dates.Count; i++)
            {
                isoDates.Append(dates[i].Year.ToString() + "-" +
                                dates[i].Month.ToString() + "-" +
                                dates[i].Day.ToString() + "T" +
                                dates[i].Hour.ToString() + ":" +
                                dates[i].Minute.ToString() + ":" +
                                dates[i].Second.ToString());
            }
        }
        [Fact]
        public void Test_SpecifyKind()
        {
            
            for (int j = 0; j < dates.Count; j++) {
                for (int i = 0; i < kinds.Length; i++) {
                    Assert.Equal( AdventureTime.Time.SpecifyKind(dates[j], kinds[i]),  
                                  DateTime.SpecifyKind(dates[j], kinds[i]));
                }
            } 
        }

        [Fact]
        public void Test_ToRoundTripFormatString()
        {
            
            for (int j = 0; j < dates.Count; j++)
            {
                Assert.Equal(Time.ToRoundTripFormatString(dates[j]), isoDates[j] );
            }
        }
        
        [Fact]
        public void Test_ParseFromRoundTripFormat()
        {
            for (int i = 0; i < dates.Count; i++)
            {
                for (int j = 0; j < kinds.Length; j++)
                {
                    DateTime expected = DateTime.SpecifyKind(dates[j], kinds[i]);
                    DateTime tested = Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(expected));
                    Assert.Equal(tested, expected);
                }
            }
            
        }

        [Fact]
        public void Test_AddTenSecond()
        {
            DateTime date = new DateTime(2018, 10, 30, 21, 12, 15);
            DateTime shiftedDate = new DateTime(2018, 10, 30, 21, 12, 25);
            Assert.Equal(AdventureTime.Time.AddTenSeconds(date), shiftedDate);
            
            date = new DateTime(2009, 8, 12, 9, 2, 27);
            shiftedDate = new DateTime(2009, 8, 12, 9, 2, 37);
            Assert.Equal(AdventureTime.Time.AddTenSeconds(date), shiftedDate);
        }
        
        [Fact]
        public void Test_GetHoursBetween()
        {
            for (int i = 0; i < dates.Count - 1; i++)
            {
                Assert.Equal(AdventureTime.Time.GetHoursBetween(dates[i], dates[i + 1]), 1);                
            }
        }

        [Fact]
        public void Test_GetAdventureTimeDurationInMinutes_ver0_Dumb()
        {
            Assert.Equal(AdventureTime.Time.GetAdventureTimeDurationInMinutes_ver0_Dumb(), -3 * 60);
        }
        
        [Fact]
        public void Test_GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb()
        {
            Assert.Equal(AdventureTime.Time.GetAdventureTimeDurationInMinutes_ver0_Dumb(), -3 * 60);
        }
        
        [Fact]
        public void Test_GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter()
        {
            Assert.Equal(AdventureTime.Time.GetAdventureTimeDurationInMinutes_ver0_Dumb(), -3 * 60);
        }
        
        [Fact]
        public void Test_GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience()
        {
            Assert.Equal(AdventureTime.Time.GetAdventureTimeDurationInMinutes_ver0_Dumb(), -3 * 60);
        }
        
        [Fact]
        public void Test_ThreeMonths()
        {
            Assert.Equal(AdventureTime.Time.GetTotalMinutesInThreeMonths(), (30 + 31 + 30 )* 24 * 60 );
        }
        
        [Fact]
        public void Test_AddTenSecondv2()
        {
            DateTime date = new DateTime(2018, 10, 12, 21, 12, 15);
            DateTime shiftedDate = new DateTime(2018, 10, 12, 21, 12, 25);
            Assert.Equal(AdventureTime.Time.AddTenSecondsV2(date), shiftedDate);
            
            date = new DateTime(2009, 8, 12, 9, 2, 27);
            shiftedDate = new DateTime(2009, 8, 12, 9, 2, 37);
            Assert.Equal(AdventureTime.Time.AddTenSecondsV2(date), shiftedDate);
        }
        
        [Fact]
        public void Test_AreEqualBirthdays()
        {
            /* Проверка на равенство */
            for (int i = 0; i < dates.Count; i++)
            {
                Assert.Equal(AdventureTime.Time.AreEqualBirthdays(dates[i],dates[i]), true);
            }
            
            /* Проверка на неравенство */
            for (int i = 0; i < dates.Count; i++)
            {
                Assert.Equal(AdventureTime.Time.AreEqualBirthdays(dates[i],dates[i].AddDays(2)), false);
            }
        }
    }
}