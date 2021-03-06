﻿using System.Collections.Generic;
using UnityEngine;

namespace SimpleCardGames.Battle
{
    [RequireComponent(typeof(IUiUserInput))]
    [RequireComponent(typeof(IUiPlayer))]
    public class UiPreStartGameUser : UiListener, IPreGameStart
    {
        IUiUserInput UserInput { get; set; }
        IUiPlayer Ui { get; set; }

        //----------------------------------------------------------------------------------------------------------

        #region Game Events

        void IPreGameStart.OnPreGameStart(List<IPlayer> players)
        {
            if (Ui.PlayerController.IsMyTurn)
                UserInput.Disable();
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        void Awake()
        {
            UserInput = GetComponent<IUiUserInput>();
            Ui = GetComponentInParent<IUiPlayer>();
        }
    }
}