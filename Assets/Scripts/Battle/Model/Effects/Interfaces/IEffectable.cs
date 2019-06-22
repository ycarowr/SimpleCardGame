namespace SimpleCardGames.Data.Effects
{
    /// <summary>
    ///     Any entities able to target something with an effect.
    /// </summary>
    public interface IEffectable
    {
        EffectsSet Effects { get; }
    }
}