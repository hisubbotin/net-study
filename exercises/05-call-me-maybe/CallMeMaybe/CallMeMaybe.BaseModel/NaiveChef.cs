using System;
using System.Collections.Immutable;

namespace CallMeMaybe.BaseModel
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
            var oven = new Oven();
            oven.Heat(166);

            var flourMixture = MakeFlourMixture();
            if (flourMixture == null)
            {
                return null;
            }

            var eggsMixture = MakeEggsMixture();
            if (eggsMixture == null)
            {
                return null;
            }

            var backingDish = PrepareBackingDish(flourMixture.Value, eggsMixture.Value);
            if (backingDish == null)
            {
                return null;
            }

            var pumpkinMuffins = oven.Bake<PumpkinBatterCup, PumpkinMuffin>(backingDish.Value, TimeSpan.FromMinutes(30));
            return pumpkinMuffins?.Cups;
        }

        private BakingDish<PumpkinBatterCup>? PrepareBackingDish(BowlOf<FlourMixture> flourMixture, BowlOf<EggsMixture> eggsMixture)
        {
            var pumpkinBatterCups = ImmutableList.CreateBuilder<PumpkinBatterCup>();
            for (var i = 0; i < 24; i++)
            {
                var fillPumpkinBatterCup = FillPumpkinBatterCup(flourMixture, eggsMixture);
                pumpkinBatterCups.Add(fillPumpkinBatterCup);
            }
            return _cookingTable.FindBakingDish(pumpkinBatterCups.ToImmutable());
        }

        private PumpkinBatterCup FillPumpkinBatterCup(BowlOf<FlourMixture> flourMixture, BowlOf<EggsMixture> eggsMixture)
        {
            return new PumpkinBatterCup();
        }

        private BowlOf<FlourMixture>? MakeFlourMixture()
        {
            /*
                здесь представим, что ничего плохого в том, что мы проверяем на null
                полученные значения только в конце, нет.
                Ты должен[-а] понимать, что в каких-то случаях такая стратегия может быть допустимой,
                а в каких-то - нет.
            */
            var wholeWheatFlour = _cookingTable.FindCupsOf<WholeWheatFlour>(3.5m);
            var allPurposeFlour = _cookingTable.FindCupsOf<AllPurposeFlour>(3.5m);
            var pumpkinPieSpice = _cookingTable.FindTeaspoonsOf<PumpkinPieSpice>(5m);
            var bakingSoda = _cookingTable.FindTeaspoonsOf<BakingSoda>(2m);
            var salt = _cookingTable.FindTeaspoonsOf<Salt>(1.5m);

            if (wholeWheatFlour == null || allPurposeFlour == null || pumpkinPieSpice == null || bakingSoda == null
                || salt == null)
            {
                return null;
            }
            return _cookingTable.FindBowlAndFillItWith(new FlourMixture());
        }

        private BowlOf<EggsMixture>? MakeEggsMixture()
        {
            /*
                здесь наоборот посмотрим, как сильно распухает метод, если проверять
                на null каждое полученное значение сразу.
            */
            var pumpkinPieFilling = _cookingTable.FindCansOf<PumpkingPieFilling>(1m);
            if (pumpkinPieFilling == null)
            {
                return null;
            }

            var sugar = _cookingTable.FindCupsOf<WhiteSugar>(3m);
            if (sugar == null)
            {
                return null;
            }

            var oil = _cookingTable.FindCupsOf<VegetableOil>(0.5m);
            if (oil == null)
            {
                return null;
            }

            var water = _cookingTable.FindCupsOf<Water>(0.5m);
            if (water == null)
            {
                return null;
            }

            var eggs = _cookingTable.FindSome<Egg>(4m);
            if (eggs == null)
            {
                return null;
            }

            return _cookingTable.FindBowlAndFillItWith(new EggsMixture());
        }

    }
}
