using System;


namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            DateTime dt = DateTime.Now;
            //dt = Time.SpecifyKind(dt, DateTimeKind.Utc);
            DateTime dt1 = Time.ToUtc(dt);
            DateTime r = new DateTime(2018, 10, 7, 15, 0, 0);
            DateTime l = new DateTime(2018, 10, 7, 16, 12, 0);
            Console.WriteLine("   {0}    Kind: {1}", dt, dt.Kind);
            Console.WriteLine("   {0}    Kind: {1}", dt1, dt1.Kind);
            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());
            Console.WriteLine(Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());
        }
    }
}
