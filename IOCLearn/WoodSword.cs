namespace IOCLearn
{
    public class WoodSword:IAttackStrategy
    {
        public void AttackTarget(Monster monster)
        {
            monster.Notify(20);
        }
    }
}