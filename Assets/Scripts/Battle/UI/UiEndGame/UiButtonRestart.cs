﻿using System.Collections;
using System.Collections.Generic;
using Patterns;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SimpleCardGames.Battle
{
    public class UiButtonRestart : UiButton,
        IListener,
        IPreGameStart,
        IFinishGame
    {
        const float DelayToShow = 3.5f;
        UITextMeshImage UiButton { get; set; }

        protected override void OnSetHandler(IButtonHandler handler)
        {
            if (handler is IPressRestart restart)
                AddListener(restart.PressRestart);
        }

        IEnumerator ShowButton()
        {
            yield return new WaitForSeconds(DelayToShow);
            UiButton.Enabled = true;
        }

        public interface IPressRestart
        {
            void PressRestart();
        }

        //----------------------------------------------------------------------------------------------------------

        #region Game Events

        void IFinishGame.OnFinishGame(IPlayer winner) => StartCoroutine(ShowButton());

        void IPreGameStart.OnPreGameStart(List<IPlayer> players) => UiButton.Enabled = false;

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Unity callbacks

        protected void Awake() =>
            UiButton = new UITextMeshImage(
                GetComponentInChildren<TMP_Text>(),
                GetComponent<Image>());

        void Start() => GameEvents.Instance.AddListener(this);

        void OnDestroy()
        {
            if (GameEvents.Instance)
                GameEvents.Instance.RemoveListener(this);
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------
    }
}