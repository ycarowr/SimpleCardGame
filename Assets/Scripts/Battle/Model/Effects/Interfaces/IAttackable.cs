namespace SimpleCardGames
{
    /// <summary>
    ///     All units that are able to attack
    /// </summary>
    public interface IAttackable
    {
        /// <summary>
        ///     Check for applicable effects before playing (windfury for characters, echo for cards)
        /// </summary>
        /// <returns>bool</returns>
        bool CanAttack();

        void ExecuteAttack();
        void OnBeforeAttack();
        void OnAfterAttack();
    }
}