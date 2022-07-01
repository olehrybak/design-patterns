using System;
using Enemies;

namespace Defenders
{
    class RatCatcher : IDefender
    {
        protected readonly string name;
        private bool hasRat;
        
        public RatCatcher(string name)
        {
            this.name = name;
            hasRat=false;
        }


        public void AttackGiant(Giant giant)
        {
            
        }

        public void AttackOgre(Ogre ogre)
        {
            if (hasRat)
            {
                Console.WriteLine($"Rat Catcher {name} throws a rat into ogre {ogre.Name}. Poor ogre is scared to death!");
                ogre.GetDamage(ogre.HP);
            }
            else
            {
                Console.WriteLine($"Rat Catcher {name} sees the ogre {ogre.Name}, but he doesn't have rats!");
            }
        }

        public void AttackRat(Rat rat)
        {
            Console.WriteLine($"Rat Catcher {name} catches the rat {rat.Name}");
            rat.GetDamage(rat.HP);
        }
    }
}