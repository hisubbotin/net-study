using System;

namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            // Можно попробовать что-нибудь потестировать...

            // Узнаем, сколько сейчас времени
            Console.WriteLine(Time.WhatTimeIsIt().ToString());
            // Теперь в UTC
            Console.WriteLine(Time.WhatTimeIsItInUtc().ToString());

            // А сколько будет времени спустя 10 секунд?
            Console.WriteLine(Time.AddTenSeconds(Time.WhatTimeIsIt()).ToString());

            // Ну и посмотрим, сколько минут в 3х месяцах
            //Console.WriteLine(Time.GetTotalMinutesInThreeMonths().ToString());

            // Остальное - лень :(
        }
    }
}
