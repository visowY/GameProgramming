using System;

namespace D_DesignPattern
{
    /*装饰器模式(组合优于继承)
     *     Component:
     *     ConcreteComponent:
     *     Decorator:
     *     ConcreteDecorator: 
     */

    public abstract class Component
    {
        public abstract void Print();
    }

    public class ConcreteComponent : Component
    {
        public override void Print()
        {
            Console.WriteLine("this is ConcreteComponent!");
        }
    }

    public class Decorator:Component
    {
        protected Component _component;
        public void SetComponent(Component component)
        {
            _component = component;
        }

        public override void Print()
        {
            _component?.Print();
        }
    }

    public class ConcreteDecoratorA : Decorator
    {
        public override void Print()
        {
            base.Print();
            Console.WriteLine("this is ConcreteDecoratorA!");
        }
    }

    public class ConcreteDecoratorB : Decorator
    {
        public override void Print()
        {
            base.Print();
            Console.WriteLine("this is ConcreteDecoratorB!");
        }
    }
}