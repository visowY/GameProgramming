namespace IOCLearn
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // 生成怪物
            Monster m1 = new Monster("小怪物A" , 50);
            Monster m2 = new Monster("小怪物B" , 50);
            Monster m3 = new Monster("小Boss", 200);
            Monster m4 = new Monster("大Boss" , 1000);
            
            Role role = new Role();
            
            role.Weapon = new WoodSword();
            role.Attack(m1);
            
            role.Weapon = new IronSword();
            role.Attack(m2);
            role.Attack(m3);
            
            role.Weapon = new MagicSword();
            role.Attack(m3);
            role.Attack(m4);
            role.Attack(m4);
            role.Attack(m4);
            role.Attack(m4);
        }
    }
    
    
    /*
     * OCP原则： 开放封闭原则：设计应该对扩展开放，对修改关闭。
     *
     * Strategy Pattern: 定义算法族，分别封装起来，让他们之间可以相互替换，此模式使的算法的变化独立于客户。
     */
}