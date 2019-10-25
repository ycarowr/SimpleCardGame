using System.Collections.Generic;
using System.Linq;
using Patterns;
using UnityEngine;

namespace SimpleCardGames.Data.Team
{
    public class TeamDatabase : Singleton<TeamDatabase>
    {
        const string PathDataBase = "Battle/TeamDatabase/Database";

        public TeamDatabase()
        {
            if (Teams == null)
                Teams = Resources.LoadAll<TeamData>(PathDataBase).ToList();
        }

        List<TeamData> Teams { get; }

        public TeamData Get(TeamId id) => Teams?.Find(team => team.Id == id);

        public List<TeamData> GetFullList() => Teams;
    }
}