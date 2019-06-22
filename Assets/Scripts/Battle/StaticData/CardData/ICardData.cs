using SimpleCardGames.Data.Effects;

namespace SimpleCardGames.Data.Card
{
    public interface ICardData : IBaseData
    {
        CardId Id { get; }
        int CardCost { get; }
        CardType CardType { get; }
        CardMonsterType CardMonsterType { get; }
        EffectsSet Effects { get; }
    }
}