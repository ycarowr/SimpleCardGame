namespace SimpleCardGames
{
    /// <summary>
    ///     All units that are able to die.
    /// </summary>
    public interface IKillable
    {
        /// <summary>
        ///     Evaluate character death.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        void EvaluateDeath();
    }
}