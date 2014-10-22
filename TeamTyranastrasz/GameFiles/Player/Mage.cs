﻿using System.Collections.Generic;
namespace RpgGame.Player
{
    public class Mage : Player
    {
        public const int MageStartingStrength = 1;
        public const int MageStartingDexterity = 3;
        public const int MageStartingVitality = 5;
        public const int MageStartingIntelligence = 10;

        public const int MageStrengthModifier = 1;
        public const int MageDexterityModifier = 1;
        public const int MageVitalityModifier = 2;
        public const int MageIntelligenceModifier = 3;

        public Mage(string name)
            : base(name, MageStartingStrength, MageStartingDexterity, MageStartingVitality, MageStartingIntelligence, MageStrengthModifier, MageDexterityModifier, MageVitalityModifier, MageIntelligenceModifier)
        {
        }

        public Mage(string name, int strength, int dexterity, int vitality, int intelligence, int maxHitPoints, int experience, int cash, int level, List<IItem> inventory, List<IItem> equiped, Position position)
            : base(name, strength, dexterity, vitality, intelligence, maxHitPoints, experience, cash, level, inventory, equiped, position, MageStrengthModifier, MageDexterityModifier, MageVitalityModifier, MageIntelligenceModifier)
        {
        }

        public override void CastBuff(string type)
        {
            switch (type)
            {
                case "attack":
                    this.Intelligence += (int)((double)this.Intelligence * 0.1);
                    break;
                case "defence":
                    this.Dexterity += (int)((double)this.Dexterity * 0.05);
                    break;
                case "health":
                    int vitality = (int)((double)this.Vitality * 0.2);
                    int addHitPoints = vitality * this.VitalityModifier;
                    if (addHitPoints + this.CurrentHitPoints > this.MaxHitPoints)
                    {
                        this.CurrentHitPoints = this.MaxHitPoints;
                    }
                    else
                    {
                        this.CurrentHitPoints += addHitPoints;
                    }
                    break;
            }
        }

        public override void ClearBuff(string type)
        {
            switch (type)
            {
                case "attack":
                    this.Intelligence -= (int)((double)this.Intelligence * 0.1);
                    break;
                case "defence":
                    this.Dexterity -= (int)((double)this.Dexterity * 0.05);
                    break;
                case "health":
                    this.Vitality -= (int)((double)this.Vitality * 0.2);
                    break;
            }
        }
    }
}
