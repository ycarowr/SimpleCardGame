using Patterns.StateMachine;
using UnityEngine;

namespace SimpleCardGames.Battle.UI.Character
{
    /// <summary>
    ///     State Machine that holds all states of a UI character.
    /// </summary>
    public class UiCharacterFsm : BaseStateMachine
    {
        //--------------------------------------------------------------------------------------------------------------

        #region Constructor

        public UiCharacterFsm(Camera camera, UiCharacterParameters parameters, IUiCharacter handler) :
            base(handler)
        {
            IdleState = new UiCharacterIdle(handler, this, parameters);
            DisableState = new UiCharacterDisable(handler, this, parameters);
            HoverState = new UiCharacterHover(handler, this, parameters);
            SelectedState = new UiCharacterSelected(handler, this, parameters);
            //UnselectedState = new UiCharacterUnselected(handler, this, parameters);
            AttackState = new UiCharacterAttack(handler, this, parameters);

            RegisterState(IdleState);
            RegisterState(DisableState);
            RegisterState(HoverState);
            //RegisterState(UnselectedState);
            RegisterState(SelectedState);
            RegisterState(AttackState);

            Initialize();
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------------

        #region Properties

        UiCharacterIdle IdleState { get; }
        UiCharacterDisable DisableState { get; }
        UiCharacterHover HoverState { get; }

        UiCharacterSelected SelectedState { get; }

        //private UiCharacterUnselected UnselectedState { get; }
        UiCharacterAttack AttackState { get; }

        #endregion

        //--------------------------------------------------------------------------------------------------------------

        #region Operations

        public void Hover() => PushState<UiCharacterHover>();

        public void Disable() => PushState<UiCharacterDisable>();

        public void Enable() => PushState<UiCharacterIdle>();

        public void Unselect() => Enable();

        public void Select() => PushState<UiCharacterSelected>();

        public void Attack(Vector3 targetPosition)
        {
            PushState<UiCharacterAttack>();
            AttackState.ExecuteAttack(targetPosition);
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------------
    }
}