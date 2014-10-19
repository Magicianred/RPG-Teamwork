﻿namespace RpgGame.Player
{
    using System.Linq;
    using System;
    using System.Collections.Generic;
    using RpgGame.Interfaces;
    using RpgGame.Items;

    public abstract class Player : Unit, IAttack, IDefend, IMovable, ITeleportable, IUsable, ITrade, ICharacter
    {
        //private int Level = 1;

        public readonly int StrengthModifier;
        public readonly int DexterityModifier;
        public readonly int VitalityModifier;
        public readonly int IntelligenceModifier;

        private Position position;
        private int cash;

        protected Player(string name, int str, int dex, int vit, int intl, int strengthModifier, int dexterityModifier, int vitalityModifier, int intelligenceModifier) : base(name)
        {
            this.Strength = str;
            this.Dexterity = dex;
            this.Vitality = vit;
            this.Intelligence = intl;
            this.StrengthModifier = strengthModifier;
            this.DexterityModifier = dexterityModifier;
            this.VitalityModifier = vitalityModifier;
            this.IntelligenceModifier = intelligenceModifier;
            CalculateAttackPoints();
            CalculateDefencePoints();
            CalculateHitPoints();
            this.CurrentHitPoints = this.MaxHitPoints;
            this.Position = new Position();
        }

        public int Strength { get; set; }

        public int Dexterity { get; set; }

        public int Vitality { get; set; }

        public int Intelligence { get; set; }

        public int MaxHitPoints { get; set; }

        public int CurrentHitPoints { get; set; }

        public int DefencePoints { get; set; }

        public int AttackPoints { get; set; }

        public int Experience { get; set; }

        public int Cash {
            get { return this.cash; }

            set {
                if (this.Cash - value < 0)
                {
                    throw new InvalidOperationException("You do not have enough money for this action.");
                }

                this.cash = value;
            }
        }

        //public int Level { get; set; }
        public List<Item> Inventory { get; set; }

        public List<Item> Equiped { get; set; }

        private int CalculateAttackPoints()
        {
            this.AttackPoints = (this.Strength * this.StrengthModifier) + (this.Intelligence * this.IntelligenceModifier);
            return this.AttackPoints;
        }

        private int CalculateDefencePoints()
        {
            this.DefencePoints = this.Dexterity * this.DexterityModifier;
            return this.DefencePoints;
        }

        private int CalculateHitPoints()
        {
            this.MaxHitPoints = this.Vitality * this.VitalityModifier;
            return this.MaxHitPoints;
        }

        public virtual void Attack()
        {
            int damage = CalculateAttackPoints();
            damage += this.Equiped.Sum(item => item.DefencePoints);

        }

        public virtual void Defend()
        {
            int defence = CalculateDefencePoints(); 
            defence += this.Equiped.Sum(item => item.DefencePoints);
        }

        public virtual void Move()
        {
            throw new NotImplementedException();
        }

        public void Teleport()
        {
            throw new NotImplementedException();
        }

        // The next couple of methods probably should implement an event - click over an item
        public void Consume(Item item)
        {
            if (item.IsConsumable)
            {
                this.MaxHitPoints += item.HitPoints;
                this.RemoveFromInventory(item);
            }
        }

        public void Equip(Item item)
        {
            foreach (var equipedItem in Equiped)
            {
                if (equipedItem.GetType() == item.GetType())
                {
                    throw new Exception("You cannot have two items from the same type");
                }
            }

            this.Equiped.Add(item);
        }

        public void AddToInventory(Item item)
        {
            if (this.Inventory.Count < 10)
            {
                this.Inventory.Add(item);
            }
        }

        public void RemoveFromInventory(Item item)
        {
            this.Inventory.Remove(item);
        }

        public void Sell(Item item)
        {
            this.Cash += item.Price;
            this.RemoveFromInventory(item);
        }

        public void Buy(Item item)
        {
            if (this.Cash >= item.Price)
            {
                this.AddToInventory(item);
            }
        }
    }
}
