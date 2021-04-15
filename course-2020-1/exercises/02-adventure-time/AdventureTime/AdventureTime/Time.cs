using System;
using System.Globalization;
using NodaTime;
using NodaTime.TimeZones;

namespace AdventureTime
{
    internal static class Time
    {
        public static DateTime WhatTimeIsIt()
        {
            return DateTime.Now;
        }
        
        public static DateTime WhatTimeIsItInUtc()
        {
            return DateTime.UtcNow;
        }
        
        public static DateTime SpecifyKind(DateTime dt, DateTimeKind kind)
        {
            return DateTime.SpecifyKind(dt, kind);
        }
        
        public static string ToRoundTripFormatString(DateTime dt)
        {
            return dt.ToString("O");
        }
        
        public static DateTime ParseFromRoundTripFormat(string dtStr)
        {
            return DateTime.Parse(dtStr, null, DateTimeStyles.RoundtripKind);
        }
        
        public static DateTime ToUtc(DateTime dt)
        {
            return DateTime.SpecifyKind(dt, DateTimeKind.Utc);
        }
        
        public static DateTime AddTenSeconds(DateTime dt)
        {
            return dt.Add(TimeSpan.FromSeconds(10));
        }
        
        public static DateTime AddTenSecondsV2(DateTime dt)
        {
            return dt + TimeSpan.FromSeconds(10);
        }
        
        public static int GetHoursBetween(DateTime dt1, DateTime dt2)
        {
            return Math.Abs((int) (dt1 - dt2).TotalHours);
        }
        
        public static int GetTotalMinutesInThreeMonths()
        {
            return (int) TimeSpan.FromDays(90).TotalMinutes;
        }

        #region Adventure time saga

        /// <summary>
        /// Возвращает количество минут, проведенных в пути из Москвы в Лондон.
        /// </summary>
        /// <remarks>
        /// Финн и Джейк, плотно поужинав, решили, что спать для слабаков и настало время приключений, поэтому быстро собрали вещи, уложили спать БиМО и отправились из воображаемой Москвы в воображаемый Лондон верхом на леди Ливнероге.
        /// Сколько минут они провели в пути, если Москву они покинули 28.03.2010 в 02:15 по местному времени, а в Лондон прибыли в 28.03.2010 в 02:15 по местному?
        /// </remarks>
        public static int GetAdventureTimeDurationInMinutes_ver0_Dumb()
        {
            var london = new DateTimeOffset(2010, 3, 28, 2, 15, 0, TimeSpan.Zero);
            var moscow = new DateTimeOffset(2010, 3, 28, 2, 15, 0, TimeSpan.FromHours(3));
            return Math.Abs((int) (moscow - london).TotalMinutes);
        }

        /// <summary>
        /// Возвращает количество минут, проведенных в пути из Москвы в Лондон.
        /// </summary>
        /// <remarks>
        /// Фионна и Кейк, поужинав заварными пироженками от принца Жвачки, решили, что они еще слишком молоды чтобы спать по ночам и сейчас самое время для приключений! Дамы собрали вещи, уложили спать БиМО и отправились из 
        /// другой воображаемой Москвы в другой воображаемый Лондон верхом на лорде Монохроме.
        /// Сколько минут они провели в путешествии, если Москву они покинули 28.03.2010 в 03:15 по местному времени, а в Лондон прибыли в 28.03.2010 в 01:15 по местному?
        /// </remarks>
        public static int GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb()
        {
            var london = new DateTimeOffset(2010, 3, 28, 1, 15, 0, TimeSpan.Zero);
            var moscow = new DateTimeOffset(2010, 3, 28, 3, 15, 0, TimeSpan.FromHours(3));
            return Math.Abs((int) (moscow - london).TotalMinutes);
        }

        /// <summary>
        /// Возвращает количество минут, проведенных в пути из Москвы в Лондон.
        /// </summary>
        public static int GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter()
        {
            var london = new DateTimeOffset(2010, 3, 28, 1, 15, 0, TimeSpan.FromHours(1));
            var moscow = new DateTimeOffset(2010, 3, 28, 3, 15, 0, TimeSpan.FromHours(4));
            return Math.Abs((int) (moscow - london).TotalMinutes);
        }

