using UnityEngine;

namespace SimpleCardGames.Battle
{
    [RequireComponent(typeof(IUiUserInput))]
    [RequireComponent(typeof(IUiPlayer))]
    public class UiFinishUserTurn : UiListener, IFinishPlayerTurn
    {
        IUiUserInput UserInput { get; set; }
        IUiPlayer Ui { get; set; }

        //----------------------------------------------------------------------------------------------------------

        #region Game Events

        void IFinishPlayerTurn.OnFinishPlayerTurn(IPlayer player)
        {
            if (Ui.PlayerController.IsUser)
                UserInput.Disable();
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        void Awake()
        {
            Ui = GetComponent<IUiPlayer>();
            UserInput = GetComponent<IUiUserInput>();
        }
    }
}