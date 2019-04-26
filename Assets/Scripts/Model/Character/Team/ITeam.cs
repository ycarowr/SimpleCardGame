using Tools;

namespace SimpleCardGames.Battle
{
    /// <summary>
    ///     Interface for a group of characters.
    /// </summary>
    public interface ITeam
    {
        Collection<ICharacter> Members { get; }
        void AddMember(ICharacter character);
        void RemoveMember(ICharacter character);
    }
}