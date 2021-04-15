using System;

namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine(Time.WhatTimeIsIt());
            Console.WriteLine(Time.WhatTimeIsItInUtc());
            Console.WriteLine(Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Local));
            Console.WriteLine(Time.ToRoundTripFormatString(Time.WhatTimeIsIt()));
            Console.WriteLine(Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(Time.WhatTimeIsIt())));
            Console.WriteLine(Time.AddTenSeconds(Time.WhatTimeIsIt()));
            Console.WriteLine(Time.GetHoursBetween(Time.WhatTimeIsIt(), Time.WhatTimeIsItInUtc()));
            Console.WriteLine(Time.GetHoursBetween(Time.WhatTimeIsIt(), Time.WhatTimeIsItInUtc().AddDays(2)));
            Console.WriteLine(Time.GetTotalMinutesInThreeMonths());
            Console.WriteLine(Time.AreEqualBirthdays(Time.WhatTimeIsIt(), Time.WhatTimeIsIt()));
            DateTime person1Birthday = new DateTime(2009, 8, 1, 0, 0, 0);
            DateTime person2Birthday = new DateTime(2009, 8, 1, 12, 0, 0);
            Console.WriteLine(Time.AreEqualBirthdays(person1Birthday, person2Birthday));
            DateTime person1Birthday_ = new DateTime(2009, 8, 1, 12, 0, 0);
            DateTime person2Birthday_ = new DateTime(2009, 8, 1, 12, 0, 0);
            Console.WriteLine(Time.AreEqualBirthdays(person1Birthday_, person2Birthday_));
        }
    }
}
