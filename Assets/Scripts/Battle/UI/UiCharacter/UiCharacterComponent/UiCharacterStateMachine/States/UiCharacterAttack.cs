using Patterns.StateMachine;
using UnityEngine;

namespace SimpleCardGames.Battle.UI.Character
{
    /// <summary>
    ///     This state executes and attack of a character.
    /// </summary>
    public class UiCharacterAttack : UiBaseCharacterState
    {
        readonly float moveSpeedAttack = 10;

        public UiCharacterAttack(IUiCharacter handler, BaseStateMachine fsm, UiCharacterParameters parameters) : base(
            handler, fsm, parameters)
        {
        }

        Vector3 TargetPosition { get; set; }
        Vector3 PreviousPosition { get; set; }

        public override void OnExitState() => Handler.Motion.Movement.OnFinishMotion -= Handler.Enable;

        public void ExecuteAttack(Vector3 targetPosition)
        {
            TargetPosition = targetPosition;
            MoveTowards();
        }

        void MoveTowards()
        {
            Handler.Motion.Movement.StopMotion();
            PreviousPosition = Handler.transform.position;
            Handler.Motion.MoveTo(TargetPosition, moveSpeedAttack);
            Handler.Motion.Movement.OnFinishMotion += MoveBack;
        }

        void MoveBack()
        {
            Handler.Motion.Movement.OnFinishMotion -= MoveBack;
            Handler.Motion.MoveTo(PreviousPosition, moveSpeedAttack);
            Handler.Motion.Movement.OnFinishMotion += Handler.Enable;
            Handler.Motion.Movement.OnFinishMotion += Handler.Unselect;
        }
    }
}