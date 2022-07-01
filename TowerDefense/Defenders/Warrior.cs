using System;
using Enemies;

namespace Defenders
{
    class Warrior : IDefender
    {
        protected readonly string name;
        protected readonly int strength;
        protected static readonly Random rng = new Random(1597);
        

        public Warrior(string name, int strength)
        {
            this.name = name;
            this.strength = strength;
        }

        public virtual void AttackGiant(Giant giant)
        {
            int damage = strength;
            Console.WriteLine($"Warrior {name} hits the giant {giant.Name}. Damage: {damage} HP");
            giant.GetDamage(damage);
        }

        public virtual void AttackOgre(Ogre ogre)
        {
            int damage = Math.Max(1, strength - ogre.Armor);
            Console.WriteLine($"Warrior {name} hits the ogre {ogre.Name}. Damage: {damage} HP");
            ogre.GetDamage(damage);
        }

        public virtual void AttackRat(Rat rat)
        {
            if (rng.NextDouble() < (rat.Speed / 100))
            {
                Console.WriteLine($"Warrior {name} tries to hit the rat {rat.Name}, but misses");
                return;
            }
            int damage = strength;
            Console.WriteLine($"Warrior {name} hits the rat {rat.Name}. Damage: {damage} HP");
            rat.GetDamage(damage);
        }
    }
}