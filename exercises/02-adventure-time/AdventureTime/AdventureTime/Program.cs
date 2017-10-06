using System;
using NodaTime;
using NodaTime.TimeZones;

namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Hello World!");

            var now = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified);
            var dt1 = new DateTimeOffset(now, TimeSpan.FromHours(4));
            var dt2 = new DateTimeOffset(now, TimeSpan.FromHours(8));

            Console.WriteLine(dt2 - dt1);

            var fromMoscow = new DateTimeOffset(2010, 3, 28, 3, 15, 0, TimeSpan.FromHours(4));
            var toLondon = new DateTimeOffset(2010, 3, 28, 1, 15, 0, TimeSpan.FromHours(1));

            Console.WriteLine(toLondon - fromMoscow);

            fromMoscow = new DateTimeOffset(2010, 3, 28, 2, 15, 0, TimeSpan.FromHours(4));
            toLondon = new DateTimeOffset(2010, 3, 28, 2, 15, 0, TimeSpan.FromHours(1));

            Console.WriteLine(toLondon - fromMoscow);

            TestNodaTime();
        }

        private static void TestNodaTime()
        {
            const string londonTimeZoneId = "Europe/London";
            const string moscowTimeZoneId = "Europe/Moscow";

            var fromMoscow = new LocalDateTime(2010, 3, 28, 2, 15, 0);
            var toLondon = new LocalDateTime(2010, 3, 28, 2, 15, 0);

            var fromMoscowInstant = GetInstantFromZonedLocalTime(fromMoscow, moscowTimeZoneId);
            var toLondonInstant = GetInstantFromZonedLocalTime(toLondon, londonTimeZoneId);
            Console.WriteLine(toLondonInstant - fromMoscowInstant);

            fromMoscow = new LocalDateTime(2010, 3, 28, 3, 15, 0);
            toLondon = new LocalDateTime(2010, 3, 28, 1, 15, 0);

            fromMoscowInstant = GetInstantFromZonedLocalTime(fromMoscow, moscowTimeZoneId);
            toLondonInstant = GetInstantFromZonedLocalTime(toLondon, londonTimeZoneId);
            Console.WriteLine(toLondonInstant - fromMoscowInstant);
        }

        private static Instant GetInstantFromZonedLocalTime(LocalDateTime localTime, string timeZoneId)
        {
            var timeZone = TzdbDateTimeZoneSource.Default.ForId(timeZoneId);
            var zonedTime = localTime.InZoneLeniently(timeZone);

            Console.WriteLine(zonedTime);

            return zonedTime.ToInstant();
        }
    }
}
