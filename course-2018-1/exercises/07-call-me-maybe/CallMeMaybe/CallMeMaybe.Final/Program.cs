using System;
using CallMeMaybe.BaseModel;

namespace CallMeMaybe.Final
{
    internal class Program
    {
        private static void Main()
        {
            var nullDtMaybe = ((DateTime?) null).ToMaybe();
            var nowDtMaybe = DateTime.Now.ToMaybe();

            TestSingleFrom(nullDtMaybe);
            TestSingleFrom(nowDtMaybe);

            TestMultipleFrom(nullDtMaybe, nowDtMaybe);
            TestMultipleFrom(nowDtMaybe, nowDtMaybe);
            TestMultipleFrom<int>(10, 20);

            TestMultipleFromWithFilter(3, 4, 5);
            TestMultipleFromWithFilter(2, 3, 5);

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

            // <===> res = m.Select(x => x);

            Console.WriteLine($"type: {res.GetType()}; values: [{string.Join(", ", res)}]");
            Console.WriteLine("==========================");
        }


        private static void TestMultipleFrom<T>(Maybe<T> m1, Maybe<T> m2)
        {
            Console.WriteLine($"Test multiple from clause for: {m1}; {m2}");
            var res =
                from x in m1
                from y in m2
                select new { x, y };

            // <===> res = m1.SelectMany(x => m2, (x, y) => new {x, y});

            Console.WriteLine($"type: {res.GetType()}; values: [{string.Join(", ", res)}]");
            Console.WriteLine("==========================");
        }


        private static void TestMultipleFromWithFilter(Maybe<int> m1, Maybe<int> m2, Maybe<int> m3)
        {
            Console.WriteLine($"Test multiple from clause with filter for: {m1}; {m2}; {m3}");
            var res =
                from x in m1
                from y in m2
                from z in m3
                where x + y > z
                select new { x, y, z };

            /*
            <===> res = m1
                    .SelectMany(x => m2, (x, y) => new { x, y })
                    .SelectMany(t => m3, (t, z) => new { t, z })
                    .Where(t => t.t.x + t.t.y > t.z)
                    .Select(t => new { t.t.x, t.t.y, t.z });
            */

            Console.WriteLine($"type: {res.GetType()}; values: [{string.Join(", ", res)}]");
            Console.WriteLine("==========================");
        }
    }
}
