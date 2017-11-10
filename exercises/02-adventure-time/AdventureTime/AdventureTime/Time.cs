﻿using System;
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
            return DateTime.Parse(dtStr);
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
            return (int)(dt2.ToUniversalTime() - dt1.ToUniversalTime()).TotalHours;
        }

        /// <summary>
        /// Возвращает количество минут во временном промежутке, равном трем месяцам.
        /// </summary>
        public static int GetTotalMinutesInThreeMonths()
        {
            throw new NotImplementedException();
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
            /*
                Как ты понимаешь, время выбрано не просто так, но для начала давай прикинемся совсем наивными.
                Лондон находится в часовом поясе +0 (GMT), а Москва в +3 (MSK). Воспользуйся DateTimeOffset, чтобы задать правильное время, и посчитай разницу в минутах. Посмотри на результат.
                Держи, заготовочку для копипасты:
                    - 2010, 3, 28, 2, 15, 0
            */
            var moscowTime = new DateTimeOffset(2010, 3, 28, 2, 15, 0, TimeSpan.FromHours(3));
            var londonTime = new DateTimeOffset(2010, 3, 28, 2, 15, 0, TimeSpan.FromHours(0));
            return (int) (londonTime - moscowTime).TotalMinutes;
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
            /*
                Здесь то же самое. Сорри, немного бездумного кодинга. Вот заготовочка для копипасты времени:
                    - 2010, 3, 28, 3, 15, 0
                    - 2010, 3, 28, 1, 15, 0
            */
            var moscowTime = new DateTimeOffset(2010, 3, 28, 3, 15, 0, TimeSpan.FromHours(3));
            var londonTime = new DateTimeOffset(2010, 3, 28, 1, 15, 0, TimeSpan.FromHours(0));
            return (int)(londonTime - moscowTime).TotalMinutes;
        }

        /// <summary>
        /// Возвращает количество минут, проведенных в пути из Москвы в Лондон.
        /// </summary>
        public static int GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter()
        {
            /*
                Глава вторая, в которой оказывается, что в некоторых странах принята такая штука как летнее время (не совсем то, про которое поет Лана Дель Рей).

                Внимательный читатель мог усомниться в данных мной часовых поясах и их смещении относительно UTC и был бы прав.
                На самом деле смещения таковы: Лондон +1 (BST - British Summer Time), Москва +4 (MSD - Moscow Daylight Time).
                Давай теперь учтем правильное смещение. Я понимаю, что это очевидно, что результат не изменится, но тебе же не сложно скопипастить и просто поменять смещения?
            */
            var moscowTime = new DateTimeOffset(2010, 3, 28, 2, 15, 0, TimeSpan.FromHours(4));
            var londonTime = new DateTimeOffset(2010, 3, 28, 2, 15, 0, TimeSpan.FromHours(1));
            return (int)(londonTime - moscowTime).TotalMinutes;
        }

        // GetGenderSwappedAdventureTimeDurationInMinutes_ver1_FeelsSmarter опустим, там то же самое

        /// <summary>
        /// Возвращает количество минут, проведенных в пути из Москвы в Лондон.
        /// </summary>
        public static int GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience()
        {
            /*
                Глава третья и последняя, в которой внезапно оказывается, что Финн и Фионна находятся в суперпозиции и существуют в виде гендерно нейтрального сверхчеловека, который и путешествовал из Москвы в Лондон.

                Дело в том, что перевод на летнее время в 2010м году в Москве произошел в 02:00 (стрелки часов перевели на час вперед), а в Лондоне - в 01:00.
                Таким образом в Москве не было 02:15 - однако можно, например, считать, что этому времени соответствует 03:15. Ну а в Лондоне 01:15 это на самом деле 02:15.
                Только как это обработать в рамках класса DateTimeOffset? Да, для конкретного примера мы могли бы сами ручками "перевести стрелки" и поставить правильное время, но что делать в общем случае?
                Тут придется воспользоваться знанием о часовых поясах. Их есть у .Net.

                Дабы ты не мучился[-ась], роя в недрах msdn и stackoverflow в поисках ответа (в конце концов, когда тебе это в жизни действительно понадобится),
                ниже ты найдешь готовый метод GetZonedTime. Просто посмотри на него (можешь даже посмотреть методы и свойства типа TimeZoneInfo, если интересно) и воспользуйся им для вычисления правильного времени
                "отбытия" и "прибытия" наших героев. Затем посчитай длительность путешествия. Также даны правильные идентификаторы зон.
            */
            const string moscowZoneId = "Russian Standard Time";
            const string londonZoneId = "GMT Standard Time";

            var moscowTime = GetZonedTime(new DateTime(2010, 3, 28, 3, 15, 0), moscowZoneId);
            var londonTime = GetZonedTime(new DateTime(2010, 3, 28, 1, 15, 0), londonZoneId);

            return (int)(londonTime - moscowTime).TotalMinutes;
        }

        /// <summary>
        /// Возвращает количество минут, проведенных в пути из Москвы в Лондон.
        /// </summary>
        public static int GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience()
        {
            const string moscowZoneId = "Russian Standard Time";
            const string londonZoneId = "GMT Standard Time";

            var moscowTime = GetZonedTime(new DateTime(2010, 3, 28, 2, 15, 0), moscowZoneId);
            var londonTime = GetZonedTime(new DateTime(2010, 3, 28, 2, 15, 0), londonZoneId);

            return (int)(londonTime - moscowTime).TotalMinutes;
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
        /// Проверка формата даты. Необходимы Unspecified kind, и 0:00:00 время
        /// </summary>
        /// <param name="date">Дата для проверки</param>
        /// <returns>True или False</returns>
        private static bool AreDateTime(DateTime date)
        {
            return date.Kind == DateTimeKind.Unspecified &&
                   date.Hour == 0 &&
                   date.Minute == 0 &&
                   date.Second == 0 &&
                   date.Millisecond == 0;
        }
        /// <summary>
        /// Указывает, родились ли два человека в один день.
        /// </summary>
        /// <param name="person1Birthday">День рождения первого человека. Должен удовлетворять формату <see cref="AreDateTime"/></param>
        /// <param name="person2Birthday">День рождения второго человека. Должен удовлетворять формату <see cref="AreDateTime"/></param>
        /// <returns>True - если родились в один день, иначе - false.</returns>
        internal static bool AreEqualBirthdays(DateTime person1Birthday, DateTime person2Birthday)
        {
            if (!AreDateTime(person1Birthday) || !AreDateTime(person2Birthday))
            {
                throw new ArgumentException("Wrong date format");
            }
            return (person1Birthday.Day == person2Birthday.Day 
                && person1Birthday.Month == person2Birthday.Month);
        }
    }
}
