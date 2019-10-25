using SimpleCardGames.Battle.Controller;
using Tools.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SimpleCardGames.Battle.UI.Card
{
    [RequireComponent(typeof(IMouseInput))]
    public class UiCardDrawerClick : MonoBehaviour
    {
        UiPlayerHandUtils CardDrawer { get; set; }
        IMouseInput Input { get; set; }

        void Awake()
        {
            CardDrawer = transform.parent.GetComponentInChildren<UiPlayerHandUtils>();
            Input = GetComponent<IMouseInput>();
            Input.OnPointerClick += DrawCard;
        }

        [Button]
        void Draw() => DrawCard(null);

        void DrawCard(PointerEventData obj) =>
            GameController.Instance.GetPlayerController(PlayerSeat.Left).Player.Draw();

        void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Tab))
                DrawCard(null);
        }
    }
}