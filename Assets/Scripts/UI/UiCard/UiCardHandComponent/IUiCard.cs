using Patterns.StateMachine;
using SimpleCardGames.Data;

namespace Tools.UI.Card
{
    public interface IUiCard : IStateMachineHandler, IUiCardComponents, IUiCardTransform
    {
        ICardHandData HandData { get; }
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
    }
}