using System;
using System.Collections.Generic;
using System.Linq;
using CallMeMaybe.Maybe;

namespace CallMeMaybe
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Hello World!");

            MaybeV1<List<int>> x = null;
            Console.WriteLine(x);

            var maybeDt = ((DateTime?) null).ToMaybe();
            Console.WriteLine(maybeDt.HasValue);

            var maybeDt2 = from t in maybeDt select t;
            Console.WriteLine(maybeDt2.GetType());

            var maybeDt3 = from t in DateTime.Now.ToMaybe() select t;
            Console.WriteLine(maybeDt3);

            Console.WriteLine(MaybeV1<int>.Nothing);

            var selectManyUnderTheHood =
                from dt1 in maybeDt
                from dt2 in maybeDt2
                select dt1.Date + dt2.TimeOfDay;

            var selectChain = maybeDt.Select(dt1 => maybeDt2.Select(dt2 => dt1.Date + dt2.TimeOfDay));

            var cookingTable = new CookingTable();
            var naiveChef = new NaiveChef(cookingTable);
            var muffins = naiveChef.CookPumpkinMuffins();
            Console.WriteLine(muffins.Count);

            var maybeChef = new MaybeChef(cookingTable);
            muffins = maybeChef.CookPumpkinMuffins();
            Console.WriteLine(muffins.Count);
        }
    }
}
