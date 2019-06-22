using System.Collections.Generic;
using SimpleCardGames.Data.Character;
using SimpleCardGames.Data.Team;
using Tools;

namespace SimpleCardGames.Battle
{
    /// <summary>
    ///     A concrete group of characters.
    /// </summary>
    public class Team : Collection<IRuntimeCharacter>, ITeam
    {
        private readonly ICharacterData capitainDataRegister;
        private readonly IReadOnlyList<ICharacterData> memberDataRegister;

        public Team(IPlayer player, TeamData teamData)
        {
            Owner = player;
            capitainDataRegister = teamData.GetCapitain();
            memberDataRegister = teamData.GetMembers();
            CreateTeam();
        }

        public List<IRuntimeCharacter> Members => Units;
        public IRuntimeCharacter Captain { get; private set; }
        public bool IsEmpty => Size == 0;
        public IPlayer Owner { get; }
        public bool HasTaunt => EvaluateTaunt();

        /// <summary>
        ///     Gets the member of the team by a specific index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public IRuntimeCharacter GetMember(int index)
        {
            var unit = Get(index);
            return unit;
        }

        /// <summary>
        ///     Adds a new team member.
        /// </summary>
        /// <param name="member"></param>
        public void AddMember(IRuntimeCharacter member)
        {
            Add(member);
        }


        /// <summary>
        ///     Removes a team member.
        /// </summary>
        /// <param name="member"></param>
        public void RemoveMember(IRuntimeCharacter member)
        {
            Remove(member);
        }

        /// <summary>
        ///     Creates the team based on the characters in the register.
        /// </summary>
        private void CreateTeam()
        {
            if (capitainDataRegister != null)
            {
                Captain = new RuntimeCharacter(capitainDataRegister, Owner);
                AddMember(Captain);
            }

            foreach (var memberData in memberDataRegister)
                AddMember(new RuntimeCharacter(memberData, Owner));
        }

        /// <summary>
        ///     Gets the index of an specific memeber of the team.
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public int GetIndex(IRuntimeCharacter member)
        {
            return Units.IndexOf(member);
        }

        private bool EvaluateTaunt()
        {
            foreach (var u in Units)
                if (u.Attributes.HasTaunt && !u.Attributes.IsDead)
                    return true;

            return false;
        }
    }
}