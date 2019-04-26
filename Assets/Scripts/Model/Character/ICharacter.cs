using SimpleCardGames.Data.Effects;

namespace SimpleCardGames.Battle
{
    /// <summary>
    ///     A character in the game.
    /// </summary>
    public interface ICharacter : IEffectable, IHealer, IHealable, IAttackable, IDamageable
    {
        CharAttributes Attributes { get; }
    }
}