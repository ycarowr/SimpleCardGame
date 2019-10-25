using UnityEngine;

namespace SimpleCardGames.Data.Card
{
    public class UiChangeCardMinionFrame : UiChangeCardSprite
    {
        protected override Sprite GetSprite() => null;

        protected override Color GetSpriteColor() => new Color(.55f, .55f, .55f);

        protected override bool ShowSprite() => Handler.StaticData.CardType == CardType.Minion;
    }
}