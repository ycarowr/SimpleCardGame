namespace SimpleCardGames.Battle
{
    public interface IBoardPosition
    {
        bool HasCharacter { get; }
        void AddCharacter(IRuntimeCharacter character);
        void RemoveCharacter();
    }
}