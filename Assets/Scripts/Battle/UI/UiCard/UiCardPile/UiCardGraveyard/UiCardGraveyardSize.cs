using System.Collections.Generic;
using SimpleCardGames.Battle.Controller;

namespace SimpleCardGames.Battle.UI.Card
{
    //------------------------------------------------------------------------------------------------------------------

    /// <summary>
    ///     Card graveyard holds a register with cards played by the player.
    /// </summary>
    public class UiCardGraveyardSize : UiText3DListener, IDoReShuffle, IPlayerPlayCard, IPlayerDiscardCard,
        IPreGameStart
    {
        const string Size = "Size: ";

        void IDoReShuffle.OnReShuffle(IPlayer player) => SetSize(player);

        void IPlayerDiscardCard.OnDiscardCard(IPlayer player, IRuntimeCard card) => SetSize(player);

        void IPlayerPlayCard.OnPlayCard(IPlayer player, IRuntimeCard card) => SetSize(player);

        void IPreGameStart.OnPreGameStart(List<IPlayer> players) => SetSize(GameController.Instance.GetUser().Player);

        void SetSize(IPlayer player)
        {
            if (player == GameController.Instance.GetUser().Player)
                SetText(Size + player.Graveyard.Size);
        }
    }
}