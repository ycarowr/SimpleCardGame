using Patterns.StateMachine;
using UnityEngine;

namespace SimpleCardGames.Battle.UI.Card
{
    /// <summary>
    ///     This state draw the collider of the card.
    /// </summary>
    public class UiCardDraw : UiBaseCardState
    {
        public UiCardDraw(IUiCard handler, BaseStateMachine fsm, UiCardParameters parameters) : base(handler, fsm,
            parameters)
        {
        }

        Vector3 StartScale { get; set; }

        //--------------------------------------------------------------------------------------------------------------

        #region Operations

        public override void OnEnterState()
        {
            CachePreviousValue();
            DisableCollision();
            SetScale();
            Handler.Motion.Movement.OnFinishMotion += GoToIdle;
        }

        public override void OnExitState() => Handler.Motion.Movement.OnFinishMotion -= GoToIdle;

        void GoToIdle() => Handler.Enable();

        void CachePreviousValue()
        {
            StartScale = Handler.transform.localScale;
            Handler.transform.localScale *= Parameters.StartSizeWhenDraw;
        }

        void SetScale() => Handler.Motion.ScaleTo(StartScale, Parameters.ScaleSpeed);

        #endregion
    }
}