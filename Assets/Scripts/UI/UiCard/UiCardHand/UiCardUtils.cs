using System.Collections;
using Extensions;
using SimpleCardGames.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        private UiCardHand CardHand { get; set; }

        #endregion

        //--------------------------------------------------------------------------------------------------------------

        #region Unitycallbacks

        private void Awake()
        {
            CardHand = transform.parent.GetComponentInChildren<UiCardHand>();
        }

        private IEnumerator Start()
        {
            //starting cards
            for (var i = 0; i < 6; i++)
            {
                yield return new WaitForSeconds(0.2f);
                DrawRandom();
            }
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------------

        #region Operations

        [Button]
        public void DrawRandom()
        {
            var rand = Random.Range(0, 3);
            switch (rand)
            {
                case 0:
                    DrawAWizard();
                    break;
                case 1:
                    DrawAChimera();
                    break;
                case 2:
                    DrawADemon();
                    break;
            }
        }

        [Button]
        public void DrawAWizard()
        {
            var cardGo = CardFactory.Instance.Get(CardId.Wizard);
            DrawCard(cardGo);
        }

        [Button]
        public void DrawAChimera()
        {
            var cardGo = CardFactory.Instance.Get(CardId.Chimera);
            DrawCard(cardGo);
        }

        [Button]
        public void DrawADemon()
        {
            var cardGo = CardFactory.Instance.Get(CardId.Demon);
            DrawCard(cardGo);
        }


        public void DrawCard(GameObject cardGo)
        {
            cardGo.name = "Card_" + Count;
            var card = cardGo.GetComponent<IUiCard>();
            card.transform.position = deckPosition.position;
            Count++;
            CardHand.AddCard(card);
        }

        [Button]
        public void PlayCard()
        {
            if (CardHand.Cards.Count > 0)
            {
                var randomCard = CardHand.Cards.RandomItem();
                CardHand.PlayCard(randomCard);
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab)) DrawAWizard();
            if (Input.GetKeyDown(KeyCode.Space)) PlayCard();
            if (Input.GetKeyDown(KeyCode.Escape)) Restart();
        }

        public void Restart()
        {
            SceneManager.LoadScene(0);
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------------
    }
}