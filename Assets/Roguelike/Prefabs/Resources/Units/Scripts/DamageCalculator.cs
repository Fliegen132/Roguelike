using Roguelike.Skills;

namespace Roguelike.Units
{
    public static class DamageCalculator
    {
        public static int DoCalc(int damage, ElementType attackType, ElementType targetType)
        {
            float newDamage = 0;
            if (attackType == targetType)
                return damage;
            
            if (attackType == ElementType.Fire && targetType == ElementType.Water) 
                newDamage = damage / 1.5f;
            else if (attackType == ElementType.Water && targetType == ElementType.Fire)
                newDamage = damage * 1.5f;
            
            return (int)newDamage;
        }
    }
}