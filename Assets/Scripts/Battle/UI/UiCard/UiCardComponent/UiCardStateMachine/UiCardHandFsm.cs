using Patterns.StateMachine;
using UnityEngine;

namespace SimpleCardGames.Battle.UI.Card
{
    /// <summary>
    ///     State Machine that holds all states of a UI Card.
    /// </summary>
    public class UiCardHandFsm : BaseStateMachine
    {
        //--------------------------------------------------------------------------------------------------------------

        #region Constructor

        public UiCardHandFsm(Camera camera, UiCardParameters cardConfigsParameters, IUiCard handler = null) :
            base(handler)
        {
            CardConfigsParameters = cardConfigsParameters;

            IdleState = new UiCardIdle(handler, this, CardConfigsParameters);
            DisableState = new UiCardDisable(handler, this, CardConfigsParameters);
            DragState = new UiCardDrag(handler, camera, this, CardConfigsParameters);
            HoverState = new UiCardHover(handler, this, CardConfigsParameters);
            DrawState = new UiCardDraw(handler, this, CardConfigsParameters);
            DiscardState = new UiCardDiscard(handler, this, CardConfigsParameters);
            TargetState = new UiCardTarget(handler, camera, this, cardConfigsParameters);

            RegisterState(IdleState);
            RegisterState(DisableState);
            RegisterState(DragState);
            RegisterState(HoverState);
            RegisterState(DrawState);
            RegisterState(DiscardState);
            RegisterState(TargetState);

            Initialize();
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------------

        #region Properties

        UiCardIdle IdleState { get; }
        UiCardDisable DisableState { get; }
        UiCardDrag DragState { get; }
        UiCardHover HoverState { get; }
        UiCardDraw DrawState { get; }
        UiCardDiscard DiscardState { get; }
        UiCardTarget TargetState { get; }
        UiCardParameters CardConfigsParameters { get; }

        #endregion

        //--------------------------------------------------------------------------------------------------------------

        #region Operations

        public void Hover() => PushState<UiCardHover>();

        public void Disable() => PushState<UiCardDisable>();

        public void Enable() => PushState<UiCardIdle>();

        public void Select() => PushState<UiCardDrag>();

        public void Unselect() => Enable();

        public void Draw() => PushState<UiCardDraw>();

        public void Discard() => PushState<UiCardDiscard>();

        public void Play()
        {
        }

        public void Target() => PushState<UiCardTarget>();

        #endregion

        //--------------------------------------------------------------------------------------------------------------
    }
}