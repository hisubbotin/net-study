using System;
namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            // эта вещь мне не понравилась, пришлось проверить
            Console.WriteLine("3 months: " + Time.GetTotalMinutesInThreeMonths());
            
            // а вот это, действительно, интересно
            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());
            Console.WriteLine(Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());
            
            var bd1 = new DateTime(1992, 10, 30, 11, 37, 0);
            var bd2 = new DateTime(1996, 7, 27, 16, 29, 0);
            Console.WriteLine(Time.AreEqualBirthdays(bd1, bd2));
            
            Console.ReadKey();
        }
    }
}
