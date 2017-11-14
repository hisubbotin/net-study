using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace CallMeMaybe
{
    public class NaiveChef : IOneRecipeChef
    {
        private readonly CookingTable _cookingTable;
        public NaiveChef(CookingTable cookingTable)
        {
            _cookingTable = cookingTable;
        }

        /// <inheritdoc />
        public IImmutableList<PumpkinMuffin> CookPumpkinMuffins()
        {
            var wholeWheatFlour = _cookingTable.FindCupsOf<WholeWheatFlour>(3.5m);
            var allPurposeFlour = _cookingTable.FindCupsOf<AllPurposeFlour>(3.5m);
            var pumpkinPieSpice = _cookingTable.FindTeaspoonsOf<PumpkinPieSpice>(5m);
            var bakingSoda = _cookingTable.FindTeaspoonsOf<BakingSoda>(2m);
            var salt = _cookingTable.FindTeaspoonsOf<Salt>(1.5m);

            if (wholeWheatFlour != null && allPurposeFlour != null && pumpkinPieSpice != null && bakingSoda != null && salt != null)
            {
                var flourMixture = MakeFlourMixture(
                    wholeWheatFlour.Value,
                    allPurposeFlour.Value,
                    pumpkinPieSpice.Value,
                    bakingSoda.Value,
                    salt.Value
                );

                var pumpkinPieFilling = _cookingTable.FindCansOf<PumpkingPieFilling>(1m);
                var sugar = _cookingTable.FindCupsOf<WhiteSugar>(3m);
                var oil = _cookingTable.FindCupsOf<VegetableOil>(0.5m);
                var water = _cookingTable.FindCupsOf<Water>(0.5m);
                var eggs = _cookingTable.FindSome<Egg>(4m);

                if (pumpkinPieFilling != null && sugar != null && oil != null && water != null && eggs != null)
                {
                    var eggMixture = MakeEggsMixture(
                        pumpkinPieFilling.Value,
                        sugar.Value,
                        oil.Value,
                        water.Value,
                        eggs.Value
                    );

                    if (flourMixture != null && eggMixture != null)
                    {
                        var pumpkinBatterCups = ImmutableList.CreateBuilder<PumpkinBatterCup>();
                        for (var i = 0; i < 24; i++)
                        {
                            pumpkinBatterCups.Add(new PumpkinBatterCup());
                        }

                        var backingDish = _cookingTable.FindBakingDish(pumpkinBatterCups.ToImmutable());
                        if (backingDish != null)
                        {
                            var oven = new Oven();
                            oven.Heat(166);

                            var pumpkinMuffins = oven.Bake<PumpkinBatterCup, PumpkinMuffin>(backingDish.Value, TimeSpan.FromMinutes(30));
                            if (pumpkinMuffins != null)
                            {
                                return pumpkinMuffins.Value.Cups;
                            }
                        }
                    }
                }
            }

            return null;
        }

        private BowlOf<EggsMixture>? MakeEggsMixture(CansOf<PumpkingPieFilling> pumpkinPieFilling, CupsOf<WhiteSugar> sugar, CupsOf<VegetableOil> oil, CupsOf<Water> water, Some<Egg> eggs)
        {
            return _cookingTable.FindBowlAndFillItWith(new EggsMixture());
        }

        private BowlOf<FlourMixture>? MakeFlourMixture(CupsOf<WholeWheatFlour> wholeWheatFlour, CupsOf<AllPurposeFlour> allPurposeFlour, TeaspoonsOf<PumpkinPieSpice> pumpkinPieSpice, TeaspoonsOf<BakingSoda> bakingSoda, TeaspoonsOf<Salt> salt)
        {
            return _cookingTable.FindBowlAndFillItWith(new FlourMixture());
        }
    }
}
