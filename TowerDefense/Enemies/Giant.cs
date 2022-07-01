using System;
using System.ComponentModel.DataAnnotations;
using Defenders;

namespace Enemies
{
    class Giant : Enemy
    {
        public Giant(string name, int hp) : base(name, hp)
        { }

        public new void GetDamage(int damage)
        {
            base.GetDamage(damage);
        }

        public override void AcceptDefender(IDefender defender)
        {
            defender.AttackGiant(this);
        }
    }
}