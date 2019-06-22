using UnityEngine;
using UnityEngine.SceneManagement;

namespace SimpleCardGames.Battle
{
    [RequireComponent(typeof(IRestartGameHandler))]
    public class UiButtonsEndGame : MonoBehaviour,
        IButtonHandler,
        UiButtonRestart.IPressRestart,
        UiButtonFinishBattle.IFinishBattle
    {
        private IRestartGameHandler PlayerHandler { get; set; }

        void UiButtonFinishBattle.IFinishBattle.FinishBattle()
        {
            SceneManager.LoadScene("RewardScene");
        }

        void UiButtonRestart.IPressRestart.PressRestart()
        {
            PlayerHandler.RestartGame();
        }

        private void Awake()
        {
            PlayerHandler = GetComponent<IRestartGameHandler>();

            var buttons = gameObject.GetComponentsInChildren<UiButton>();
            foreach (var button in buttons)
                button.SetHandler(this);
        }
    }
}