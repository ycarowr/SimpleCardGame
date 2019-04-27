using System;
using System.Collections;
using Extensions;
using SimpleCardGames.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using Extensions;
using System.Linq;
using SimpleCardGames;
using SimpleCardGames.Battle.Controller;
using SimpleCardGames.Battle;

namespace Tools.UI.Card
{
    public class UiCardUtils : MonoBehaviour
    {
        //--------------------------------------------------------------------------------------------------------------

        #region Fields

        private int Count { get; set; }

        [SerializeField] [Tooltip("Prefab of the Card C#")]
        private GameObject cardPrefabCs;

        [SerializeField] [Tooltip("World point where the deck is positioned")]
        private Transform deckPosition;

        [SerializeField] [Tooltip("Game view transform")]
        private Transform gameView;

        private IUiCardHand CardHand { get; set; }

        #endregion

        //--------------------------------------------------------------------------------------------------------------

        #region Unitycallbacks

        private void Awake()
        {
            CardHand = transform.parent.GetComponentInChildren<UiCardHand>();
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------------

        public void Draw(IRuntimeCard card)
        {
            var cardGo = CardFactory.Instance.Get(card);
            var uiCard = cardGo.GetComponent<IUiCard>();
            cardGo.name = "Card_" + Count;
            cardGo.transform.position = deckPosition.position;
            Count++;
            CardHand.AddCard(uiCard);
        }
 
        public void Discard(IRuntimeCard card)
        {
            var uiCard = CardHand.GetCard(card);
            CardHand.DiscardCard(uiCard);
        }

        public void PlayCard(IRuntimeCard card)
        {
            var uiCard = CardHand.GetCard(card);
            CardHand.PlayCard(uiCard);
        }

        //--------------------------------------------------------------------------------------------------------------

        private void Update()
        { 
            if (Input.GetKeyDown(KeyCode.Escape)) Restart();
        }

        public void Restart()
        {
            SceneManager.LoadScene(0);
        }

        //--------------------------------------------------------------------------------------------------------------
    }
}