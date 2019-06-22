using System.Collections.Generic;
using UnityEngine;

namespace SimpleCardGames.Battle.UI.Character
{
    /// <summary>
    ///     Class responsible to bend the characters in the player hand.
    /// </summary>
    [RequireComponent(typeof(IUiPlayerTeam))]
    public class UiPlayerTeamPositioner : MonoBehaviour
    {
        //--------------------------------------------------------------------------------------------------------------

        #region Unitycallbacks

        private void Awake()
        {
            dirtyChrs = new List<IUiCharacter>();
            PlayerTeam = GetComponent<IUiPlayerTeam>();
            PlayerTeam.OnPileChanged += Positioning;
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------------

        //void Update()
        //{
        //    Positioning(PlayerTeam.Characters.ToArray());
        //}

        //--------------------------------------------------------------------------------------------------------------

        private void Positioning(IUiCharacter[] characters, IUiCharacter capitain)
        {
            var pivotX = pivot.position.x;
            var pivotY = pivot.position.y;

            var n = MaxCharactersPerLine;
            var m = MaxCharactersPerColumn;

            var charWidth = n * CharacterWidth;
            var charHeight = m * CharacterHeight;

            var totalWidth = charWidth + (n - 1) * characterParameters.SpacingX;
            var totalHeight = charHeight + (n - 1) * characterParameters.SpacingY;

            var side = PlayerTeam.Controller.Seat == PlayerSeat.Left ? 1 : -1;
            var minX = pivotX - side * totalWidth / 2;
            var minY = pivotY + totalHeight / 2;

            var deltaX = CharacterWidth;
            var deltaY = CharacterHeight;

            float px = 0, py = 0;

            if (characterParameters.AllowSpacingX)
                ResetPx();

            if (characterParameters.AllowSpacingY)
                ResetPy();

            var mainHerosOffset = capitain != null ? 1 : 0;

            for (var i = mainHerosOffset; i < characters.Length; i++)
            {
                var character = characters[i];
                var position = new Vector3(px, py);

                if (!character.IsAttacking) character.Motion.MoveTo(position, 4f);

                if (characterParameters.AllowSpacingX)
                    px += (deltaX + characterParameters.SpacingX) * side;

                if ((i - mainHerosOffset) % MaxCharactersPerLine == MaxCharactersPerLine - 1)
                {
                    ResetPx();
                    if (characterParameters.AllowSpacingY)
                        py -= deltaY + characterParameters.SpacingY;
                }
            }

            if (characters.Length > 0 && capitain != null)
            {
                var character = characters[mainHerosOffset - 1];
                if (!character.IsAttacking)
                    character.Motion.MoveTo(mainHerosPosition.transform.position, 4f);
            }

            void ResetPx()
            {
                px = minX + side * deltaX / 2;
            }

            void ResetPy()
            {
                py = minY + deltaY / 2;
            }
        }

        //--------------------------------------------------------------------------------------------------------------

        #region Fields and Properties

        private const int MaxCharactersPerLine = 4;
        private const int MaxCharactersPerColumn = 2;

        [SerializeField] private UiCharacterParameters characterParameters;

        [SerializeField] [Tooltip("The Card Prefab")]
        private UiCharacterComponent characterPrefab;

        [SerializeField] [Tooltip("Transform used as anchor to position the characters.")]
        private Transform pivot;

        private float CharacterWidth => characterPrefab.GetComponentInChildren<SpriteRenderer>().bounds.size.x;
        private float CharacterHeight => characterPrefab.GetComponentInChildren<SpriteRenderer>().bounds.size.y;

        private IUiPlayerTeam PlayerTeam { get; set; }
        private List<IUiCharacter> dirtyChrs;

        [SerializeField] private Transform mainHerosPosition;

        #endregion

        //--------------------------------------------------------------------------------------------------------------
    }
}