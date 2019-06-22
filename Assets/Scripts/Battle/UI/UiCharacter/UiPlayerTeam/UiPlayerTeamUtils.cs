using System.Collections;
using System.Collections.Generic;
using SimpleCardGames.Data.Character;
using UnityEngine;

namespace SimpleCardGames.Battle.UI.Character
{
    public class UiPlayerTeamUtils : UiListener, IPreGameStart, IDoDamage, IDoAttack, IDoKill, IPlayerSpawnCharacter
    {
        //--------------------------------------------------------------------------------------------------------------
        private const float TimeUntilRemoveUnit = 1;

        [SerializeField] [Tooltip("World point where the character is positioned")]
        private Transform characterPosition;

        private int Count { get; set; }

        private IUiPlayerTeam UiPlayerTeam { get; set; }
        private IUiPlayer Controller { get; set; }

        void IDoAttack.OnDamage(IDamager source, IDamageable target, int amount)
        {
            UiPlayerTeam.Unselect();
        }

        void IDoAttack.OnCantAttack(IDamager source, IDamageable target, int amount)
        {
            UiPlayerTeam.Unselect();
        }

        void IDoDamage.OnDamage(IDamager source, IDamageable target, int amount)
        {
            UiPlayerTeam.Unselect();
        }

        public void OnKill(IRuntimeCharacter target)
        {
            StartCoroutine(RemoveEffectively(target));
        }

        void IPlayerSpawnCharacter.OnSpawnCharacter(IPlayer player, IRuntimeCharacter character)
        {
            if (Controller.Seat == player.Seat)
                DeployCharacter(character);
        }

        //--------------------------------------------------------------------------------------------------------------

        void IPreGameStart.OnPreGameStart(List<IPlayer> players)
        {
            var members = Controller.PlayerController.Player.Team.Members;

            foreach (var member in members)
                DeployCharacter(member);
        }

        //--------------------------------------------------------------------------------------------------------------

        private void Awake()
        {
            Controller = GetComponent<IUiPlayer>();
            UiPlayerTeam = GetComponentInChildren<IUiPlayerTeam>();
        }

        //--------------------------------------------------------------------------------------------------------------

        public void DeployCharacter(IRuntimeCharacter character)
        {
            var uiCharacter = CharacterFactory.Instance.Get(character);

            if (character.Attributes.IsCaptain)
                UiPlayerTeam.AddCapitain(uiCharacter);
            else
                UiPlayerTeam.AddCharacter(uiCharacter);
        }

        public void RemoveCharacter(IRuntimeCharacter character)
        {
            var uiCharacter = CharacterFactory.Instance.Get(character);
            UiPlayerTeam.RemoveCharacter(uiCharacter);
        }

        private IEnumerator RemoveEffectively(IRuntimeCharacter target)
        {
            yield return new WaitForSeconds(TimeUntilRemoveUnit);
            UiPlayerTeam.RemoveCharacter(target);
        }
    }
}