using System;

namespace SimpleCardGames.Battle.UI.Character
{
    public interface IUiPlayerTeam : IUiCharacterPile
    {
        IUiPlayer Controller { get; }
        Action<IUiCharacter> OnCharacterSelected { get; set; }
        IClickZone UnselectZone { get; }
        void Unselect();
        void Restart();
        void SelectCharacter(IUiCharacter uiCharacter);
        void UnselectCharacter(IUiCharacter uiCharacter);
        void Attack(IUiCharacter attack, IUiCharacter defender);
        IUiCharacter GetCharacter(IRuntimeCharacter character);
    }
}