using System;
using System.Collections.Immutable;
using System.Linq;
using CallMeMaybe.BaseModel;

namespace CallMeMaybe.V2
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

            // !!!: result имеет тип IEnumerable<IImmutableList<PumpkinMuffin>>

            // нужно явно вернуться из IEnumerable в Maybe - для этого и нужен соответствующий экстеншн.
            return result.ToMaybe().GetValueOrDefault();
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
            return _cookingTable.FindBowlAndFillItWith(new FlourMixture()).ToMaybe();
        }

        private Maybe<BowlOf<EggsMixture>> MakeEggsMixture()
        {
            /*
                Выглядит чуть лучше и писать несколько удобнее.
                Если бы было ветвление логики, то пришлось бы разбивать на куски и миксовать с вызовом методов-аналогов
                Select/SelectOrElse/Do/DoOrElse из первой части задания.

                Основной же минус - мы работаем с IEnumerable и на выходе тоже IEnumerable, что как бы не очень:
                    - нарушается семантика кода. Мы должны работать в терминах монады Maybe, а не последовательностей
                    - кое-что еще. Что? Подсказка: проблема в работе с объектами как объектами некоторого интерфейса
            */
            var result =
                from pumpkinPieFilling in _cookingTable.FindCansOf<PumpkingPieFilling>(1m).ToMaybe()
                from sugar in _cookingTable.FindCupsOf<WhiteSugar>(3m).ToMaybe()
                from oil in _cookingTable.FindCupsOf<VegetableOil>(0.5m).ToMaybe()
                from water in _cookingTable.FindCupsOf<Water>(0.5m).ToMaybe()
                from eggs in _cookingTable.FindSome<Egg>(4m).ToMaybe()
                from eggsMixture in _cookingTable.FindBowlAndFillItWith(new EggsMixture()).ToMaybe()
                select eggsMixture;

            // !!!: result имеет тип IEnumerable<BowlOf<EggsMixture>>

            // нужно явно вернуться из IEnumerable в Maybe - для этого и нужен соответствующий экстеншн.
            return result.ToMaybe();
        }
    }
}
