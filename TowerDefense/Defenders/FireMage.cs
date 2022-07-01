using System;
using Enemies;

namespace Defenders
{
    class FireMage : Mage
    {
        private double killChance;
        protected static readonly Random rng = new Random(1597);

        public FireMage(string name, int mana, int manaRegen, int spellPower, double killChance) : base(name, mana, manaRegen, spellPower)
        {
            this.killChance = killChance;
        }

        public override void AttackGiant(Giant giant)
        {
            if (CanCastSpell())
            {
                if (rng.NextDouble() < killChance)
                {
                    Console.WriteLine($"Fire Mage {name} incinerated the giant {giant.Name}!");
                    giant.GetDamage(giant.HP);
                }
                else
                {
                    int damage = spellPower;
                    Console.WriteLine($"Fire Mage {name} hits the giant {giant.Name}. Damage: {damage} HP");
                    giant.GetDamage(damage);
                }
            }
        }

        public override void AttackOgre(Ogre ogre)
        {
            if (CanCastSpell())
            {
                if (rng.NextDouble() < killChance)
                {
                    Console.WriteLine($"Fire Mage {name} incinerated the ogre {ogre.Name}!");
                    ogre.GetDamage(ogre.HP);
                }
                else
                {
                    int damage = Math.Max(1, spellPower - ogre.Armor);
                    Console.WriteLine($"Fire Mage {name} hits the ogre {ogre.Name}. Damage: {damage} HP");
                    ogre.GetDamage(damage);
                }
            }
        }

        public override void AttackRat(Rat rat)
        {
            if (CanCastSpell())
            {
                if (rng.NextDouble() < killChance)
                {
                    Console.WriteLine($"Fire Mage {name} incinerated the rat {rat.Name}!");
                    rat.GetDamage(rat.HP);
                }
                else
                {
                    int damage = spellPower;
                    Console.WriteLine($"Fire Mage {name} hits the rat {rat.Name}. Damage: {damage} HP");
                    rat.GetDamage(damage);
                }
            }
        }
    }
}