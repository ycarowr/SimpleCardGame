﻿using Patterns.StateMachine;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SimpleCardGames.Battle.UI.Card
{
    public class UiCardHover : UiBaseCardState
    {
        //--------------------------------------------------------------------------------------------------------------

        public UiCardHover(IUiCard handler, BaseStateMachine fsm, UiCardParameters parameters) : base(handler, fsm,
            parameters)
        {
        }

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
            Handler.Motion.RotateTo(StartEuler, Parameters.RotationSpeed);
            Handler.Motion.MoveTo(StartPosition, Parameters.HoverSpeed);
            Handler.Motion.ScaleTo(StartScale, Parameters.ScaleSpeed);
        }

        private void SetRotation()
        {
            if (!Parameters.HoverRotation)
                Handler.Motion.RotateTo(Vector3.zero, Parameters.RotationSpeed);
        }

        private void SetPosition()
        {
            var halfCardHeight = new Vector3(0, Handler.Renderer.bounds.size.y / 2);
            var pointZeroScreen = Handler.MainCamera.ScreenToWorldPoint(Vector3.zero);
            var bottomScreenY = new Vector3(0, pointZeroScreen.y);
            var currentPosWithoutY = new Vector3(Handler.transform.position.x, 0, Handler.transform.position.z);
            var hoverHeightParameter = new Vector3(0, Parameters.HoverHeight);
            var final = currentPosWithoutY + bottomScreenY + halfCardHeight + hoverHeightParameter;
            Handler.Motion.MoveTo(final, Parameters.HoverSpeed);
        }

        private void SetScale()
        {
            var currentScale = Handler.transform.localScale;
            var finalScale = currentScale * Parameters.HoverScale;
            Handler.Motion.ScaleTo(finalScale, Parameters.ScaleSpeed);
        }

        private void CachePreviousValues()
        {
            StartPosition = Handler.transform.position;
            StartEuler = Handler.transform.eulerAngles;
            StartScale = Handler.transform.localScale;
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

        #region Operations

        public override void OnEnterState()
        {
            MakeRenderFirst();
            SubscribeInput();
            CachePreviousValues();
            SetScale();
            SetPosition();
            SetRotation();
        }

        public override void OnExitState()
        {
            ResetValues();
            UnsubscribeInput();
            DisableCollision();
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------------

        #region Properties

        private Vector3 StartPosition { get; set; }
        private Vector3 StartEuler { get; set; }
        private Vector3 StartScale { get; set; }

        #endregion

        //--------------------------------------------------------------------------------------------------------------
    }
}