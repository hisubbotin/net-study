using System;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;

namespace CallMeMaybe
{
    #region Ingredients

    internal struct WholeWheatFlour { }
    internal struct AllPurposeFlour { }
    internal struct Water { }
    internal struct VegetableOil { }
    internal struct PumpkinPieSpice { }
    internal struct BakingSoda { }
    internal struct Salt { }
    internal struct PumpkingPieFilling { }
    internal struct WhiteSugar { }
    internal struct Egg { }

    #endregion

    #region Reservoirs

    public struct CansOf<T>
    {
        public decimal Count { get; }
        public CansOf(decimal count)
        {
            Count = count;
        }
    }

    public struct CupsOf<T>
    {
        public decimal Count { get; }
        public CupsOf(decimal count)
        {
            Count = count;
        }
    }

    public struct TeaspoonsOf<T>
    {
        public decimal Count { get; }
        public TeaspoonsOf(decimal count)
        {
            Count = count;
        }
    }

    public struct Some<T>
    {
        public decimal Count { get; }
        public Some(decimal count)
        {
            Count = count;
        }
    }

    public struct BowlOf<T>
    {
        public T Content { get; }

        public BowlOf(T content)
        {
            Content = content;
        }
    }

    #endregion

    #region Cooking stuff repository

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

    #region Intermediate cooking stuff

    internal struct FlourMixture { }
    internal struct EggsMixture { }

    #endregion

    #region Baking stuff

    internal interface IBakeableTo<out TBaked>
        where TBaked: IBaked
    {
        TBaked Bake(TimeSpan duration, decimal degreesCelsius);
    }
    internal interface IBaked
    {
        void SmellMe();
        void BiteMe();
        void TasteMe();
        void Enjoy();
    }

    internal class PumpkinBatterCup : IBakeableTo<PumpkinMuffin>
    {
        public PumpkinMuffin Bake(TimeSpan duration, decimal degreesCelsius)
        {
            Debug.Assert(duration > TimeSpan.FromMinutes(27) && duration < TimeSpan.FromMinutes(33));
            Debug.Assert(degreesCelsius > 155 && degreesCelsius < 180);
            return new PumpkinMuffin();
        }
    }
    public class PumpkinMuffin: IBaked
    {
        public void SmellMe() { }
        public void BiteMe() { }
        public void TasteMe() { }
        public void Enjoy() { }
    }

    public struct BakingDish<T>
    {
        public IImmutableList<T> Cups { get; }

        public BakingDish(IImmutableList<T> cups)
        {
            Cups = cups;
        }
    }

    internal class Oven
    {
        public decimal DegreesCelsius { get; protected set; }

        public void Heat(decimal degreesCelsius)
        {
            DegreesCelsius = degreesCelsius;
        }

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
