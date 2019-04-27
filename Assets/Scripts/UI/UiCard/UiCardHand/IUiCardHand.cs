using SimpleCardGames;
using System;

namespace Tools.UI.Card
{
    public interface IUiCardHand : IUiCardPile
    {
        Action<IUiCard> OnCardPlayed { get; set; }
        Action<IUiCard> OnCardSelected { get; set; }
        Action<IUiCard> OnCardDiscarded { get; set; }

        void PlaySelected();
        void Unselect();
        void PlayCard(IUiCard uiCard);
        void SelectCard(IUiCard uiCard);
        void DiscardCard(IUiCard uiCard);
        void UnselectCard(IUiCard uiCard);
        IUiCard GetCard(IRuntimeCard card);
    }
}