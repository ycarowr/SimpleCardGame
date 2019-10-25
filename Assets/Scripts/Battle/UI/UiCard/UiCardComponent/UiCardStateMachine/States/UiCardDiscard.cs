using Patterns.StateMachine;
using UnityEngine;

namespace SimpleCardGames.Battle.UI.Card
{
    /// <summary>
    ///     State when a cards has been discarded.
    /// </summary>
    public class UiCardDiscard : UiBaseCardState
    {
        public UiCardDiscard(IUiCard handler, BaseStateMachine fsm, UiCardParameters parameters) : base(handler, fsm,
            parameters)
        {
        }

        Vector3 StartScale { get; set; }

        //--------------------------------------------------------------------------------------------------------------

        #region Operations

        public override void OnEnterState()
        {
            Disable();
            SetScale();
            SetRotation();
        }

        void SetScale()
        {
            var finalScale = Handler.transform.localScale * Parameters.DiscardedSize;
            Handler.Motion.ScaleTo(finalScale, Parameters.ScaleSpeed);
        }

        void SetRotation() => Handler.Motion.RotateTo(Vector3.zero, Parameters.RotationSpeed);

        #endregion
    }
}