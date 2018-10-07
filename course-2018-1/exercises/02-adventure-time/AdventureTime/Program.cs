using System;

namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            var dtLocal = new DateTime(2010, 3, 28, 1, 15, 1, DateTimeKind.Local);
            var dtUtc = new DateTime(2010, 3, 27, 22, 15, 1, DateTimeKind.Utc);
            
            Console.WriteLine(dtUtc - dtLocal);
            Console.WriteLine(dtUtc - dtLocal.ToUniversalTime());
        }
    }
}
