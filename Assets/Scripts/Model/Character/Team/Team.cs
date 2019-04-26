using Tools;

namespace SimpleCardGames.Battle
{
    /// <summary>
    ///     A concrete group of characters.
    /// </summary>
    public class Team : ITeam
    {
        public Collection<ICharacter> Members { get; private set; }

        public void AddMember(ICharacter character)
        {
            Members.Add(character);
        }

        public void RemoveMember(ICharacter character)
        {
            Members.Remove(character);
        }
    }
}