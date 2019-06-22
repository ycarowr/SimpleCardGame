using UnityEngine;

namespace SimpleCardGames.Data.Team
{
    [CreateAssetMenu(menuName = "Data/Teams")]
    public class TeamsCurrentData : ScriptableObject
    {
        public TeamData EnemyTeam;
        public TeamData PlayerTeam;
    }
}