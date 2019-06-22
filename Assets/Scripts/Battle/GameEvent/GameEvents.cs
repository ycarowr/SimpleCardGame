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
    ///     Broadcast of a attack to the Listeners.
    /// </summary>
    public interface IDoAttack : ISubject
    {
        void OnDamage(IDamager source, IDamageable target, int amount);

        //Character has not attacks left
        void OnCantAttack(IDamager source, IDamageable target, int amount);
    }

    /// <summary>
    ///     Broadcast of a damage to the Listeners.
    /// </summary>
    public interface IDoDamage : ISubject
    {
        void OnDamage(IDamager source, IDamageable target, int amount);
    }

    /// <summary>
    ///     Broadcast of a heal to the Listeners.
    /// </summary>
    public interface IDoHeal : ISubject
    {
        void OnHeal(IHealer source, IHealable target, int amount);
    }

    public interface IDoKill : ISubject
    {
        void OnKill(IRuntimeCharacter target);
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
    ///     Broadcast of a draw minion card.
    /// </summary>
    public interface IPlayerDrawMinionCard : ISubject
    {
        void OnDrawMinionCard(IPlayer player, IRuntimeCard card);
    }

    /// <summary>
    ///     Broadcast of a draw spell card.
    /// </summary>
    public interface IPlayerDrawSpellCard : ISubject
    {
        void OnDrawSpellCard(IPlayer player, IRuntimeCard card);
    }

    /// <summary>
    ///     Broadcast of a draw power card.
    /// </summary>
    public interface IPlayerDrawPowerCard : ISubject
    {
        void OnDrawPowerCard(IPlayer player, IRuntimeCard card);
    }

    /// <summary>
    ///     Broadcast of a draw curse card.
    /// </summary>
    public interface IPlayerDrawCurseCard : ISubject
    {
        void OnDrawCurseCard(IPlayer player, IRuntimeCard card);
    }

    /// <summary>
    ///     Broadcast of a discard card.
    /// </summary>
    public interface IPlayerDiscardCard : ISubject
    {
        void OnDiscardCard(IPlayer player, IRuntimeCard card);
    }

    /// <summary>
    ///     Broadcast of a play minion card.
    /// </summary>
    public interface IPlayerDiscardMinionCard : ISubject
    {
        void OnDiscardMinionCard(IPlayer player, IRuntimeCard card);
    }

    /// <summary>
    ///     Broadcast of a play spell card.
    /// </summary>
    public interface IPlayerDiscardSpellCard : ISubject
    {
        void OnDiscardSpellCard(IPlayer player, IRuntimeCard card);
    }

    /// <summary>
    ///     Broadcast of a play power card.
    /// </summary>
    public interface IPlayerDiscardPowerCard : ISubject
    {
        void OnDiscardPowerCard(IPlayer player, IRuntimeCard card);
    }

    /// <summary>
    ///     Broadcast of a play curse card.
    /// </summary>
    public interface IPlayerDiscardCurseCard : ISubject
    {
        void OnDiscardCurseCard(IPlayer player, IRuntimeCard card);
    }

    /// <summary>
    ///     Broadcast of a play card.
    /// </summary>
    public interface IPlayerPlayCard : ISubject
    {
        void OnPlayCard(IPlayer player, IRuntimeCard card);
    }

    /// <summary>
    ///     Broadcast of a play minion card.
    /// </summary>
    public interface IPlayerPlayMinionCard : ISubject
    {
        void OnPlayMinionCard(IPlayer player, IRuntimeCard card);
    }

    /// <summary>
    ///     Broadcast of a play spell card.
    /// </summary>
    public interface IPlayerPlaySpellCard : ISubject
    {
        void OnPlaySpellCard(IPlayer player, IRuntimeCard card);
    }

    /// <summary>
    ///     Broadcast of a play power card.
    /// </summary>
    public interface IPlayerPlayPowerCard : ISubject
    {
        void OnPlayPowerCard(IPlayer player, IRuntimeCard card);
    }

    /// <summary>
    ///     Broadcast of a play curse card.
    /// </summary>
    public interface IPlayerPlayCurseCard : ISubject
    {
        void OnPlayCurseCard(IPlayer player, IRuntimeCard card);
    }

    /// <summary>
    ///     Broadcast of a mana consumption.
    /// </summary>
    public interface IDoManaManipulation : ISubject
    {
        void OnChangeMana(IPlayer player, int amount);
    }

    /// <summary>
    ///     Broadcast of a reshuffle.
    /// </summary>
    public interface IDoReShuffle : ISubject
    {
        void OnReShuffle(IPlayer player);
    }

    /// <summary>
    ///     Broadcast of a spawn character.
    /// </summary>
    public interface IPlayerSpawnCharacter : ISubject
    {
        void OnSpawnCharacter(IPlayer player, IRuntimeCharacter character);
    }

    /// <summary>
    ///     Broadcast of restart game.
    /// </summary>
    public interface IRestartGame : ISubject
    {
        void OnRestart();
    }

    #endregion

    //----------------------------------------------------------------------------------------------------------
}