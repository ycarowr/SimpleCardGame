using TMPro;
using Tools.UI;
using UnityEngine;

namespace SimpleCardGames.Battle.UI
{
    public class UiNotificationText : MonoBehaviour, IUiMotion
    {
        TextMeshPro Text { get; set; }
        public UiMotion Motion { get; private set; }

        void Awake()
        {
            Text = GetComponent<TextMeshPro>();
            Motion = new UiMotion(this);
            Motion.Movement.OnFinishMotion += Finish;
        }

        void Finish() => UiNotificationTextPooler.Instance.ReleasePooledObject(gameObject);

        public void Write(Vector3 startPosition, Vector3 finalPosition, string text, float speed, Color color)
        {
            transform.position = startPosition;
            Text.text = text;
            Text.color = color;
            Motion.MoveTo(finalPosition, speed);
        }

        void Update() => Motion?.Update();
    }
}