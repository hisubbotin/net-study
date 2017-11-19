using System;
using System.Collections.Generic;
using System.Linq;
using CallMeMaybe.BaseModel;

namespace CallMeMaybe.V2
{
    class Program
    {
        static void Main(string[] args)
        {
            var nullDtMaybe = ((DateTime?)null).ToMaybe();
            var nowDtMaybe = DateTime.Now.ToMaybe();

            TestSingleFrom(nullDtMaybe);
            TestSingleFrom(nowDtMaybe);

            TestMultipleFrom(nullDtMaybe, nowDtMaybe);
            TestMultipleFrom(nowDtMaybe, nowDtMaybe);
            TestMultipleFrom<int>(10, 20);

            var maybeDt2 = from t in nullDtMaybe select t;
            Console.WriteLine(maybeDt2.GetType());

            var maybeDt3 = from t in DateTime.Now.ToMaybe() select t;
            Console.WriteLine(string.Join(", ", maybeDt3));

            var multipleFromRes =
                from dt1 in nullDtMaybe
                from dt2 in maybeDt2
                select dt1.Date + dt2.TimeOfDay;
            Console.WriteLine(string.Join(", ", multipleFromRes));


            var selectChain = nullDtMaybe
                .Select(dt1 => maybeDt2.Select(dt2 => dt1.Date + dt2.TimeOfDay));

            var cookingTable = new CookingTable();
            var naiveChef = new NaiveChef(cookingTable);
            var muffins = naiveChef.CookPumpkinMuffins();
            Console.WriteLine(muffins.Count);

            var maybeChef = new MaybeChef(cookingTable);
            muffins = maybeChef.CookPumpkinMuffins();
            Console.WriteLine(muffins.Count);
        }

        private static void TestSingleFrom<T>(Maybe<T> m)
        {
            Console.WriteLine($"Test from clause for: {m}");
            var res = from x in m select x;

            // ===> res = m.Select(x => x);

            Console.WriteLine($"type: {res.GetType()}; values: [{string.Join(", ", res)}]");
            Console.WriteLine("==========================");
        }


        private static void TestMultipleFrom<T>(Maybe<T> m1, Maybe<T> m2)
        {
            Console.WriteLine($"Test multiple from clause for: {m1}; {m2}");
            var res =
                from x in m1
                from y in m2
                select new {x, y};

            // ===> res = m1.SelectMany(x => m2, (x, y) => new {x, y});

            Console.WriteLine($"type: {res.GetType()}; values: [{string.Join(", ", res)}]");
            Console.WriteLine("==========================");
        }
    }
}
