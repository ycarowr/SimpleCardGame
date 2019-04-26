using Tools;

namespace SimpleCardGames.Battle
{
    /// <summary>
    ///     A board interface.
    /// </summary>
    public interface IBoard
    {
        Collection<ICharacter> Characters { get; }
        Collection<IBoardPosition> Positions { get; }
        void AddCharacter(ICharacter tile, IBoardPosition position);
        void RemoveTile(ICharacter tile, IBoardPosition position);
        void CreateBoard();
        void Clear();
    }
}