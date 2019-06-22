using System.Collections.Generic;
using Patterns;
using SimpleCardGames.Data.Card;
using SimpleCardGames.Data.Effects;

namespace SimpleCardGames.Battle
{
    /// <summary>
    ///     Manages RuntimeCharacter memory allocation.
    /// </summary>
    public class RuntimeCharacterFactory : Pooler<RuntimeCharacter, RuntimeCharacterFactory>
    {
        private const int Size = 30;
        
        public RuntimeCharacterFactory() : base(Size)
        {
            
        }
    }
}