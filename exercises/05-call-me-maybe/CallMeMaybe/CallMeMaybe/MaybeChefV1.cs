using System;
using System.Collections.Immutable;
using System.Linq;
using CallMeMaybe.Maybe;

namespace CallMeMaybe
{
    public class MaybeChefV1: IOneRecipeChef
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
            var result =
                from flourMixture in MakeFlourMixture()
                from eggsMixture in MakeEggsMixture()
                from backingDish in PrepareBackingDish(flourMixture, eggsMixture)
                from pumpkinMuffins in oven.Bake<PumpkinBatterCup, PumpkinMuffin>(backingDish, TimeSpan.FromMinutes(30)).ToMaybe()
                select pumpkinMuffins.Cups;

            return result.GetValueOrDefault();
        }

        private MaybeV1<BakingDish<PumpkinBatterCup>> PrepareBackingDish(BowlOf<FlourMixture> flourMixture, BowlOf<EggsMixture> eggsMixture)
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

        private MaybeV1<BowlOf<EggsMixture>> MakeEggsMixture()
        {
            throw new NotImplementedException();
        }

        private MaybeV1<BowlOf<FlourMixture>> MakeFlourMixture()
        {
            throw new NotImplementedException();
        }
    }
}
