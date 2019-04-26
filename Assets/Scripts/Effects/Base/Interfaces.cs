namespace SimpleCardGame.Data.Effects
{
    /// <summary>
    ///     Any entity able to be targeted by an effect.
    /// </summary>
    public interface IEffectAble
    {
    }

    /// <summary>
    ///     Any entity able to draw a card.
    /// </summary>
    public interface IDrawAble : IEffectAble
    {
        void Draw();
    }

    /// <summary>
    ///     Any entity able to discard a card.
    /// </summary>
    public interface IDiscardAble : IEffectAble
    {
        void Discard();
    }

    /// <summary>
    ///     Any entity able to be damaged.
    /// </summary>
    public interface IDamageAble : IEffectAble
    {
        void TakeDamage();
    }

    /// <summary>
    ///     Any entity able to be healed.
    /// </summary>
    public interface IHealAble : IEffectAble
    {
        void TakeHeal();
    }
}