        /// <summary>
        /// Возвращает количество минут, проведенных в пути из Москвы в Лондон.
        /// </summary>
        public static int GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience()
        {
            const string moscowZoneIdWindaStyle = "Russian Standard Time";
            const string londonZoneIdWindaStyle = "GMT Standard Time";
            
            const string londonZoneId = "Europe/London"; // на яблоке другие ID пам-пам
            const string moscowZoneId = "Europe/Moscow"; // на яблоке другие ID пам-пам
            
            var london = GetZonedTime(new LocalDateTime(2010, 3, 28, 2, 15, 0), londonZoneId);
            var moscow = GetZonedTime(new LocalDateTime(2010, 3, 28, 2, 15, 0), moscowZoneId);

            return Math.Abs((int) (moscow - london).TotalMinutes);
        }

        /// <summary>
        /// Возвращает количество минут, проведенных в пути из Москвы в Лондон.
        /// </summary>
        public static int GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience()
        {
            // Интереееесно, будет ли один в один метод выдавать одинаковые результаты? Даже не знаю Meh
            const string londonTimeZoneId = "Europe/London";
            const string moscowTimeZoneId = "Europe/Moscow";
            
            var london = GetZonedTime(new LocalDateTime(2010, 3, 28, 2, 15, 0), londonTimeZoneId);
            var moscow = GetZonedTime(new LocalDateTime(2010, 3, 28, 2, 15, 0), moscowTimeZoneId);

            return Math.Abs((int) (moscow - london).TotalMinutes);
        }

        private static DateTimeOffset GetZonedTime(DateTime localTime, string timeZoneId)
        {
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);

            // и немножечко полезной доп инфы в консоль:
            var isInvalid = timeZone.IsInvalidTime(localTime);
            var isDaylightSaving = timeZone.IsDaylightSavingTime(localTime);
            var isAmbiguous = timeZone.IsAmbiguousTime(localTime);

            Console.WriteLine($"{localTime}: invalid = {isInvalid}; daylight = {isDaylightSaving}; ambigous = {isAmbiguous}");

            // несмотря на то, что DateTimeOffset хранит локальное время + смещение, в действительности здесь мы вычисляем правильное абсолютное значение (время UTC)
            return new DateTimeOffset(localTime, timeZone.GetUtcOffset(localTime));
        }


        // Ниже пример решения с использованием библиотеки NodaTime

        /// <summary>
        /// Возвращает количество минут, проведенных в пути из Москвы в Лондон.
        /// </summary>
        public static int GetAdventureTimeDurationInMinutes_ver3_NodaTime()
        {
            const string londonTimeZoneId = "Europe/London";
            const string moscowTimeZoneId = "Europe/Moscow";

            // Тип LocalDateTime не хранит информации о том, где "наблюдается" это время, но явно говорит, что данное время нужно трактовать как есть и никаких неявных преобразований не делать.
            // Более того, его апи не позволяет тебе сделать что-то неявно или трактовать это время как-то иначе. Например, его невозможно превратить в абсолютное время UTC (в Noda Time ему отвечает тип Instant)
            var from = new LocalDateTime(2010, 3, 28, 2, 15, 0);
            var to = new LocalDateTime(2010, 3, 28, 2, 15, 0);

            //Тип ZonedDateTime - это ровным счетом LocalDateTime + DateTimeZone (локальное время + часовой пояс). Вот из него абсолютное время уже можно получить (информации достаточно).
            var fromMoscowZoned = GetZonedTime(from, moscowTimeZoneId);
            var toLondonZoned = GetZonedTime(to, londonTimeZoneId);
            return (int) (toLondonZoned - fromMoscowZoned).TotalMinutes;
        }

        private static ZonedDateTime GetZonedTime(LocalDateTime localTime, string timeZoneId)
        {
            // здесь используется не windows-specific словарь идентификаторов, а более "принятый" сообществом
            var timeZone = TzdbDateTimeZoneSource.Default.ForId(timeZoneId);

            // обрати внимание, есть два метода, превращающих локальное время + часовой пояс в ZonedDateTime: InZoneLeniently и InZoneStrictly. Первый не ругается на сомнительное локальное время, второй - бросает исключение. Для наглядности конкретно этого примера я использовал "снисходительный" вариант.
            return localTime.InZoneLeniently(timeZone);
        }

        #endregion

        /// <summary>
        /// Указывает, родились ли два человека в один день.
        /// </summary>
        /// <param name="person1Birthday">День рождения первого человека.</param>
        /// <param name="person2Birthday">День рождения второго человека.</param>
        /// <returns>True - если родились в один день, иначе - false.</returns>
        internal static bool AreEqualBirthdays(DateTime person1Birthday, DateTime person2Birthday)
        {
            return person1Birthday.Day.Equals(person2Birthday.Day) && person1Birthday.Month.Equals(person2Birthday.Month);
        }
    }
}
