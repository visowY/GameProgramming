using System;

namespace IOCLearn
{
    internal class Role
    {

        public IAttackStrategy Weapon { get; set; }

        public void Attack(Monster monster)
        {
           Weapon.AttackTarget(monster);
        }
    }
}