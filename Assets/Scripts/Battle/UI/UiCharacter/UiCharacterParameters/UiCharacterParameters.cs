using UnityEngine;

namespace SimpleCardGames.Battle.UI.Character
{
    [CreateAssetMenu(menuName = "Parameters/Character")]
    public class UiCharacterParameters : ScriptableObject
    {
        [SerializeField] private bool allowSpacingX = true;
        [SerializeField] private bool allowSpacingY;
        [SerializeField] [Range(0, 1)] private float disabledAlpha = 0.6f;
        [SerializeField] [Range(1, 3)] private float scaleHover;
        [SerializeField] [Range(1, 3)] private float scaleIdle;
        [SerializeField] [Range(1, 3)] private float scaleSelect;
        [SerializeField] [Range(-20, 20)] private float spacingX;
        [SerializeField] [Range(-20, 20)] private float spacingY;

        //------------------------------------------------------------------------------------------------------
        public float ScaleIdle => scaleIdle;
        public float ScaleHover => scaleHover;
        public float ScaleSelect => scaleSelect;
        public float SpacingX => spacingX;
        public float SpacingY => spacingY;
        public bool AllowSpacingX => allowSpacingX;
        public bool AllowSpacingY => allowSpacingY;

        public float DisabledAlpha => disabledAlpha;
    }
}