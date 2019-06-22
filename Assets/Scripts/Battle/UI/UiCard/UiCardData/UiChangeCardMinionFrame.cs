using UnityEngine;

namespace SimpleCardGames.Data.Card
{
    public class UiChangeCardMinionFrame : UiChangeCardSprite
    {
        protected override Sprite GetSprite()
        {
            return null;
        }

        protected override Color GetSpriteColor()
        {
            return new Color(.55f, .55f, .55f);
        }

        protected override bool ShowSprite()
        {
            return Handler.StaticData.CardType == CardType.Minion;
        }
    }
}