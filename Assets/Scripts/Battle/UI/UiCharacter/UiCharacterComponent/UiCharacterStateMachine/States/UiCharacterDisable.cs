using Patterns.StateMachine;

namespace SimpleCardGames.Battle.UI.Character
{
    /// <summary>
    ///     This state disables the collider of the character.
    /// </summary>
    public class UiCharacterDisable : UiBaseCharacterState
    {
        public UiCharacterDisable(IUiCharacter handler, BaseStateMachine fsm, UiCharacterParameters parameters) : base(
            handler, fsm, parameters)
        {
        }

        public override void OnEnterState()
        {
            Disable();
        }
    }
}