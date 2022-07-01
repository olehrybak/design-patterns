using System;
using Enemies;

namespace Defenders
{
    class Archer : Warrior
    {
        private int arrows;
        
        public Archer(string name, int strength, int arrows) : base(name, strength)
        {
            this.arrows = arrows;
        }

        public override void AttackGiant(Giant giant)
        {
            for (int i = 0; i < 2; i++)
            {
                if (arrows <= 0)
                {
                    Console.WriteLine($"Archer {name} sees the Giant {giant.Name}, but he doesn't have enough arrows to attack.");
                    return;
                }
                int damage = strength;
                Console.WriteLine($"Archer {name} hits the giant {giant.Name}. Damage: {damage} HP");
                giant.GetDamage(damage);
                arrows -= 1;
            }

        }

        public override void AttackOgre(Ogre ogre)
        {
            if (arrows <= 0)
            {
                Console.WriteLine($"Archer {name} sees the ogre {ogre.Name}, but he doesn't have enough arrows to attack.");
                return;
            }
            int damage = strength;
            Console.WriteLine($"Archer {name} hits the ogre {ogre.Name}. Damage: {damage} HP");
            ogre.GetDamage(damage);
            arrows -= 1;
        }

        public override void AttackRat(Rat rat)
        {
            if (arrows <= 0)
            {
                Console.WriteLine($"Archer {name} sees the rat {rat.Name}, but he doesn't have enough arrows to attack.");
                return;
            }
            if (rng.NextDouble() < (rat.Speed / 100))
            {
                Console.WriteLine($"Archer {name} tries to hit the rat {rat.Name}, but misses");
                return;
            }
            int damage = strength;
            Console.WriteLine($"Archer {name} hits the rat {rat.Name}. Damage: {damage} HP");
            rat.GetDamage(damage);
            arrows -= 1;
        }
    }
}