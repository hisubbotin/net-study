using System;
using System.Linq;

namespace CallMeMaybe
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Hello World!");

            Maybe<object> x = null;
            Console.WriteLine(x.HasValue);

            var dt = ((DateTime?) null).ToMaybe();
            Console.WriteLine(dt.HasValue);

            Console.WriteLine(Maybe<int>.Nothing);

            //var cookingTable = new CookingTable();
            //var naiveChef = new NaiveChef(cookingTable);
            //var muffins = naiveChef.CookPumpkinMuffins();
            //Console.WriteLine(muffins.Count);

            //var maybeChef = new MaybeChef(cookingTable);
            //muffins = maybeChef.CookPumpkinMuffins();
            //Console.WriteLine(muffins.Count);
        }
    }
}
