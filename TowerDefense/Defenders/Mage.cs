using System;
using Enemies;

namespace Defenders
{
    class Mage : IDefender
    {
        protected readonly string name;
        protected int mana;
        protected readonly int manaRegen;
        protected readonly int spellPower;
        
        public Mage(string name, int mana, int manaRegen, int spellPower)
        {
            this.name = name;
            this.mana = mana;
            this.manaRegen = manaRegen;
            this.spellPower = spellPower;
        }

        protected bool CanCastSpell()
        {
            if (mana >= spellPower)
            {
                mana -= spellPower;
                return true;
            }

            Console.WriteLine($"Mage {name} is recharging mana");
            RechargeMana();
            return false;
        }

        private void RechargeMana()
        {
            mana += manaRegen;
        }


        public virtual void AttackGiant(Giant giant)
        {
            if (CanCastSpell())
            {
                int damage = spellPower;
                Console.WriteLine($"Mage {name} hits the giant {giant.Name}. Damage: {damage} HP");
                giant.GetDamage(damage);
            }
        }

        public virtual void AttackOgre(Ogre ogre)
        {
            if (CanCastSpell())
            {
                int damage = Math.Max(1, spellPower - ogre.Armor);
                Console.WriteLine($"Mage {name} hits the ogre. Damage: {damage} HP");
                ogre.GetDamage(damage);
            }
        }

        public virtual void AttackRat(Rat rat)
        {
            if (CanCastSpell())
            {
                int damage = spellPower;
                Console.WriteLine($"Mage {name} hits the rat {rat.Name}. Damage: {damage} HP");
                rat.GetDamage(damage);
            }
        }
    }
}