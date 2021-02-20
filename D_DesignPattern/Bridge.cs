using System;

namespace D_DesignPattern
{
    public class Bridge
    {
        public static void DoMain()
        {
            Abstraction abs = new RefinedAbstraction();
            abs.Implementor = new ConcreteImplementorA();
            abs.Operation();
            
            abs.Implementor = new ConcreteImplementorB();
            abs.Operation();
        }
    }

    # region 桥接模式

    public abstract class Implementor
    {
        public abstract void Operation();
    }

    public class Abstraction
    {
        protected Implementor _implementor;
        
        public Implementor Implementor
        {
            set => _implementor = value;
        }

        public virtual void Operation()
        {
            _implementor.Operation();
        }
    }

    public class ConcreteImplementorA : Implementor
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteImplementorA Operation");
        }
    }

    public class ConcreteImplementorB : Implementor
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteImplementorB Operation");
        }
    }

    public class RefinedAbstraction : Abstraction
    {
        public override void Operation()
        {
            _implementor.Operation();
        }
    }


    # endregion 
}