using UnityEngine.EventSystems;

namespace SimpleCardGames.Battle.UI.Card
{
    /// <summary>
    ///     Battlefield Zone.
    /// </summary>
    public class UiZoneBattleField : UiBaseDropZone
    {
        protected override void OnPointerUp(PointerEventData eventData)
        {
            CardHand?.PlaySelected();
        }
    }
}