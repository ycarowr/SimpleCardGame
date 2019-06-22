namespace SimpleCardGames.Data.Character
{
    public interface ICharacterData : IBaseData
    {
        CharacterId Id { get; }
        int Health { get; }
        int Attack { get; }
        int AttacksTurn { get; }
        bool HasTaunt { get; }
    }
}