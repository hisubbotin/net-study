using System;
namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            DateTime d = DateTime.Now;
            DateTime s = d.AddMonths(1);
            System.Console.WriteLine(Time.AreEqualBirthdays(d, d));
            System.Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());
            System.Console.WriteLine(Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());
            System.Console.ReadLine();
        }
    }
}
