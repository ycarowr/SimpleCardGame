using Patterns.StateMachine;

namespace SimpleCardGames.Battle.UI.Card
{
    /// <summary>
    ///     This state disables the collider of the card.
    /// </summary>
    public class UiCardDisable : UiBaseCardState
    {
        public UiCardDisable(IUiCard handler, BaseStateMachine fsm, UiCardParameters parameters) : base(handler, fsm,
            parameters)
        {
        }

        public override void OnEnterState()
        {
            Disable();
        }
    }
}