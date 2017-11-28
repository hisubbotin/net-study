using System;
using System.Globalization;
using NodaTime;
using NodaTime.TimeZones;

namespace AdventureTime
{
    /// <summary>
    /// Класс методов для работы с временем.
    /// </summary>
    internal static class Time
    {
        /// <summary>
        /// Возвращает текущее локальное время.
        /// </summary>
        public static DateTime WhatTimeIsIt()
        {
            return DateTime.Now;
        }

        /// <summary>
        /// Возвращает текущее время в UTC.
        /// </summary>
        public static DateTime WhatTimeIsItInUtc()
        {
            return DateTime.UtcNow;
        }

        /// <summary>
        /// Возвращает объект <see cref="DateTime"/> с заданными временем и значением <see cref="DateTime.Kind"/>.
        /// </summary>
        /// <param name="dt">Объект <see cref="DateTime"/>, задающий время.</param>
        /// <param name="kind">Значение <see cref="DateTime.Kind"/>, задающий соответствующее свойство возвращаемого объекта.</param>
        /// <returns>Объект <see cref="DateTime"/> с заданными временем и значением <see cref="DateTime.Kind"/>.</returns>
        public static DateTime SpecifyKind(DateTime dt, DateTimeKind kind)
        {
            return DateTime.SpecifyKind(dt, kind);
        }

        /// <summary>
        /// Конвертирует объект <see cref="DateTime"/> в эквивалентное ему строковое представление времени в формате ISO 8601 (aka round-trip format).
        /// </summary>
        /// <param name="dt">Объект <see cref="DateTime"/> для конвертации в строку.</param>
        /// <returns>Строковое представление времени в формате ISO 8601.</returns>
        public static string ToRoundTripFormatString(DateTime dt)
        {
            return dt.ToString("o");
        }

        /// <summary>
        /// Конвертирует строковое представление времени в формате ISO 8601 в объект <see cref="DateTime"/>.
        /// </summary>
        /// <param name="dtStr">Строковое представление времени в формате ISO 8601.</param>
        /// <returns>Объект <see cref="DateTime"/>.</returns>
        public static DateTime ParseFromRoundTripFormat(string dtStr)
        {
            return DateTime.Parse(dtStr, null, DateTimeStyles.RoundtripKind);
        }

        /// <summary>
        /// Преобразует значение текущего объекта <see cref="DateTime"/> во время UTC.
        /// </summary>
        public static DateTime ToUtc(DateTime dt)
        {
            return dt.ToUniversalTime();
        }

        /// <summary>
        /// Возвращает время, передвинутое вперед на 10 секунд от заданного.
        /// </summary>
        /// <param name="dt">Заданное время.</param>
        /// <returns>Время, передвинутое вперед на 10 секунд от заданного</returns>
        public static DateTime AddTenSeconds(DateTime dt)
        {
            return dt.AddSeconds(10);
        }

        /// <summary>
        /// Возвращает время, передвинутое вперед на 10 секунд от заданного.
        /// </summary>
        /// <param name="dt">Заданное время.</param>
        /// <returns>Время, передвинутое вперед на 10 секунд от заданного</returns>
        public static DateTime AddTenSecondsV2(DateTime dt)
        {
            return dt + TimeSpan.FromSeconds(10);
        }

        /// <summary>
        /// Возвращает полное количество часов заданного временного отрезка.
        /// </summary>
        /// <param name="dt1">Начало временного отрезка.</param>
        /// <param name="dt2">Конец временного отрезка.</param>
        /// <returns>Полное количество часов заданного временного отрезка.</returns>
        public static int GetHoursBetween(DateTime dt1, DateTime dt2)
        {
            var ts = dt1.ToUniversalTime() - dt2.ToUniversalTime();
            return (int)ts.TotalHours;
        }

        /// <summary>
        /// Возвращает количество минут во временном промежутке, равном трем месяцам.
        /// </summary>
        [System.Obsolete]
        public static int GetTotalMinutesInThreeMonths()
        {
            var now = DateTime.Now;
            return (int)(now.AddMonths(3) - now).TotalMinutes;
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
            var londonTime = new DateTimeOffset(2010, 3, 28, 2, 15, 0, TimeSpan.FromHours(0));
            var moscowTime = new DateTimeOffset(2010, 3, 28, 2, 15, 0, TimeSpan.FromHours(3));

            return (int)(londonTime - moscowTime).TotalMinutes;
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
            var londonTime = new DateTimeOffset(2010, 3, 28, 1, 15, 0, TimeSpan.FromHours(0));
            var moscowTime = new DateTimeOffset(2010, 3, 28, 3, 15, 0, TimeSpan.FromHours(3));

            return (int)(londonTime - moscowTime).TotalMinutes;
        }

        /// <summary>
        /// Возвращает количество минут, проведенных в пути из Москвы в Лондон.
        /// </summary>
        public static int GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter()
        {
            var londonTime = new DateTimeOffset(2010, 3, 28, 2, 15, 0, TimeSpan.FromHours(1));
            var moscowTime = new DateTimeOffset(2010, 3, 28, 2, 15, 0, TimeSpan.FromHours(4));

            return (int)(londonTime - moscowTime).TotalMinutes;
        }

        // GetGenderSwappedAdventureTimeDurationInMinutes_ver1_FeelsSmarter опустим, там то же самое

        /// <summary>
        /// Возвращает количество минут, проведенных в пути из Москвы в Лондон.
        /// </summary>
        public static int GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience()
        { 
            const string moscowZoneId = "Russian Standard Time";
            const string londonZoneId = "GMT Standard Time";
            
            var moscowZonedTime = GetZonedTime(new DateTime(2010, 3, 28, 2, 15, 0), moscowZoneId);
            var londonZonedTime = GetZonedTime(new DateTime(2010, 3, 28, 2, 15, 0), londonZoneId);

            return (int)(londonZonedTime - moscowZonedTime).TotalMinutes;
        }

        /// <summary>
        /// Возвращает количество минут, проведенных в пути из Москвы в Лондон.
        /// </summary>
        public static int GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience()
        {
            const string moscowZoneId = "Russian Standard Time";
            const string londonZoneId = "GMT Standard Time";

            var moscowZonedTime = GetZonedTime(new DateTime(2010, 3, 28, 3, 15, 0), moscowZoneId);
            var londonZonedTime = GetZonedTime(new DateTime(2010, 3, 28, 1, 15, 0), londonZoneId);

            return (int)(londonZonedTime - moscowZonedTime).TotalMinutes;
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
            return (int)(toLondonZoned - fromMoscowZoned).TotalMinutes;
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
            return person1Birthday.ToUniversalTime().DayOfYear == person2Birthday.ToUniversalTime().DayOfYear;
        }
    }
}
