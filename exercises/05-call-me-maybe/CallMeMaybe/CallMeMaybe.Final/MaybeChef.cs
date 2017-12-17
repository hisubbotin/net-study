using System;
using System.Collections.Immutable;
using CallMeMaybe.BaseModel;

namespace CallMeMaybe.Final
{
    public class MaybeChef: IOneRecipeChef
    {
        private readonly CookingTable _cookingTable;

        /// <inheritdoc />
        public MaybeChef(CookingTable cookingTable)
        {
            _cookingTable = cookingTable;
        }

        /// <inheritdoc />
        public IImmutableList<PumpkinMuffin> CookPumpkinMuffins()
        {
            var oven = new Oven();
            oven.Heat(166);

            var result =
                from flourMixture in MakeFlourMixture()
                from eggsMixture in MakeEggsMixture()
                from backingDish in PrepareBackingDish(flourMixture, eggsMixture)
                from pumpkinMuffins in oven.Bake<PumpkinBatterCup, PumpkinMuffin>(backingDish, TimeSpan.FromMinutes(30)).ToMaybe()
                select pumpkinMuffins.Cups;

            return result.GetValueOrDefault();
        }

        private Maybe<BakingDish<PumpkinBatterCup>> PrepareBackingDish(BowlOf<FlourMixture> flourMixture, BowlOf<EggsMixture> eggsMixture)
        {
            var pumpkinBatterCups = ImmutableList.CreateBuilder<PumpkinBatterCup>();
            for (var i = 0; i < 24; i++)
            {
                pumpkinBatterCups.Add(FillPumpkinBatterCup(flourMixture, eggsMixture));
            }
            return _cookingTable.FindBakingDish(pumpkinBatterCups.ToImmutable()).ToMaybe();
        }

        private PumpkinBatterCup FillPumpkinBatterCup(BowlOf<FlourMixture> flourMixture, BowlOf<EggsMixture> eggsMixture)
        {
            return new PumpkinBatterCup();
        }

        private Maybe<BowlOf<EggsMixture>> MakeEggsMixture()
        {
            /*
                Теперь мы оперируем только объектами типа Maybe<T> - 
                больше никаких непонятных преобразований в IEnumerable и обратно :)
            */
            return 
                from pumpkinPieFilling in _cookingTable.FindCansOf<PumpkingPieFilling>(1m).ToMaybe()
                from sugar in _cookingTable.FindCupsOf<WhiteSugar>(3m).ToMaybe()
                from oil in _cookingTable.FindCupsOf<VegetableOil>(0.5m).ToMaybe()
                from water in _cookingTable.FindCupsOf<Water>(0.5m).ToMaybe()
                from eggs in _cookingTable.FindSome<Egg>(4m).ToMaybe()
                from eggsMixture in _cookingTable.FindBowlAndFillItWith(new EggsMixture()).ToMaybe()
                select eggsMixture;
        }

        private Maybe<BowlOf<FlourMixture>> MakeFlourMixture()
        {
            // здесь сделай сам, пожалуйста
            return _cookingTable.FindBowlAndFillItWith(new FlourMixture()).ToMaybe();
        }
    }
}
