using SimpleCardGames.Data.Card;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SimpleCardGames.Battle.UI.Card
{
    public class UiPlayerHandUtils : MonoBehaviour
    {
        //--------------------------------------------------------------------------------------------------------------

        void Awake() => PlayerHand = transform.parent.GetComponentInChildren<IUiPlayerHand>();

        //--------------------------------------------------------------------------------------------------------------

        public void Draw(IRuntimeCard card)
        {
            var uiCard = CardFactory.Instance.Get(card);
            uiCard.MonoBehavior.name = "Card_" + Count;
            uiCard.transform.position = deckPosition.position;
            Count++;
            PlayerHand.AddCard(uiCard);
        }

        public void Discard(IRuntimeCard card)
        {
            var uiCard = PlayerHand.GetCard(card);
            PlayerHand.DiscardCard(uiCard);
        }

        public void PlayCard(IRuntimeCard card)
        {
            var uiCard = PlayerHand.GetCard(card);
            PlayerHand.PlayCard(uiCard);
        }

        //--------------------------------------------------------------------------------------------------------------

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape)) Restart();
        }

        public void Restart() => SceneManager.LoadScene(0);
        //--------------------------------------------------------------------------------------------------------------

        #region Fields

        int Count { get; set; }

        [SerializeField] [Tooltip("World point where the deck is positioned")]
        Transform deckPosition;

        IUiPlayerHand PlayerHand { get; set; }

        #endregion

        //--------------------------------------------------------------------------------------------------------------
    }
}