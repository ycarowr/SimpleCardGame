
using SimpleCardGames.Data.Character;
using SimpleCardGames;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleCardGames.Battle
{
    public class CharAttributes
    {
        public int DefaultMaxHealth { get; private set; }

        public bool IsFullHealth => Health == DefaultMaxHealth;

        public CharacterData CharacterData {get;set;}

        public int Health { get;set; }

        public int MaxHealth { get; set; }

        public bool IsDead { get; set; }

        public IPlayer Owner { get; set; }

        //----------------------------------------------------------------------------------------------------------

        public CharAttributes(CharacterData data, IPlayer owner)
        {
            SetData(data, owner);
        }

        public void SetData(CharacterData data, IPlayer owner)
        {
            CharacterData = data;
            MaxHealth = data.Health;
            Health = data.Health;
            Owner = owner;
            DefaultMaxHealth = Owner.Configurations.Amount.HealthPlayers.GetHealth(owner.Seat);
            Health = DefaultMaxHealth;
        }
    }
}