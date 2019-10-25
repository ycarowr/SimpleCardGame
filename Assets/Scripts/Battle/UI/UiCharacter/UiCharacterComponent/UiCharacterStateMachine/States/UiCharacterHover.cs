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

        Vector3 DefaultSize { get; set; }


        //--------------------------------------------------------------------------------------------------------------

        void OnPointerExit(PointerEventData obj)
        {
            if (Fsm.IsCurrent(this))
                Handler.Enable();
        }

        void OnPointerDown(PointerEventData eventData)
        {
            if (Fsm.IsCurrent(this))
                Handler.Select();
        }

        //--------------------------------------------------------------------------------------------------------------

        void ResetValues() => Handler.Motion.ScaleTo(DefaultSize, 5);

        void SetScale()
        {
            var finalScale = DefaultSize * Parameters.ScaleHover;
            Handler.Motion.ScaleTo(finalScale, 5);
        }

        void CachePreviousValues() => DefaultSize = Handler.transform.localScale;

        void SubscribeInput()
        {
            Handler.Input.OnPointerExit += OnPointerExit;
            Handler.Input.OnPointerDown += OnPointerDown;
        }

        void UnsubscribeInput()
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