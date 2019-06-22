using SimpleCardGames.Battle.Controller;
using Tools.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SimpleCardGames.Battle.UI.Card
{
    [RequireComponent(typeof(IMouseInput))]
    public class UiCardDrawerClick : MonoBehaviour
    {
        private UiPlayerHandUtils CardDrawer { get; set; }
        private IMouseInput Input { get; set; }

        private void Awake()
        {
            CardDrawer = transform.parent.GetComponentInChildren<UiPlayerHandUtils>();
            Input = GetComponent<IMouseInput>();
            Input.OnPointerClick += DrawCard;
        }

        [Button]
        private void Draw()
        {
            DrawCard(null);
        }

        private void DrawCard(PointerEventData obj)
        {
            GameController.Instance.GetPlayerController(PlayerSeat.Left).Player.Draw();
        }

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Tab))
                DrawCard(null);
        }
    }
}