namespace IOCLearn
{
    public class IronSword:IAttackStrategy
    {
        public void AttackTarget(Monster monster)
        {
            monster.Notify(50);
        }
    }
}