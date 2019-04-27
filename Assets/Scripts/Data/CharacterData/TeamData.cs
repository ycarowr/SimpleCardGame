using SimpleCardGames.Battle;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleCardGames.Data.Character
{
    [CreateAssetMenu(menuName ="Data/Team")]
    public class TeamData : ScriptableObject
    {
        [Tooltip("All the crew.")][SerializeField] private List<ICharacterData> teamMembers = new List<ICharacterData>();
        public List<ICharacterData> TeamMembers => teamMembers;
        [SerializeField] [Multiline]
        [Tooltip("Brief description of the team. The text won't be visible to the user.")]private string description;

        public Team GetMembers(IPlayer player)
        {
            var team = new Team();
            
            foreach(var memberData in teamMembers)
            {
                var character = new RuntimeCharacter(memberData, player);
                team.AddMember(character);
            }

            return team;
        }
    }
}