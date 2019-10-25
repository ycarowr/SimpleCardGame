using UnityEngine;

namespace SimpleCardGames.Battle.UI.Character
{
    [RequireComponent(typeof(IUiPlayerTeam))]
    public class UiPlayerTeamRestart : UiListener, IRestartGame
    {
        //--------------------------------------------------------------------------------------------------------------

        IUiPlayerTeam PlayerTeam { get; set; }

        //--------------------------------------------------------------------------------------------------------------

        void IRestartGame.OnRestart() => PlayerTeam.Restart();

        //--------------------------------------------------------------------------------------------------------------

        void Awake() => PlayerTeam = GetComponent<IUiPlayerTeam>();

        //--------------------------------------------------------------------------------------------------------------
    }
}