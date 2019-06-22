﻿using System.Collections.Generic;
using Patterns;
using SimpleCardGames.Data.Card;
using SimpleCardGames.Data.Effects;

namespace SimpleCardGames.Battle
{
    /// <summary>
    ///     Manages RuntimeCard memory allocation.
    /// </summary>
    public class RuntimeCardFactory : Pooler<RuntimeCard, RuntimeCardFactory>
    {
        private const int Size = 30;
        
        public RuntimeCardFactory() : base(Size)
        {
            
        }
    }
}