using System;

namespace D_DesignPattern
{
    public class BridgeExam
    {
        
    }

    public abstract class MakeCoffee
    {
        public abstract void Making();
    }

    public sealed class MakeCoffeeSingleton
    {
        private static MakeCoffee _instance;

        public MakeCoffeeSingleton(MakeCoffee instance)
        {
            _instance = instance;
        }

        public static MakeCoffee Instance => _instance;
    }

    public abstract class Coffee
    {
        private MakeCoffee _makeCoffee;

        public Coffee()
        {
            _makeCoffee = MakeCoffeeSingleton.Instance;
        }

        public MakeCoffee MakeCoffee()
        {
            return _makeCoffee;
        }

        public abstract void Make();
    }

    public class BlackCoffee : MakeCoffee
    {
        public override void Making()
        {
            Console.WriteLine("黑咖啡");
        }
    }



}