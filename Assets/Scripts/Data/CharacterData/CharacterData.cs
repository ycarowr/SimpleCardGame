using SimpleCardGames.Data.Effects;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace SimpleCardGames.Data.Character
{ 
    [CreateAssetMenu(menuName = "Data/Character")]
    public class CharacterData : ScriptableObject
    {
        [Range(1, 16)] public int Health;

        [Tooltip("Root of the Effects")]
        public EffectsSet Effects;
    }
}