using System.Collections.Generic;
using Patterns;
using SimpleCardGames.Battle;
using SimpleCardGames.Battle.Controller;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Tools.UI.Card
{
    [RequireComponent(typeof(IMouseInput))]
    public class UiCardDrawerClick : MonoBehaviour
    {
        private UiCardUtils CardDrawer { get; set; }
        private IMouseInput Input { get; set; }

        private void Awake()
        {
            CardDrawer = transform.parent.GetComponentInChildren<UiCardUtils>();
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
            GameController.Instance.GetPlayerController(PlayerSeat.Bottom).Player.Draw();
        }

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Tab))
                DrawCard(null);
        }
    }
}