using System.Collections.Generic;
using System.Linq;
using Patterns;
using UnityEngine;

namespace SimpleCardGames.Data.Team
{
    public class TeamDatabase : Singleton<TeamDatabase>
    {
        private const string PathDataBase = "Battle/TeamDatabase/Database";

        public TeamDatabase()
        {
            if (Teams == null)
                Teams = Resources.LoadAll<TeamData>(PathDataBase).ToList();
        }

        private List<TeamData> Teams { get; }

        public TeamData Get(TeamId id)
        {
            return Teams?.Find(team => team.Id == id);
        }

        public List<TeamData> GetFullList()
        {
            return Teams;
        }
    }
}