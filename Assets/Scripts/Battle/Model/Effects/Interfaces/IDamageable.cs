using SimpleCardGames.Data.Effects;

namespace SimpleCardGames
{
    /// <summary>
    ///     All units that are able to take damage.
    /// </summary>
    public interface IDamageable : ITargetable
    {
        /// <summary>
        ///     Take some damage and return the real damage dealt after reductions or bonus.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        int TakeDamage(IDamager source, int amount);
    }
}