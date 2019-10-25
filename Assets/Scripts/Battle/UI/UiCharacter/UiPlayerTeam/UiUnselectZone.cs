using Tools.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SimpleCardGames.Battle.UI.Character
{
    public interface IClickZone
    {
        Collider Collider { get; }
        void Enable();
        void Disable();
    }

    [RequireComponent(typeof(IMouseInput))]
    [RequireComponent(typeof(Collider))]
    public class UiUnselectZone : MonoBehaviour, IClickZone
    {
        readonly Vector3 Offset = new Vector3(0, 0, 0.1f);

        //--------------------------------------------------------------------------------------------------------------

        IUiPlayerTeam UiPlayerTeam { get; set; }
        IMouseInput Input { get; set; }
        public Collider Collider { get; private set; }

        public void Disable() => Collider.enabled = false;

        public void Enable() => Collider.enabled = true;

        void Awake()
        {
            Collider = GetComponent<Collider>();
            Input = GetComponent<IMouseInput>();
            Input.OnPointerClick += Unselect;
            UiPlayerTeam = transform.GetComponentInParent<IUiPlayerTeam>();
            Disable();
        }

        void Unselect(PointerEventData obj) => UiPlayerTeam.Unselect();

        public void EnableOnTarget(Transform target)
        {
            var pos = target.position;
            transform.position = pos + Offset;
            Enable();
        }

        //--------------------------------------------------------------------------------------------------------------
    }
}