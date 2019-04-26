namespace SimpleCardGames.Battle
{
    public interface IBoardPosition
    {
        bool HasCharacter { get; }
        void AddCharacter(ICharacter character);
        void RemoveCharacter();
    }
}