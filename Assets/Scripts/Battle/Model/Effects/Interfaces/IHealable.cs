using SimpleCardGames.Data.Effects;

namespace SimpleCardGames
{
    /// <summary>
    ///     All units that are able to get healed.
    /// </summary>
    public interface IHealable : ITargetable
    {
        /// <summary>
        ///     Heals damage and return the real amount after reductions or bonus.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        int TakeHeal(IHealer source, int amount);
    }
}