using System;

namespace SimpleCardGames.Battle.UI.Card
{
    /// <summary>
    ///     An pile of UI cards.
    /// </summary>
    public interface IUiCardPile
    {
        Action<IUiCard[]> OnPileChanged { get; set; }
        void AddCard(IUiCard uiCard);
        void RemoveCard(IUiCard uiCard);
        void Restart();
    }
}