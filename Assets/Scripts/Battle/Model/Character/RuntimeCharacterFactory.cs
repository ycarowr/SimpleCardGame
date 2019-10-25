using Patterns;

namespace SimpleCardGames.Battle
{
    /// <summary>
    ///     Manages RuntimeCharacter memory allocation.
    /// </summary>
    public class RuntimeCharacterFactory : Pooler<RuntimeCharacter, RuntimeCharacterFactory>
    {
        const int Size = 30;

        public RuntimeCharacterFactory() : base(Size)
        {
        }
    }
}