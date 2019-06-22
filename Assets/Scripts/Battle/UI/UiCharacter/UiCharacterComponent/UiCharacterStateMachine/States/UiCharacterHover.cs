using Patterns.StateMachine;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SimpleCardGames.Battle.UI.Character
{
    public class UiCharacterHover : UiBaseCharacterState
    {
        //--------------------------------------------------------------------------------------------------------------

        public UiCharacterHover(IUiCharacter handler, BaseStateMachine fsm, UiCharacterParameters parameters) : base(
            handler, fsm, parameters)
        {
        }

        //--------------------------------------------------------------------------------------------------------------

        private Vector3 DefaultSize { get; set; }


        //--------------------------------------------------------------------------------------------------------------

        private void OnPointerExit(PointerEventData obj)
        {
            if (Fsm.IsCurrent(this))
                Handler.Enable();
        }

        private void OnPointerDown(PointerEventData eventData)
        {
            if (Fsm.IsCurrent(this))
                Handler.Select();
        }

        //--------------------------------------------------------------------------------------------------------------

        private void ResetValues()
        {
            Handler.Motion.ScaleTo(DefaultSize, 5);
        }

        private void SetScale()
        {
            var finalScale = DefaultSize * Parameters.ScaleHover;
            Handler.Motion.ScaleTo(finalScale, 5);
        }

        private void CachePreviousValues()
        {
            DefaultSize = Handler.transform.localScale;
        }

        private void SubscribeInput()
        {
            Handler.Input.OnPointerExit += OnPointerExit;
            Handler.Input.OnPointerDown += OnPointerDown;
        }

        private void UnsubscribeInput()
        {
            Handler.Input.OnPointerExit -= OnPointerExit;
            Handler.Input.OnPointerDown -= OnPointerDown;
        }

        //--------------------------------------------------------------------------------------------------------------

        public override void OnEnterState()
        {
            MakeRenderFirst();
            SubscribeInput();
            CachePreviousValues();
            SetScale();
        }

        public override void OnExitState()
        {
            ResetValues();
            UnsubscribeInput();
        }

        //--------------------------------------------------------------------------------------------------------------
    }
}