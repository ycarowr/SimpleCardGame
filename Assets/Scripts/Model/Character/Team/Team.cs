using Tools;
using UnityEngine;

namespace SimpleCardGames.Battle
{
    /// <summary>
    ///     A concrete group of characters.
    /// </summary>
    public class Team : ITeam
    {
        public Collection<ICharacter> Members { get; private set; }

        public Team(Collection<ICharacter> members = null)
        {
            if (members == null)
                Members = new Collection<ICharacter>();
        }

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