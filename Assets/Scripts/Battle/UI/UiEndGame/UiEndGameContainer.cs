using System.Collections;
using SimpleCardGames.Battle.Controller;
using UnityEngine;

namespace SimpleCardGames.Battle
{
    public interface IRestartGameHandler
    {
        void RestartGame();
    }

    /// <summary>
    ///     End game HUD. Solves model dependencies accessing the game controller via Singleton.
    /// </summary>
    [RequireComponent(typeof(IUiUserInput))]
    public class UiEndGameContainer : UiListener,
        IRestartGameHandler,
        IFinishGame,
        IStartGame,
        IUiController
    {
        //----------------------------------------------------------------------------------------------------------

        void IRestartGameHandler.RestartGame() => Controller.RestartGameImmediately();

        //----------------------------------------------------------------------------------------------------------

        #region Unity Callbacks

        void Awake()
        {
            //user input
            UserInput = gameObject.AddComponent<UiUserInput>();

            //HUD end game
            gameObject.AddComponent<UiButtonsEndGame>();
        }

        #endregion

        IEnumerator EnableInput()
        {
            yield return new WaitForSeconds(DelayToEnable);
            UserInput.Enable();
        }
        //----------------------------------------------------------------------------------------------------------

        #region Properties

        const float DelayToEnable = 1f;
        IUiUserInput UserInput { get; set; }
        public IGameController Controller => GameController.Instance;

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Game Events

        void IFinishGame.OnFinishGame(IPlayer winner) => StartCoroutine(EnableInput());

        void IStartGame.OnStartGame(IPlayer starter) => UserInput.Disable();

        #endregion
    }
}