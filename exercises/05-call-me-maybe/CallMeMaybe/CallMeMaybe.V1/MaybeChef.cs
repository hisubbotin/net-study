using System;
using System.Collections.Immutable;
using CallMeMaybe.BaseModel;

namespace CallMeMaybe.V1
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

            return MakeFlourMixture()
                .Select(flourMixture => MakeEggsMixture().Select(eggsMixture => PrepareBackingDish(flourMixture, eggsMixture)))
                .Select(backingDish => oven.Bake<PumpkinBatterCup, PumpkinMuffin>(backingDish, TimeSpan.FromMinutes(30)).ToMaybe())
                .SelectOrElse(pumpkinMuffin => pumpkinMuffin.Cups, () => null);
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

        private Maybe<BowlOf<FlourMixture>> MakeFlourMixture()
        {
            // здесь сделай сам, пожалуйста
            throw new NotImplementedException();
        }
        private Maybe<BowlOf<EggsMixture>> MakeEggsMixture()
        {
            // как видишь, так можно, но чет не очень удобно - получается огромная вложенная блямба селектов
            // и это у нас еще логика не ветвистая!
            return _cookingTable.FindCansOf<PumpkingPieFilling>(1m).ToMaybe()
                .Select(pumpkinPieFilling => _cookingTable.FindCupsOf<WhiteSugar>(3m).ToMaybe()
                .Select(sugar => _cookingTable.FindCupsOf<VegetableOil>(0.5m).ToMaybe()
                .Select(oil => _cookingTable.FindCupsOf<Water>(0.5m).ToMaybe()
                .Select(water => _cookingTable.FindSome<Egg>(4m).ToMaybe()
                .Select(eggs => _cookingTable.FindBowlAndFillItWith(new EggsMixture()).ToMaybe()
                )))));
        }
    }
}
