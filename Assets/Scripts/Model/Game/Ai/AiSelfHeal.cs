namespace SimpleCardGames.Battle
{
    /// <summary>
    ///     This AI always heals itself... and never wins.
    /// </summary>
    public class AiSelfHeal : AiBase
    {
        public AiSelfHeal(IPlayer player, IPrimitiveGame game) : base(player, game)
        {
        }

        public override MoveType GetBestMove()
        {
            return MoveType.HealMove;
        }
    }
}