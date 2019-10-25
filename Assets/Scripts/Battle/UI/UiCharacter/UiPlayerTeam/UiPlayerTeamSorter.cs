using UnityEngine;

namespace SimpleCardGames.Battle.UI.Character
{
    [RequireComponent(typeof(IUiPlayerTeam))]
    public class UiPlayerTeamSorter : MonoBehaviour
    {
        //--------------------------------------------------------------------------------------------------------------

        IUiPlayerTeam PlayerTeam { get; set; }

        //--------------------------------------------------------------------------------------------------------------

        void Awake()
        {
            PlayerTeam = GetComponent<IUiPlayerTeam>();
            PlayerTeam.OnPileChanged += Sort;
        }

        //--------------------------------------------------------------------------------------------------------------

        public void Sort(IUiCharacter[] characters, IUiCharacter capitain)
        {
            if (characters == null)
                return;

            foreach (var character in characters)
            {
                var position = character.transform.localPosition;
                position.z = 0;
                character.transform.localPosition = position;
            }
        }

        //--------------------------------------------------------------------------------------------------------------
    }
}