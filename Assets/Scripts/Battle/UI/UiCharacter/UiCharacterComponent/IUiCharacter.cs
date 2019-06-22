using Patterns.StateMachine;
using SimpleCardGames.Data.Effects;
using Tools.UI;
using UnityEngine;

namespace SimpleCardGames.Battle.UI.Character
{
    /// <summary>
    ///     A complete UI character.
    /// </summary>
    public interface IUiCharacter : IStateMachineHandler, IUiCharacterComponents, IUiMotion, ITargetable
    {
        IUiCharacterData Data { get; }
        IUiPlayerTeam Team { get; }
        bool IsUser { get; }
        bool IsInitialized { get; }
        bool IsHovering { get; }
        bool IsDisabled { get; }
        bool IsAttacking { get; }
        void Initialize();
        void Disable();
        void Enable();
        void Select();
        void Unselect();
        void Hover();
        void Restart();
        void Attack(Vector3 targetPosition);
    }
}