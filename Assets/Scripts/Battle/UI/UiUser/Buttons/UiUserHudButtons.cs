using UnityEngine;

namespace SimpleCardGames.Battle
{
    [RequireComponent(typeof(IUiUserInput))]
    [RequireComponent(typeof(IUiPlayer))]
    public class UiUserHudButtons : MonoBehaviour,
        UiButtonEndTurn.IPressEndTurn,
        UiButtonDamage.IPressDamage,
        UiButtonHeal.IPressHeal
    {
        IUiPlayer Ui { get; set; }
        IUiUserInput UserInput { get; set; }

        //----------------------------------------------------------------------------------------------------------

        #region Unity callback 

        void Awake()
        {
            UserInput = GetComponent<IUiUserInput>();
            Ui = GetComponent<IUiPlayer>();
            var buttons = gameObject.GetComponentsInChildren<UiButton>();
            foreach (var button in buttons)
                button.SetHandler(this);
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        void DisableInput() => UserInput.Disable();

        //----------------------------------------------------------------------------------------------------------

        #region Buttons

        void UiButtonDamage.IPressDamage.PressDamageMove()
        {
            //if (Ui.PlayerController.ProcessMove(MoveType.DamageMove))
            //    DisableInput();
        }

        void UiButtonHeal.IPressHeal.PressHealMove()
        {
            //if (Ui.PlayerController.ProcessMove(MoveType.HealMove))
            //    DisableInput();
        }

        void UiButtonEndTurn.IPressEndTurn.PressRandomMove()
        {
            if (Ui.PlayerController.PassTurn())
                DisableInput();
        }

        #endregion
    }
}