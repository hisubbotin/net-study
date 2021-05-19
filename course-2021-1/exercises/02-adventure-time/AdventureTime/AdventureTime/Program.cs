using System;

namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine(Time.WhatTimeIsIt());
            Console.WriteLine(Time.WhatTimeIsItInUtc());
            Console.WriteLine(Time.ToRoundTripFormatString(Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Utc)));
            Console.WriteLine(Time.ToRoundTripFormatString(Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Local)));
            Console.WriteLine(Time.ToRoundTripFormatString(Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Unspecified)));
            Console.WriteLine(Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Local));
            Console.WriteLine(Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Unspecified));
            Console.WriteLine(Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Utc));
        }
    }
}
