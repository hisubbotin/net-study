using System;
using System.Linq;
using CallMeMaybe.BaseModel;

namespace CallMeMaybe.V2
{
    internal class Program
    {
        private static void Main()
        {
            var nullDtMaybe = ((DateTime?)null).ToMaybe();
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

			Console.ReadKey();
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
                select new {x, y};

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

/*
Test from clause for: null
type: System.Linq.Enumerable+SelectEnumerableIterator`2[System.DateTime,System.D
ateTime]; values: []
==========================
Test from clause for: 18.11.2018 12:56:45
type: System.Linq.Enumerable+SelectEnumerableIterator`2[System.DateTime,System.D
ateTime]; values: [18.11.2018 12:56:45]
==========================
Test multiple from clause for: null; 18.11.2018 12:56:45
type: System.Linq.Enumerable+<SelectManyIterator>d__167`3[System.DateTime,System
.DateTime,<>f__AnonymousType9`2[System.DateTime,System.DateTime]]; values: []
==========================
Test multiple from clause for: 18.11.2018 12:56:45; 18.11.2018 12:56:45
type: System.Linq.Enumerable+<SelectManyIterator>d__167`3[System.DateTime,System
.DateTime,<>f__AnonymousType9`2[System.DateTime,System.DateTime]]; values: [{ x
= 18.11.2018 12:56:45, y = 18.11.2018 12:56:45 }]
==========================
Test multiple from clause for: 10; 20
type: System.Linq.Enumerable+<SelectManyIterator>d__167`3[System.Int32,System.In
t32,<>f__AnonymousType9`2[System.Int32,System.Int32]]; values: [{ x = 10, y = 20
 }]
==========================
Test multiple from clause with filter for: 3; 4; 5
type: System.Linq.Enumerable+WhereSelectEnumerableIterator`2[<>f__AnonymousType1
0`2[<>f__AnonymousType9`2[System.Int32,System.Int32],System.Int32],<>f__Anonymou
sType11`3[System.Int32,System.Int32,System.Int32]]; values: [{ x = 3, y = 4, z =
 5 }]
==========================
Test multiple from clause with filter for: 2; 3; 5
type: System.Linq.Enumerable+WhereSelectEnumerableIterator`2[<>f__AnonymousType1
0`2[<>f__AnonymousType9`2[System.Int32,System.Int32],System.Int32],<>f__Anonymou
sType11`3[System.Int32,System.Int32,System.Int32]]; values: []
==========================
24
24
*/