using System;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;

namespace CallMeMaybe.BaseModel
{
    #region Ingredients

    public struct WholeWheatFlour { }
    public struct AllPurposeFlour { }
    public struct Water { }
    public struct VegetableOil { }
    public struct PumpkinPieSpice { }
    public struct BakingSoda { }
    public struct Salt { }
    public struct PumpkingPieFilling { }
    public struct WhiteSugar { }
    public struct Egg { }

    #endregion

    #region Containers

    /// <summary>
    /// Связка жестяных банок с содержимым <see cref="T"/>.
    /// </summary>
    public struct CansOf<T>
    {
        public decimal Count { get; }
        public CansOf(decimal count)
        {
            Count = count;
        }
    }

    /// <summary>
    /// Несколько чашек с содержимым <see cref="T"/>.
    /// </summary>
    public struct CupsOf<T>
    {
        public decimal Count { get; }
        public CupsOf(decimal count)
        {
            Count = count;
        }
    }

    /// <summary>
    /// Несколько чайных ложек с содержимым <see cref="T"/>.
    /// </summary>
    public struct TeaspoonsOf<T>
    {
        public decimal Count { get; }
        public TeaspoonsOf(decimal count)
        {
            Count = count;
        }
    }

    /// <summary>
    /// Немножко <see cref="T"/>.
    /// </summary>
    public struct Some<T>
    {
        public decimal Count { get; }
        public Some(decimal count)
        {
            Count = count;
        }
    }

    /// <summary>
    /// Миска с <see cref="T"/>.
    /// </summary>
    public struct BowlOf<T>
    {
        public T Content { get; }

        public BowlOf(T content)
        {
            Content = content;
        }
    }

    #endregion

    #region Cooking table is like repository of the cooking stuff

    /// <summary>
    /// Кухонный стол aka репозиторий всей кухонной утвари и ингредиентов. Осторожно, очень нестабилен!
    /// </summary>
    public class CookingTable
    {
        public CansOf<T>? FindCansOf<T>(decimal cansCount)
        {
            return new CansOf<T>(cansCount);
        }

        public BowlOf<T>? FindBowlAndFillItWith<T>(T content)
        {
            return new BowlOf<T>(content);
        }

        public CupsOf<T>? FindCupsOf<T>(decimal cupsCount)
        {
            return new CupsOf<T>(cupsCount);
        }

        public TeaspoonsOf<T>? FindTeaspoonsOf<T>(decimal spoonsCount)
        {
            return new TeaspoonsOf<T>(spoonsCount);
        }

        public Some<T>? FindSome<T>(decimal count)
        {
            return new Some<T>(count);
        }

        public BakingDish<T>? FindBakingDish<T>(IImmutableList<T> cups)
        {
            return new BakingDish<T>(cups);
        }
    }

    #endregion

    #region Intermediate cooking ingredients

    public struct FlourMixture { }
    public struct EggsMixture { }

    #endregion

    #region Baking stuff

    /// <summary>
    /// Я запекаемый в.
    /// </summary>
    /// <typeparam name="TBaked">А это, во что оно превращается при запекании.</typeparam>
    public interface IBakeableTo<out TBaked>
        where TBaked: IBaked
    {
        TBaked Bake(TimeSpan duration, decimal degreesCelsius);
    }

    /// <summary>
    /// Я запекшийся.
    /// </summary>
    public interface IBaked
    {
        void SmellMe();
        void BiteMe();
        void TasteMe();
        void Enjoy();
    }

    /// <summary>
    /// Формочка для выпечки маффинов, наполненная тыквенно-масляной жижей.
    /// </summary>
    public class PumpkinBatterCup : IBakeableTo<PumpkinMuffin>
    {
        public PumpkinMuffin Bake(TimeSpan duration, decimal degreesCelsius)
        {
            Debug.Assert(duration > TimeSpan.FromMinutes(27) && duration < TimeSpan.FromMinutes(33));
            Debug.Assert(degreesCelsius > 155 && degreesCelsius < 180);
            return new PumpkinMuffin();
        }
    }
    /// <summary>
    /// Бабушкина радость тыквенный маффин.
    /// </summary>
    public class PumpkinMuffin: IBaked
    {
        public void SmellMe() { }
        public void BiteMe() { }
        public void TasteMe() { }
        public void Enjoy() { }
    }

    /// <summary>
    /// Форма для выпечки.
    /// </summary>
    public struct BakingDish<T>
    {
        public IImmutableList<T> Cups { get; }

        public BakingDish(IImmutableList<T> cups)
        {
            Cups = cups;
        }
    }

    /// <summary>
    /// Духовка.
    /// </summary>
    public class Oven
    {
        public decimal DegreesCelsius { get; protected set; }

        /// <summary>
        /// Подогревает (или охлаждает) духовку до заданной температуры.
        /// </summary>
        /// <param name="degreesCelsius"></param>
        public void Heat(decimal degreesCelsius)
        {
            DegreesCelsius = degreesCelsius;
        }

        /// <summary>
        /// Запекает все, что есть в форме для выпечки, в течение указанного времени.
        /// </summary>
        public BakingDish<TBaked>? Bake<TRaw, TBaked>(BakingDish<TRaw> dish, TimeSpan duration)
            where TBaked: IBaked
            where TRaw: IBakeableTo<TBaked>
        {
            // or null
            return new BakingDish<TBaked>(
                dish
                    .Cups
                    .Select(cup => cup.Bake(duration, DegreesCelsius))
                    .ToImmutableList()
            );
        }
    }

    #endregion


}
