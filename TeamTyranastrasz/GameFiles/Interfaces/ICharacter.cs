﻿namespace RpgGame.Interfaces
{
    public interface ICharacter
    {
        int Strength { get; }

        int Dexterity { get; }

        int Vitality { get; }

        int Intelligence { get; }

        int AttackPoints { get; }

        int DefencePoints { get; }

        int HitPoints { get; }

        int Experience { get; }

        int Cash { get; }

        //void CalculateAttackPoints();

        //void CalculateDefensePoints();

        //void CalculateHitPoints();
    }
}
