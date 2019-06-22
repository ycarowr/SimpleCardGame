using Patterns.StateMachine;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SimpleCardGames.Battle.UI.Character
{
    /// <summary>
    ///     UI Character Idle behavior.
    /// </summary>
    public class UiCharacterIdle : UiBaseCharacterState
    {
        //--------------------------------------------------------------------------------------------------------------

        public UiCharacterIdle(IUiCharacter handler, BaseStateMachine fsm, UiCharacterParameters parameters) : base(
            handler, fsm, parameters)
        {
            DefaultSize = Handler.transform.localScale;
        }

        private Vector3 DefaultSize { get; }

        //--------------------------------------------------------------------------------------------------------------

        public override void OnEnterState()
        {
            Handler.Input.OnPointerDown += OnPointerDown;
            Handler.Input.OnPointerEnter += OnPointerEnter;
            Enable();
            Handler.Motion.ScaleTo(DefaultSize, 5);
        }

        public override void OnExitState()
        {
            Handler.Input.OnPointerDown -= OnPointerDown;
            Handler.Input.OnPointerEnter -= OnPointerEnter;
        }

        //--------------------------------------------------------------------------------------------------------------

        private void OnPointerEnter(PointerEventData obj)
        {
            if (Fsm.IsCurrent(this))
                Handler.Hover();
        }

        private void OnPointerDown(PointerEventData eventData)
        {
            if (Fsm.IsCurrent(this))
                Handler.Select();
        }

        //--------------------------------------------------------------------------------------------------------------
    }
}