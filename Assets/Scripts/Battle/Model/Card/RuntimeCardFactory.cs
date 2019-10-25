using Patterns;

namespace SimpleCardGames.Battle
{
    /// <summary>
    ///     Manages RuntimeCard memory allocation.
    /// </summary>
    public class RuntimeCardFactory : Pooler<RuntimeCard, RuntimeCardFactory>
    {
        const int Size = 30;

        public RuntimeCardFactory() : base(Size)
        {
        }
    }
}