using System;
using System.Collections.Generic;
using CallMeMaybe.BaseModel;

namespace CallMeMaybe.V1
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Hello World!");

            Maybe<List<int>> listOfInt = null;
            Console.WriteLine(listOfInt);

            var nullDtMaybe = ((DateTime?) null).ToMaybe();
            var maybeDt = DateTime.Now.ToMaybe();

            TestDateTimeMaybe(nullDtMaybe);
            TestDateTimeMaybe(maybeDt);

            TestSelectChain(nullDtMaybe, maybeDt);
            TestSelectChain(DateTime.Today.AddDays(-1), DateTime.Now);

            var cookingTable = new CookingTable();
            var naiveChef = new NaiveChef(cookingTable);
            var muffins = naiveChef.CookPumpkinMuffins();
            Console.WriteLine(muffins.Count);

            var maybeChef = new MaybeChef(cookingTable);
            muffins = maybeChef.CookPumpkinMuffins();
            Console.WriteLine(muffins.Count);
        }

        private static void TestSelectChain(Maybe<DateTime> maybeDt1, Maybe<DateTime> maybeDt2)
        {
            Console.WriteLine($"Test select chain for: {maybeDt1}; {maybeDt2}");
            var res = maybeDt1.Select(dt1 => maybeDt2.Select(dt2 => dt1.Date + dt2.TimeOfDay));
            Console.WriteLine($"type: {res.GetType()}; value: {res}");
            Console.WriteLine("=======================================");
        }

        private static void TestDateTimeMaybe(Maybe<DateTime> maybeDt)
        {
            Console.WriteLine($"Test Maybe<DateTime> for: {maybeDt}");
            Console.WriteLine(maybeDt.HasValue);
            Console.WriteLine(maybeDt.ToString());
            Console.WriteLine(
                maybeDt.SelectOrElse(dt => dt.Date == DateTime.Today ? "Today" : "Not today", () => "Don't know, man"));
            maybeDt.Do(dt => Console.WriteLine("I have a value"));
            maybeDt.OrElseDo(() => Console.WriteLine("I have no value"));
            Console.WriteLine("=======================================");
        }
    }
}
