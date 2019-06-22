using System.Collections.Generic;
using SimpleCardGames.Battle.Controller;

namespace SimpleCardGames.Battle.UI.Card
{
    public class UiCardLibrarySize : UiText3DListener, IDoReShuffle, IPlayerDrawCard, IPreGameStart
    {
        private const string Size = "Size: ";

        void IDoReShuffle.OnReShuffle(IPlayer player)
        {
            SetSize(player);
        }

        void IPlayerDrawCard.OnDrawCard(IPlayer player, IRuntimeCard card)
        {
            SetSize(player);
        }

        void IPreGameStart.OnPreGameStart(List<IPlayer> players)
        {
            SetSize(GameController.Instance.GetUser().Player);
        }

        private void SetSize(IPlayer player)
        {
            if (player == GameController.Instance.GetUser().Player)
                SetText(Size + player.Library.Size);
        }
    }
}