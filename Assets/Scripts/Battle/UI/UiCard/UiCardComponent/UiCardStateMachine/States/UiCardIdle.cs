using Patterns.StateMachine;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SimpleCardGames.Battle.UI.Card
{
    /// <summary>
    ///     UI Card Idle behavior.
    /// </summary>
    public class UiCardIdle : UiBaseCardState
    {
        //--------------------------------------------------------------------------------------------------------------

        public UiCardIdle(IUiCard handler, BaseStateMachine fsm, UiCardParameters parameters) : base(handler, fsm,
            parameters)
        {
            DefaultSize = Handler.transform.localScale;
        }

        private Vector3 DefaultSize { get; }

        //--------------------------------------------------------------------------------------------------------------

        public override void OnEnterState()
        {
            Handler.Input.OnPointerDown += OnPointerDown;
            Handler.Input.OnPointerEnter += OnPointerEnter;

            if (Handler.Motion.Movement.IsOperating)
            {
                DisableCollision();
                Handler.Motion.Movement.OnFinishMotion += Enable;
            }
            else
            {
                Enable();
            }

            MakeRenderNormal();
            Handler.Motion.ScaleTo(DefaultSize, Parameters.ScaleSpeed);
        }

        public override void OnExitState()
        {
            Handler.Input.OnPointerDown -= OnPointerDown;
            Handler.Input.OnPointerEnter -= OnPointerEnter;
            Handler.Motion.Movement.OnFinishMotion -= Enable;
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