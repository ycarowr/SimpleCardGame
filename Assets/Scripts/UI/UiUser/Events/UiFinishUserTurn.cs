using UnityEngine;

namespace SimpleCardGames.Battle
{
    [RequireComponent(typeof(IUiUserInput))]
    [RequireComponent(typeof(IUiPlayer))]
    public class UiFinishUserTurn : UiListener, IFinishPlayerTurn
    {
        private IUiUserInput UserInput { get; set; }
        private IUiPlayer Ui { get; set; }

        //----------------------------------------------------------------------------------------------------------

        #region Game Events

        void IFinishPlayerTurn.OnFinishPlayerTurn(IPlayer player)
        {
            if (Ui.PlayerController.IsUser)
                UserInput.Disable();
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        private void Awake()
        {
            Ui = GetComponent<IUiPlayer>();
            UserInput = GetComponent<IUiUserInput>();
        }
    }
}