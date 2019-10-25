using System;
using SimpleCardGames.Battle.UI.Card;
using UnityEngine;

namespace SimpleCardGames.Battle.UI.Character
{
    //------------------------------------------------------------------------------------------------------------------

    /// <summary>
    ///     Character Hand holds a register of characters.
    /// </summary>
    public class UiPlayerTeam : UiCharacterPile, IUiPlayerTeam
    {
        //--------------------------------------------------------------------------------------------------------------

        protected override void Awake()
        {
            base.Awake();
            Controller = GetComponent<IUiPlayer>();
            UnselectZone = GetComponentInChildren<IClickZone>();

            PlayerHand = transform.parent.parent.GetComponentInChildren<IUiPlayerHand>();
            PlayerHand.OnCardSelected += card => DisableCharacters();
            PlayerHand.OnPileChanged += card => EnableCharacters();
        }

        //--------------------------------------------------------------------------------------------------------------

        #region Properties

        [SerializeField] UiPlayerTeam uiEnemyTeam;
        public IClickZone UnselectZone { get; private set; }
        IUiPlayerHand PlayerHand { get; set; }
        public IUiPlayer Controller { get; set; }

        public Action<IUiCharacter> OnCharacterSelected { get; set; } = character => { };

        public IUiCharacter SelectedCharacter { get; private set; }

        #endregion

        //--------------------------------------------------------------------------------------------------------------

        #region Operations

        /// <summary>
        ///     Select the character in the parameter.
        /// </summary>
        /// <param name="character"></param>
        public void SelectCharacter(IUiCharacter character)
        {
            if (character == null)
                return;

            uiEnemyTeam.OnCharacterSelected += TryAttack;
            UnselectZone.Enable();
            SelectedCharacter = character;

            if (character.IsUser)
                DisableCharacters();
            NotifyCharacterSelected();
        }

        /// <summary>
        ///     Unselect the character in the parameter.
        /// </summary>
        /// <param name="character"></param>
        public void UnselectCharacter(IUiCharacter character)
        {
            if (character == null)
                return;

            uiEnemyTeam.OnCharacterSelected -= TryAttack;
            UnselectZone.Disable();
            SelectedCharacter = null;
            character.Unselect();
            NotifyPileChange();
            EnableCharacters();
        }

        /// <summary>
        ///     Unselect the character which is currently selected. Nothing happens if current is null.
        /// </summary>
        public void Unselect() => UnselectCharacter(SelectedCharacter);

        /// <summary>
        ///     Disables input for all characters.
        /// </summary>
        public void DisableCharacters()
        {
            foreach (var otherCharacter in Characters)
                otherCharacter.Disable();
        }

        /// <summary>
        ///     Enables input for all characters.
        /// </summary>
        public void EnableCharacters()
        {
            foreach (var otherCharacter in Characters)
                otherCharacter.Enable();
        }

        [Button]
        void NotifyCharacterSelected() => OnCharacterSelected?.Invoke(SelectedCharacter);

        void TryAttack(IUiCharacter defender)
        {
            if (SelectedCharacter == null)
                return;

            Attack(SelectedCharacter, defender);
        }

        public void Attack(IUiCharacter agreessor, IUiCharacter blocker)
        {
            var attackData = new AttackMechanics.RuntimeAttackData
            {
                Agressor = agreessor.Data.RuntimeData,
                Blocker = blocker.Data.RuntimeData
            };

            Controller.PlayerController.Attack(attackData);
        }

        public IUiCharacter GetCharacter(IRuntimeCharacter character) =>
            Characters.Find(x => x.Data.RuntimeData == character);

        public override void Restart()
        {
            SelectedCharacter = null;
            base.Restart();
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------------
    }
}