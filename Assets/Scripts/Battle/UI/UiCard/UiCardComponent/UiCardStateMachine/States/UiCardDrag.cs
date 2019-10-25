using System;
using Extensions;
using Patterns.StateMachine;
using UnityEngine;

namespace SimpleCardGames.Battle.UI.Card
{
    public class UiCardDrag : UiBaseCardState
    {
        public UiCardDrag(IUiCard handler, Camera camera, BaseStateMachine fsm, UiCardParameters parameters) : base(
            handler, fsm, parameters) =>
            MyCamera = camera;
        //--------------------------------------------------------------------------------------------------------------

        Vector3 StartEuler { get; set; }
        Camera MyCamera { get; }

        //--------------------------------------------------------------------------------------------------------------


        Vector3 WorldPoint()
        {
            var mousePosition = Handler.Input.MousePosition;
            var worldPoint = MyCamera.ScreenToWorldPoint(mousePosition);
            return worldPoint;
        }

        void FollowCursor()
        {
            var myZ = Handler.transform.position.z;
            Handler.transform.position = WorldPoint().WithZ(myZ);
        }

        void AddTorque() => throw new NotImplementedException();

        //--------------------------------------------------------------------------------------------------------------

        #region Operations

        public override void OnUpdate() => FollowCursor();

        public override void OnEnterState()
        {
            //stop any movement
            Handler.Motion.Movement.StopMotion();

            //cache old values
            StartEuler = Handler.transform.eulerAngles;

            Handler.Motion.RotateTo(Vector3.zero, Parameters.RotationSpeed);
            MakeRenderFirst();
            RemoveAllTransparency();
        }

        public override void OnExitState()
        {
            //reset position and rotation
            if (Handler.transform)
            {
                Handler.Motion.RotateTo(StartEuler, Parameters.RotationSpeed);
                MakeRenderNormal();
            }

            DisableCollision();
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------------
    }
}