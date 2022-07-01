using Enemies;

namespace Defenders
{
    interface IDefender
    {
        void AttackGiant(Giant giant);
        void AttackOgre(Ogre ogre);
        void AttackRat(Rat rat);
    }
}