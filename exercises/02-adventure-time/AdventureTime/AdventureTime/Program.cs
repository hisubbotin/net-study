using System;

namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine(DateTime.Now);
            Console.WriteLine(DateTime.Now.ToString("dd.MM"));

            string a = "aaaa";
            string b = "aaaa";

            Console.WriteLine(a == b);
            Console.WriteLine(a.Equals(b));
            Console.WriteLine(a.CompareTo(b));

            Console.WriteLine(Time.GetTotalMinutesInThreeMonths());

            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience() == 
                Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());
        }
    }
}
