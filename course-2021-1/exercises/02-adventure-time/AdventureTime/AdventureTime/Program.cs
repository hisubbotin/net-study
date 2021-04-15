using System;

namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine(Time.WhatTimeIsIt());
            Console.WriteLine(Time.WhatTimeIsItInUtc());
            
            Console.WriteLine();
            
            var dt1 = Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Local);
            var dt2 = Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Unspecified);
            var dt3 = Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Utc);
            
            Console.WriteLine(dt1);
            Console.WriteLine(dt2);
            Console.WriteLine(dt3);

            Console.WriteLine();
            
            Console.WriteLine(Time.ToRoundTripFormatString(Time.WhatTimeIsIt()));
            Console.WriteLine(Time.ToRoundTripFormatString(Time.WhatTimeIsItInUtc()));
            Console.WriteLine(Time.ToRoundTripFormatString(Time.SpecifyKind( Time.WhatTimeIsItInUtc(), 
                DateTimeKind.Utc)));
            
            Console.WriteLine();
            
            Console.WriteLine(Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(dt1)));
            Console.WriteLine(Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(dt2)));
            Console.WriteLine(Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(dt3)));
            
            Console.WriteLine();
            
            Console.WriteLine(Time.ToUtc(dt1));
            Console.WriteLine(Time.ToUtc(dt2));
            Console.WriteLine(Time.ToUtc(dt3));
            
            Console.WriteLine();
            
            Console.WriteLine(Time.AddTenSeconds(dt1));
            Console.WriteLine(Time.AddTenSecondsV2(dt1));
            
            Console.WriteLine();
            
            Console.WriteLine(Time.GetHoursBetween(dt1, dt1.AddHours(3)));
            Console.WriteLine(Time.GetHoursBetween(Time.WhatTimeIsItInUtc(), Time.WhatTimeIsIt()));
            
            Console.WriteLine();
            
            Console.WriteLine(Time.GetTotalMinutesInThreeMonths());
            
            Console.WriteLine();
            
            Console.WriteLine(Time.AreEqualBirthdays(dt1, dt3));
            Console.WriteLine(Time.AreEqualBirthdays(dt1, dt3 + TimeSpan.FromDays(1)));
        }
    }
}
