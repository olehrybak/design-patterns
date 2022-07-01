using System;
using Defenders;

namespace Enemies
{
    class Rat : Enemy
    {
        public int Speed { get; set; }

        public new void GetDamage(int damage)
        {
            Speed++;
            base.GetDamage(damage);
        }

        public Rat(string name, int hp, int speed) : base(name, hp)
        {
            Speed = speed;
        }

        public override void AcceptDefender(IDefender defender)
        {
            defender.AttackRat(this);
        }
    }
}