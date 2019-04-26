using System.Collections.Generic;
using Patterns;

namespace SimpleCardGames.Battle
{
    //----------------------------------------------------------------------------------------------------------

    public class GameEvents : Observer<GameEvents>
    {
        protected override void OnAwake()
        {
            Logger.Instance.Log<GameEvents>("Awake");
        }

        private void Start()
        {
            Logger.Instance.Log<GameEvents>("Start");
        }
    }

    //----------------------------------------------------------------------------------------------------------

    #region Game Events Declaration

    /// <summary>
    ///     Broadcast of the players right before the game start.
    /// </summary>
    public interface IPreGameStart : ISubject
    {
        void OnPreGameStart(List<IPlayer> players);
    }

    /// <summary>
    ///     Broadcast of the starter player to the Listeners.
    /// </summary>
    public interface IStartGame : ISubject
    {
        void OnStartGame(IPlayer starter);
    }

    /// <summary>
    ///     Broadcast of the winner after a game is finished to the Listeners.
    /// </summary>
    public interface IFinishGame : ISubject
    {
        void OnFinishGame(IPlayer winner);
    }

    /// <summary>
    ///     Broadcast of a player when it starts the turn to the Listeners.
    /// </summary>
    public interface IStartPlayerTurn : ISubject
    {
        void OnStartPlayerTurn(IPlayer player);
    }

    /// <summary>
    ///     Broadcast of a player when it finishes the turn to the Listeners.
    /// </summary>
    public interface IFinishPlayerTurn : ISubject
    {
        void OnFinishPlayerTurn(IPlayer player);
    }

    /// <summary>
    ///     Broadcast of a damage to the Listeners.
    /// </summary>
    public interface IDoDamage : ISubject
    {
        void OnDamage(IAttackable source, IDamageable target, int amount);
    }

    /// <summary>
    ///     Broadcast of a heal to the Listeners.
    /// </summary>
    public interface IDoHeal : ISubject
    {
        void OnHeal(IHealer source, IHealable target, int amount);
    }

    /// <summary>
    ///     Broadcast of the time to the Listeners.
    /// </summary>
    public interface IDoTick : ISubject
    {
        void OnTickTime(int time, IPlayer player);
    }

    /// <summary>
    ///     Broadcast of a draw card.
    /// </summary>
    public interface IPlayerDrawCard : ISubject
    {
        void OnDrawCard(IPlayer player, IRuntimeCard card);
    }

    /// <summary>
    ///     Broadcast of a discard card.
    /// </summary>
    public interface IPlayerDiscardCard : ISubject
    {
        void OnDiscardCard(IPlayer player, IRuntimeCard card);
    }

    /// <summary>
    ///     Broadcast of a play card.
    /// </summary>
    public interface IPlayerPlayCard : ISubject
    {
        void OnPlayCard(IPlayer player, IRuntimeCard card);
    }

    #endregion

    //----------------------------------------------------------------------------------------------------------
}