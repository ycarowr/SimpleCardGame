using System.Collections.Generic;
using SimpleCardGames.Data.Character;
using UnityEngine;

namespace SimpleCardGames.Data.Team
{
    public enum TeamId
    {
        TeamRocket,
        TeamRocketElite
    }

    [CreateAssetMenu(menuName = "Data/Team")]
    public class TeamData : ScriptableObject
    {
        [SerializeField] [Tooltip("The capitan of the crew.")]
        CharacterData capitain;

        [SerializeField] [Multiline] [Tooltip("Brief description of the team. The text won't be visible to the user.")]
        string description;

        [SerializeField] TeamId id;

        [SerializeField] [Tooltip("All data of the members")]
        List<CharacterData> members = new List<CharacterData>();

        public TeamId Id => id;

        /// <summary>
        ///     It returns a list with all data members of the team.
        /// </summary>
        /// <returns></returns>
        public List<ICharacterData> GetMembers()
        {
            var allData = new List<ICharacterData>();
            members.ForEach(member => allData.Add(member));
            return allData;
        }

        public ICharacterData GetCapitain() => capitain;
    }
}