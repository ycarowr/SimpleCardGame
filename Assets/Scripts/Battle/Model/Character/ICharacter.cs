using SimpleCardGames.Data.Character;
using SimpleCardGames.Data.Effects;

namespace SimpleCardGames.Battle
{
    /// <summary>
    ///     A character in the game.
    /// </summary>
    public interface IRuntimeCharacter : ITargetable, IHealer, IHealable, IDamager, IDamageable, IKillable, IAttackable
    {
        ICharacterData Data { get; }
        CharAttributes Attributes { get; }
        void StartPlayerTurn();
    }
}