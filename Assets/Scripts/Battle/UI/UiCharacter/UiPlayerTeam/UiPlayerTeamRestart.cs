using UnityEngine;

namespace SimpleCardGames.Battle.UI.Character
{
    [RequireComponent(typeof(IUiPlayerTeam))]
    public class UiPlayerTeamRestart : UiListener, IRestartGame
    {
        //--------------------------------------------------------------------------------------------------------------

        private IUiPlayerTeam PlayerTeam { get; set; }

        //--------------------------------------------------------------------------------------------------------------

        void IRestartGame.OnRestart()
        {
            PlayerTeam.Restart();
        }

        //--------------------------------------------------------------------------------------------------------------

        private void Awake()
        {
            PlayerTeam = GetComponent<IUiPlayerTeam>();
        }

        //--------------------------------------------------------------------------------------------------------------
    }
}