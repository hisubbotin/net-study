using System;

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
        internal static DateTime WhatTimeIsIt()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Возвращает текущее время в UTC.
        /// </summary>
        internal static DateTime WhatTimeIsItInUtc()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Возвращает объект <see cref="DateTime"/> с заданными временем и значением <see cref="DateTime.Kind"/>.
        /// </summary>
        /// <param name="dt">Объект <see cref="DateTime"/>, задающий время.</param>
        /// <param name="kind">Значение <see cref="DateTime.Kind"/>, задающий соответствующее свойство возвращаемого объекта.</param>
        /// <returns>Объект <see cref="DateTime"/> с заданными временем и значением <see cref="DateTime.Kind"/>.</returns>
        internal static DateTime SpecifyKind(DateTime dt, DateTimeKind kind)
        {
            /*
                Подсказка: поищи в статических методах DateTime.
            */
            throw new NotImplementedException();
        }

        /// <summary>
        /// Конвертирует объект <see cref="DateTime"/> в эквивалентное ему строковое представление времени в формате ISO 8601 (aka round-trip format).
        /// </summary>
        /// <param name="dt">Объект <see cref="DateTime"/> для конвертации в строку.</param>
        /// <returns>Строковое представление времени в формате ISO 8601.</returns>
        internal static string ToRoundTripFormatString(DateTime dt)
        {
            /*
                Обязательно поиграйся и посмотри на изменение результата в зависимости от dt.Kind (для этого тебе поможет метод выше).
            */
            throw new NotImplementedException();
        }

        /// <summary>
        /// Конвертирует строковое представление времени в формате ISO 8601 в объект <see cref="DateTime"/>.
        /// </summary>
        /// <param name="dtStr">Строковое представление времени в формате ISO 8601.</param>
        /// <returns>Объект <see cref="DateTime"/>.</returns>
        internal static DateTime ParseFromRoundTripFormat(string dtStr)
        {
            /*
                Поиграйся и проверь, что round-trip действительно round-trip, т.е. туда-обратно равно оригиналу (для туда воспользуйся предыдущим методом).
                Проверь для всех значений DateTime.Kind.
            */
            throw new NotImplementedException();
        }

        /// <summary>
        /// Преобразует значение текущего объекта <see cref="DateTime"/> во время UTC.
        /// </summary>
        internal static DateTime ToUtc(DateTime dt)
        {
            /*
                Eсли воспользуешься нужным методом, то знай, что результат его работы зависит от dt.Kind. В случае dt.Kind == Unspecified предполагается, что время локальное,
                т.е. результат работы в случае Local и Unspecified совпадают. Такие дела
            */
            throw new NotImplementedException();
        }

        /// <summary>
        /// Возвращает время, передвинутое вперед на 10 секунд от заданного.
        /// </summary>
        /// <param name="dt">Заданное время.</param>
        /// <returns>Время, передвинутое вперед на 10 секунд от заданного</returns>
        internal static DateTime AddTenSeconds(DateTime dt)
        {
            // здесь воспользуйся методами самого объекта и заодно посмотри какие еще похожие есть
            throw new NotImplementedException();
        }

        /// <summary>
        /// Возвращает время, передвинутое вперед на 10 секунд от заданного.
        /// </summary>
        /// <param name="dt">Заданное время.</param>
        /// <returns>Время, передвинутое вперед на 10 секунд от заданного</returns>
        internal static DateTime AddTenSecondsV2(DateTime dt)
        {
            /*
                Ну а здесь воспользуйся сложением с TimeSpan. Обрати внимание, что помимо конструктора, у класса есть набор полезных статических методов-фабрик.
                Обрати внимание, что у TimeSpan нет статических методов FromMonth, FromYear. Как думаешь, почему?
            */
            throw new NotImplementedException();
        }

        /// <summary>
        /// Возвращает полное количество часов заданного временного отрезка.
        /// </summary>
        /// <param name="dt1">Начало временного отрезка.</param>
        /// <param name="dt2">Конец временного отрезка.</param>
        /// <returns>Полное количество часов заданного временного отрезка.</returns>
        internal static int GetHoursBetween(DateTime dt1, DateTime dt2)
        {
            /*
                1) Подумай, в чем разница между Hours и TotalHours
                2) Проверь, учитывается ли Kind объектов при арифметических операциях.
                3) Подумай, почему возвращаемое значение может отличаться от действительности.
            */
            throw new NotImplementedException();
        }

        /// <summary>
        /// Возвращает количество минут во временном промежутке, равном трем месяцам.
        /// </summary>
        internal static int GetTotalMinutesInThreeMonths()
        {
            // ну тут все просто и очевидно, если сделал остальные и подумал над вопросами в комментах.
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal static int GetAdventureTimeDuration()
        {
            /*
                
                var fromLondon = new DateTimeOffset(2010, 3, 28, 1, 15, 0, TimeSpan.FromHours(1));
                var toMoscow = new DateTimeOffset(2010, 3, 28, 5, 0, 0, TimeSpan.FromHours(4));

            */
            throw new NotImplementedException();
        }

        internal static void GetBirthdate()
        {
            throw new NotImplementedException();
        }
    }
}
