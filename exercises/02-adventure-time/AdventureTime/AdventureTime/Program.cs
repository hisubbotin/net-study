namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(DateTime.MinValue);
            Console.WriteLine(DateTime.MaxValue);

            Console.WriteLine(DateTime.Now);
            Console.WriteLine(DateTime.UtcNow.Kind);
            Console.WriteLine(new DateTime(2017, 10, 18).Kind);

            Console.WriteLine(DateTime.Now.ToUniversalTime());
            Console.WriteLine(DateTime.UtcNow.ToUniversalTime());
            Console.WriteLine(new DateTime(2017, 10, 18).ToUniversalTime());

            Console.WriteLine(DateTimeOffset.MinValue);
            Console.WriteLine(DateTimeOffset.MaxValue);

            Console.WriteLine(TimeSpan.MinValue);
            Console.WriteLine(new TimeSpan(10, 20, 13, 100).Minutes);

            var gmt = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
            var msd = TimeZoneInfo.FindSystemTimeZoneById("Russian Standard Time");

            var fromLondon = new DateTimeOffset(2010, 3, 28, 1, 15, 0, TimeSpan.FromHours(1));
            var toMoscow = new DateTimeOffset(2010, 3, 28, 5, 0, 0, TimeSpan.FromHours(4));

            var fL = TimeZoneInfo.ConvertTime(fromLondon, gmt);
            var tM = TimeZoneInfo.ConvertTime(toMoscow, msd);

            Console.WriteLine(fL.LocalDateTime);

            Console.WriteLine(toMoscow - fromLondon);
            Console.WriteLine(tM - fL);

            Console.WriteLine("------------------------------");

            Console.WriteLine(Time.WhatTimeIsIt());
            Console.WriteLine(Time.WhatTimeIsItInUtc());
            Console.WriteLine(Time.ParseDateTime("12/12/2012"));
            Console.WriteLine(Time.ToUtc(DateTime.Now));
            Console.WriteLine(Time.AddTenSeconds(Time.ParseDateTime("12/12/2012")));
            Console.WriteLine(Time.GetHoursBetween(DateTime.Now, Time.ToUtc(DateTime.Now)));
            Console.WriteLine((DateTime.Now - DateTime.UtcNow).TotalHours);
            Console.WriteLine(Time.GetTotalMinutesInThreeMonths());
            Console.WriteLine(Time.GetParticularTravelDurationInMinutes());
            Console.WriteLine(Time.GetBirthdate());

        }
    }
}
