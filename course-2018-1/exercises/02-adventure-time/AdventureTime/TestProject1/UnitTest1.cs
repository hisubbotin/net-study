using System;
using System.Collections.Generic;
using System.Linq;
using AdventureTime;
using Xunit;

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
    }
}