namespace SimpleCardGames.Battle
{
    /// <summary>
    ///     This AI module always tries the random option.
    /// </summary>
    public class AiVeryLucky : AiBase
    {
        public AiVeryLucky(IPlayer player, IPrimitiveGame game) : base(player, game)
        {
        }

        public override MoveType GetBestMove()
        {
            return MoveType.RandomMove;
        }
    }
}