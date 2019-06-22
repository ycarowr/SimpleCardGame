using Patterns.StateMachine;
using SimpleCardGames.Data.Card;
using Tools.UI;

namespace SimpleCardGames.Battle.UI.Card
{
    /// <summary>
    ///     A complete UI card.
    /// </summary>
    public interface IUiCard : IStateMachineHandler, IUiCardComponents, IUiMotion
    {
        IUiCardData Data { get; }
        IUiPlayerHand Hand { get; }
        bool IsInitialized { get; }
        bool IsDragging { get; }
        bool IsHovering { get; }
        bool IsDisabled { get; }
        void Initialize();
        void Disable();
        void Enable();
        void Select();
        void Unselect();
        void Hover();
        void Draw();
        void Discard();
        void Play();
        void Restart();
        void Target();
    }
}