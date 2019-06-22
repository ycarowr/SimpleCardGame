//using Patterns.StateMachine;
//using UnityEngine;
//using UnityEngine.EventSystems;

//namespace SimpleCardGames.Battle.UI.Character
//{
//    public class UiCharacterUnselected : UiBaseCharacterState
//    {
//        //--------------------------------------------------------------------------------------------------------------


//        public UiCharacterUnselected(IUiCharacter handler, BaseStateMachine fsm, UiCharacterParameters parameters) : base(handler, fsm, parameters)
//        {
//            DefaultSize = handler.transform.localScale;
//        }

//        //--------------------------------------------------------------------------------------------------------------

//        private Camera MyCamera { get; }
//        private Vector3 DefaultSize { get; }
//        public Collider UnselectZone { get; }

//        //--------------------------------------------------------------------------------------------------------------

//        public override void OnEnterState()
//        {
//            Handler.Scale.StopMotion();
//            MakeRenderFirst();
//            RemoveAllTransparency();
//            SetScale();
//        }

//        private void SetScale()
//        {
//            var finalScale = Parameters.ScaleSelect * Parameters.ScaleIdle * DefaultSize;
//            finalScale.z = 1;
//            Handler.ScaleTo(finalScale, 5);
//        }

//        public override void OnExitState()
//        {
//            Handler.Scale.StopMotion();
//            Handler.Team.UnselectZone.Disable();
//            Handler.ScaleTo(DefaultSize * Parameters.ScaleIdle, 5);
//            if (Handler.transform)
//                MakeRenderNormal();
//        }

//        //--------------------------------------------------------------------------------------------------------------
//    }
//}

