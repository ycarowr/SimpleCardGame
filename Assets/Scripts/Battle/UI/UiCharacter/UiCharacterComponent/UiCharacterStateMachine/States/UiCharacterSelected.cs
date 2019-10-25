using Patterns.StateMachine;
using UnityEngine;

namespace SimpleCardGames.Battle.UI.Character
{
    public class UiCharacterSelected : UiBaseCharacterState
    {
        //--------------------------------------------------------------------------------------------------------------


        public UiCharacterSelected(IUiCharacter handler, BaseStateMachine fsm, UiCharacterParameters parameters) : base(
            handler, fsm, parameters) =>
            DefaultSize = handler.transform.localScale;

        //--------------------------------------------------------------------------------------------------------------

        Camera MyCamera { get; }
        Vector3 DefaultSize { get; }
        public Collider UnselectZone { get; }

        //--------------------------------------------------------------------------------------------------------------

        public override void OnEnterState()
        {
            Handler.Motion.Scale.StopMotion();
            MakeRenderFirst();
            RemoveAllTransparency();
            SetScale();
        }

        void SetScale()
        {
            var finalScale = Parameters.ScaleSelect * Parameters.ScaleIdle * DefaultSize;
            finalScale.z = 1;
            Handler.Motion.ScaleTo(finalScale, 5);
        }

        public override void OnExitState()
        {
            Handler.Motion.Scale.StopMotion();
            Handler.Team.UnselectZone.Disable();
            Handler.Motion.ScaleTo(DefaultSize * Parameters.ScaleIdle, 5);
            if (Handler.transform)
                MakeRenderNormal();
        }

        //--------------------------------------------------------------------------------------------------------------
    }
}