using System;
using SimpleCardGames.Data.Character;
using UnityEngine;

namespace SimpleCardGames.Battle.UI.Character
{
    //--------------------------------------------------------------------------------------------------------------

    /// <summary>
    ///     Data stored inside the an UI character.
    /// </summary>
    public interface IUiCharacterData
    {
        IRuntimeCharacter RuntimeData { get; }
        ICharacterData StaticData { get; }
        Action<ICharacterData> OnSetData { get; set; }
        void SetData(IRuntimeCharacter character);
    }

    //--------------------------------------------------------------------------------------------------------------

    public class UiCharacterDataComponent : MonoBehaviour, IUiCharacterData
    {
        /// <summary>
        ///     Set a card.
        /// </summary>
        /// <param name="character"></param>
        public void SetData(IRuntimeCharacter character)
        {
            RuntimeData = character;
            OnSetData?.Invoke(StaticData);
        }

        /// <summary>
        ///     Static card data reference.
        /// </summary>
        public ICharacterData StaticData => RuntimeData.Data;

        /// <summary>
        ///     Fired when a card model is assigned to this card.
        /// </summary>
        public Action<ICharacterData> OnSetData { get; set; } = data => { };

        /// <summary>
        ///     Card correspondent in the game model.
        /// </summary>
        public IRuntimeCharacter RuntimeData { get; private set; }
    }
}