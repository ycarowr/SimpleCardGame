using UnityEngine;

namespace SimpleCardGames.Battle.UI.Character
{
    [CreateAssetMenu(menuName = "Parameters/Character")]
    public class UiCharacterParameters : ScriptableObject
    {
        [SerializeField] bool allowSpacingX = true;
        [SerializeField] bool allowSpacingY;
        [SerializeField] [Range(0, 1)] float disabledAlpha = 0.6f;
        [SerializeField] [Range(1, 3)] float scaleHover;
        [SerializeField] [Range(1, 3)] float scaleIdle;
        [SerializeField] [Range(1, 3)] float scaleSelect;
        [SerializeField] [Range(-20, 20)] float spacingX;
        [SerializeField] [Range(-20, 20)] float spacingY;

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