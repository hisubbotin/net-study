using System;
using NodaTime;
using NodaTime.TimeZones;

namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {    
            var person1Birthday = new DateTime(2010, 10, 9);
            var person2Birthday = new DateTime(2000, 10, 9);
            Console.WriteLine(person1Birthday.Date.Equals(person2Birthday.Date));
        }
    }
}
