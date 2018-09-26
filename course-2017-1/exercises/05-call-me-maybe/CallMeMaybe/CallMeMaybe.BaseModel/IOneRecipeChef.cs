using System.Collections.Immutable;

namespace CallMeMaybe.BaseModel
{
    public interface IOneRecipeChef
    {
        IImmutableList<PumpkinMuffin> CookPumpkinMuffins();
    }
}
