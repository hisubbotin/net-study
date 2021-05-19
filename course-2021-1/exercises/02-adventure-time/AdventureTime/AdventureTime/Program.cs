using System;

namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("WhatTimeIsIt: " + Time.WhatTimeIsIt());
            Console.WriteLine("WhatTimeIsItUtc: " + Time.WhatTimeIsItInUtc());

            Console.WriteLine();

            DateTime Now = Time.WhatTimeIsIt();
            DateTime NowLocal = Time.SpecifyKind(Now, DateTimeKind.Local);
            DateTime NowUtc = Time.SpecifyKind(Now, DateTimeKind.Utc);
            DateTime NowUn = Time.SpecifyKind(Now, DateTimeKind.Unspecified);
            Console.WriteLine("Now: " + Now);
            Console.WriteLine("SpecifyKind NowLocal: " + NowLocal);
            Console.WriteLine("SpecifyKind NowUtc: " + NowUtc);
            Console.WriteLine("SpecifyKind NowUn: " + NowUn);

            Console.WriteLine();

            Console.WriteLine("Now: " + Now);
            Console.WriteLine("ParseFromRoundTripFormat Now: " + Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(Now)));
            Console.WriteLine("ParseFromRoundTripFormat NowLocal: " + Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(NowLocal)));
            Console.WriteLine("ParseFromRoundTripFormat NowUtc: " + Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(NowUtc)));
            Console.WriteLine("ParseFromRoundTripFormat NowUn: " + Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(NowUn)));

            Console.WriteLine();

            Console.WriteLine("Now: " + Now);
            Console.WriteLine("ToRoundTripFormatString Now: " + Time.ToRoundTripFormatString(Now));
            Console.WriteLine("ToRoundTripFormatString NowLocal: " + Time.ToRoundTripFormatString(NowLocal));
            Console.WriteLine("ToRoundTripFormatString NowUtc: " + Time.ToRoundTripFormatString(NowUtc));
            Console.WriteLine("ToRoundTripFormatString NowUn: " + Time.ToRoundTripFormatString(NowUn));

            Console.WriteLine();

            Console.WriteLine("Now: " + Now);
            Console.WriteLine("AddTenSeconds Now: " + Time.AddTenSecondsV2(Now));
            Console.WriteLine("AddTenSeconds NowLocal: " + Time.AddTenSecondsV2(NowLocal));
            Console.WriteLine("AddTenSeconds NowUtc: " + Time.AddTenSecondsV2(NowUtc));
            Console.WriteLine("AddTenSeconds NowUn: " + Time.AddTenSecondsV2(NowUn));

            Console.WriteLine();

            Console.WriteLine("Now: " + Now);
            Console.WriteLine("AddTenSecondsV2 Now: " + Time.AddTenSecondsV2(Now));
            Console.WriteLine("AddTenSecondsV2 NowLocal: " + Time.AddTenSecondsV2(NowLocal));
            Console.WriteLine("AddTenSecondsV2 NowUtc: " + Time.AddTenSecondsV2(NowUtc));
            Console.WriteLine("AddTenSecondsV2 NowUn: " + Time.AddTenSecondsV2(NowUn));

            Console.WriteLine();

            Console.WriteLine("Now: " + Now);
            Console.WriteLine("GetHoursBetween NowUtc Now: " + Time.GetHoursBetween(NowUtc, Now));
            Console.WriteLine("GetHoursBetween NowUtc NowUtc.AddHours(2): " + Time.GetHoursBetween(NowUtc, NowUtc.AddHours(2)));
            Console.WriteLine("GetHoursBetween NowUtc.AddHours(2) NowUtc: " + Time.GetHoursBetween(NowUtc.AddHours(2), NowUtc));
            Console.WriteLine("GetHoursBetween NowUtc NowUtc.AddDays(2): " + Time.GetHoursBetween(NowUtc, NowUtc.AddDays(2)));

            Console.WriteLine();

            Console.WriteLine("GetTotalMinutesInThreeMonths: " + Time.GetTotalMinutesInThreeMonths());

            Console.WriteLine();

            Console.WriteLine("GetAdventureTimeDurationInMinutes_ver0_Dumb: " + Time.GetAdventureTimeDurationInMinutes_ver0_Dumb());
            Console.WriteLine("GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb: " + Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb());
            Console.WriteLine("GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter: " + Time.GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter());
            Console.WriteLine("GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience: " + Time.GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());
            Console.WriteLine("GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience: " + Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());

            Console.WriteLine();

            Console.WriteLine("AreEqualBirthdays Now Now: " + Time.AreEqualBirthdays(Now, Now));
            Console.WriteLine("AreEqualBirthdays Now NowUtc: " + Time.AreEqualBirthdays(Now, NowUtc));
            Console.WriteLine("AreEqualBirthdays Now NowUn: " + Time.AreEqualBirthdays(Now, NowUn));
            Console.WriteLine("AreEqualBirthdays NowUtc NowUn: " + Time.AreEqualBirthdays(NowUtc, NowUn));
            Console.WriteLine("AreEqualBirthdays Now NowUtc.AddHours(2): " + Time.AreEqualBirthdays(Now, NowUtc.AddHours(2)));
            Console.WriteLine("AreEqualBirthdays NowUtc NowUtc.AddYears(1): " + Time.AreEqualBirthdays(NowUtc, NowUtc.AddYears(1)));
            Console.WriteLine("AreEqualBirthdays NowUtc NowUtc.AddDays(1): " + Time.AreEqualBirthdays(NowUtc, NowUtc.AddDays(1)));
        }
    }
}
