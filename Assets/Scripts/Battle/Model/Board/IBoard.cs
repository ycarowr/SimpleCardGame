using Tools;

namespace SimpleCardGames.Battle
{
    /// <summary>
    ///     A board interface.
    /// </summary>
    public interface IBoard
    {
        Collection<IRuntimeCharacter> Characters { get; }
        Collection<IBoardPosition> Positions { get; }
        void AddCharacter(IRuntimeCharacter tile, IBoardPosition position);
        void RemoveTile(IRuntimeCharacter tile, IBoardPosition position);
        void CreateBoard();
        void Clear();
    }
}