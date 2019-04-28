using SimpleCardGames.Data.Effects;

namespace SimpleCardGames
{
    /// <summary>
    ///     All units that are able to draw cards thought effects.
    /// </summary>
    public interface IDiscardable
    {
        /// <summary>
        ///     Discard an amount of cards. Send the source of the effect.
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        void DoDiscard(int amount, IEffector source);
    }
}