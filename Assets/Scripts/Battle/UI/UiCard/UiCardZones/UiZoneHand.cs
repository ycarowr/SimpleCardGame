using UnityEngine.EventSystems;

namespace SimpleCardGames.Battle.UI.Card
{
    /// <summary>
    ///     GameController hand zone.
    /// </summary>
    public class UiZoneHand : UiBaseDropZone
    {
        protected override void OnPointerUp(PointerEventData eventData)
        {
            CardHand?.Unselect();
        }
    }
}