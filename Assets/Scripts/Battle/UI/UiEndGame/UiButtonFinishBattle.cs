using System.Collections;
using System.Collections.Generic;
using Patterns;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SimpleCardGames.Battle
{
    public class UiButtonFinishBattle : UiButton,
        IListener,
        IPreGameStart,
        IFinishGame
    {
        private const float DelayToShow = 3.5f;
        private UITextMeshImage UiButton { get; set; }

        protected override void OnSetHandler(IButtonHandler handler)
        {
            if (handler is IFinishBattle finish)
                AddListener(finish.FinishBattle);
        }

        private IEnumerator ShowButton()
        {
            yield return new WaitForSeconds(DelayToShow);
            UiButton.Enabled = true;
        }

        public interface IFinishBattle
        {
            void FinishBattle();
        }

        //----------------------------------------------------------------------------------------------------------

        #region Game Events

        void IFinishGame.OnFinishGame(IPlayer winner)
        {
            StartCoroutine(ShowButton());
        }

        void IPreGameStart.OnPreGameStart(List<IPlayer> players)
        {
            UiButton.Enabled = false;
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Unity callbacks

        protected void Awake()
        {
            UiButton = new UITextMeshImage(
                GetComponentInChildren<TMP_Text>(),
                GetComponent<Image>());
        }

        private void Start()
        {
            GameEvents.Instance.AddListener(this);
        }

        private void OnDestroy()
        {
            if (GameEvents.Instance)
                GameEvents.Instance.RemoveListener(this);
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------
    }
}