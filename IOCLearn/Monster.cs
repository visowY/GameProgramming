using System;

namespace IOCLearn
{
    /// <summary>
    /// 怪物
    /// </summary>
    public sealed class Monster
    {
        public string Name { get; set; }
        public int HP { get; set; }

        public Monster(string name, int hp)
        {
            Name = name;
            HP = hp;
        }

        public void Notify(int loss)
        {
            if (HP <= 0)
            {
                Console.WriteLine("此怪物已经死亡");
                return;
            }

            HP -= loss;
            if (HP <= 0)
            {
                Console.WriteLine($"怪物 {Name} 被打死了");
            }
            else
            {
                Console.WriteLine($"怪物 {Name} 损失了 {loss} HP");
            }
        }
    }
}