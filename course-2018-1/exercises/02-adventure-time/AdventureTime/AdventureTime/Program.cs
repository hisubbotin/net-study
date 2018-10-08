using System;
using System.Globalization;

namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine(DateTime.Now.ToString("O"));
//            Console.WriteLine(DateTime.UtcNow.ToString("O"));
            

//            Console.WriteLine((int)4.999999);
//            Console.WriteLine(DateTime.Now.AddHours(25));
//            Console.WriteLine((DateTime.Now.AddHours(26) - DateTime.Now).Hours);
//            Console.WriteLine(DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified).ToString("O"));
//            Console.WriteLine(DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Local).ToString("O"));
//            Console.WriteLine(DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc).ToString("O"));
//            
//            
//            Console.WriteLine(DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Unspecified).ToString("O"));
//            Console.WriteLine(DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Local).ToString("O"));
//            Console.WriteLine(DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc).ToString("O"));
//
            var d = DateTime.Now;
//            bool eq = d == DateTime.Parse(d.ToString("O"), null, DateTimeStyles.RoundtripKind);
//            Console.WriteLine(eq);
            
            
//            Console.WriteLine(DateTime.SpecifyKind(d, DateTimeKind.Local).ToUniversalTime());
//            Console.WriteLine(DateTime.SpecifyKind(d, DateTimeKind.Unspecified).ToUniversalTime());
//            Console.WriteLine(DateTime.SpecifyKind(d, DateTimeKind.Utc).ToUniversalTime());

//            Console.WriteLine((d.AddSeconds(1200) - d).TotalHours);
//            
//            var d1 = new DateTime(2010, 10, 8, 13, 01, 10, DateTimeKind.Local);
//            var d2 = new DateTime(2010, 10, 8, 8, 01, 10, DateTimeKind.Utc);
//            
//            Console.WriteLine((d1 - d2).TotalHours);
            
            
//            Console.WriteLine(dtUtc - dtLocal.ToUniversalTime());
            
            
            var start = new DateTime();
            Console.WriteLine(start);

        }
    }
}
