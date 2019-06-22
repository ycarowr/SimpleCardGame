using Extensions;
using Patterns.StateMachine;
using UnityEngine;

namespace SimpleCardGames.Battle.UI.Card
{
    /// <summary>
    ///     This state tells what happen with a card when searching for a target.
    /// </summary>
    public class UiCardTarget : UiBaseCardState
    {
        public UiCardTarget(IUiCard handler, Camera camera, BaseStateMachine fsm, UiCardParameters parameters)
            : base(handler, fsm, parameters)
        {
            var screenCenter = new Vector2(Screen.width, Screen.height) / 2;
            WorldCenter = camera.ScreenToWorldPoint(screenCenter).WithZ(0);
            Speed = 8;
        }

        private Vector3 WorldCenter { get; }
        private float Speed { get; }

        public override void OnEnterState()
        {
            Handler.Motion.MoveTo(WorldCenter, Speed);
        }
    }
}