using System;
using System.Collections.Generic;
using SimpleCardGames.Data.Character;
using UnityEngine;

namespace SimpleCardGames.Battle.UI.Character
{
    //------------------------------------------------------------------------------------------------------------------

    /// <summary>
    ///     Pile of cards. Add or Remove cards and be notified when changes happen.
    /// </summary>
    public abstract class UiCharacterPile : MonoBehaviour, IUiCharacterPile
    {
        //--------------------------------------------------------------------------------------------------------------

        #region Unitycallbacks

        protected virtual void Awake()
        {
            //initialize register
            Characters = new List<IUiCharacter>();

            Restart();
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------------

        #region Properties

        /// <summary>
        ///     List with all cards.
        /// </summary>
        public List<IUiCharacter> Characters { get; private set; }

        public IUiCharacter Capitain { get; private set; }

        /// <summary>
        ///     Event raised when add or remove a character.
        /// </summary>
        public Action<IUiCharacter[], IUiCharacter> OnPileChanged { get; set; } = (crew, capitain) => { };

        #endregion

        //--------------------------------------------------------------------------------------------------------------

        #region Operations

        public virtual void AddCapitain(IUiCharacter character)
        {
            Capitain = character;
            AddCharacter(character);
        }

        /// <summary>
        ///     Add a character to the pile.
        /// </summary>
        /// <param name="character"></param>
        public virtual void AddCharacter(IUiCharacter character)
        {
            if (character == null)
                throw new ArgumentNullException("Null is not a valid argument.");

            Characters.Add(character);
            character.transform.SetParent(transform);
            character.transform.localPosition = Vector3.zero;
            character.Initialize();
            character.Enable();
            NotifyPileChange();
        }


        /// <summary>
        ///     Remove a character from the pile.
        /// </summary>
        /// <param name="character"></param>
        public virtual void RemoveCharacter(IUiCharacter character)
        {
            if (character == null)
                throw new ArgumentNullException("Null is not a valid argument.");

            Characters.Remove(character);
            NotifyPileChange();
        }

        public virtual void RemoveCharacter(IRuntimeCharacter character)
        {
            if (character == null)
                throw new ArgumentNullException("Null is not a valid argument.");

            //I believe this Find is ok to destroy remove the ui element
            var uiCharacter = Characters.Find(x => x.Data.RuntimeData == character);
            if (uiCharacter == null)
                return;

            RemoveCharacter(uiCharacter);
        }

        /// <summary>
        ///     Clear all the pile.
        /// </summary>
        [Button]
        public virtual void Restart()
        {
            for (var i = 0; i < Characters.Count; i++)
            {
                var character = Characters[i];
                if (character != null && character.gameObject.activeSelf)
                    CharacterFactory.Instance.ReleasePooledObject(character.gameObject);
            }

            Characters.Clear();
        }

        /// <summary>
        ///     Notify all listeners of this pile that some change has been made.
        /// </summary>
        [Button]
        public void NotifyPileChange()
        {
            OnPileChanged?.Invoke(Characters.ToArray(), Capitain);
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------------
    }
}