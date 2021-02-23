using System;

namespace IOCLearn
{
    public class MagicSword:IAttackStrategy
    {
        private Random _random = new Random();
        public void AttackTarget(Monster monster)
        {
            int loss = (_random.NextDouble() < 0.5) ? 100 : 200;
            if (200 == loss)
            {
                Console.WriteLine("出现暴击");
                monster.Notify(loss);
            }
        }
    }
}