using System;
using System.Collections.Generic;
using CallMeMaybe.BaseModel;

namespace CallMeMaybe.V1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Maybe<List<int>> x = null;
            Console.WriteLine(x);

            TestDateTimeMaybe(((DateTime?) null).ToMaybe());
            TestDateTimeMaybe(DateTime.Now);


            var maybeDt2 = from t in ((DateTime?) null).ToMaybe() select t;
            Console.WriteLine(maybeDt2.GetType());

            var maybeDt3 = from t in DateTime.Now.ToMaybe() select t;
            Console.WriteLine(maybeDt3);

            Console.WriteLine(Maybe<int>.Nothing);

            var selectManyUnderTheHood =
                from dt1 in ((DateTime?) null).ToMaybe()
                from dt2 in maybeDt2
                select dt1.Date + dt2.TimeOfDay;

            var selectChain = ((DateTime?) null).ToMaybe().Select(dt1 => maybeDt2.Select(dt2 => dt1.Date + dt2.TimeOfDay));

            var cookingTable = new CookingTable();
            var naiveChef = new NaiveChef(cookingTable);
            var muffins = naiveChef.CookPumpkinMuffins();
            Console.WriteLine(muffins.Count);

            var maybeChef = new MaybeChef(cookingTable);
            muffins = maybeChef.CookPumpkinMuffins();
            Console.WriteLine(muffins.Count);
        }

        private static void TestDateTimeMaybe(Maybe<DateTime> maybeDt)
        {
            Console.WriteLine(maybeDt.HasValue);
            Console.WriteLine(maybeDt.ToString());
            Console.WriteLine(
                maybeDt.SelectOrElse(dt => dt.Date == DateTime.Today ? "Today" : "Not today", () => "Don't know, man"));
            maybeDt.Do(dt => Console.WriteLine("I have a value"));
            maybeDt.OrElseDo(() => Console.WriteLine("I have no value"));
        }
    }
}
