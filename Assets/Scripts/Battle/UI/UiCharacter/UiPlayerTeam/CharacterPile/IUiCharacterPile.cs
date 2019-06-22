using System;
using System.Collections.Generic;

namespace SimpleCardGames.Battle.UI.Character
{
    /// <summary>
    ///     An pile of UI characters.
    /// </summary>
    public interface IUiCharacterPile
    {
        List<IUiCharacter> Characters { get; }
        IUiCharacter Capitain { get; }
        Action<IUiCharacter[], IUiCharacter> OnPileChanged { get; set; }
        void AddCharacter(IUiCharacter uiCharacter);
        void AddCapitain(IUiCharacter uiCharacter);
        void RemoveCharacter(IUiCharacter uiCharacter);
        void RemoveCharacter(IRuntimeCharacter uiCharacter);
    }
}