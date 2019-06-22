using System.Collections.Generic;
using SimpleCardGames.Battle.Controller;

namespace SimpleCardGames.Battle
{
    public class UiManaText : UiText3DListener, IDoManaManipulation, IPreGameStart
    {
        private const string Mana = "Mana: ";

        void IDoManaManipulation.OnChangeMana(IPlayer player, int amount)
        {
            var user = GameController.Instance.GetUser();

            if (user.Player == player)
                SetMana(player);
        }

        void IPreGameStart.OnPreGameStart(List<IPlayer> players)
        {
            var player = GameController.Instance.GetUser();
            SetMana(player.Player);
        }

        private void SetMana(IPlayer player)
        {
            SetText(Mana + player.Mana);
        }
    }
}