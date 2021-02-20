using System;
using System.Collections.Generic;

namespace D_DesignPattern
{
    public class FlyweightExam
    {
        
    }
    
    # region 享元模式

    public abstract class Flyweight
    {
        public abstract void Operation(int extrinsicstate);
    }


    public class FlyweightFactory
    {
        public Dictionary<string , Flyweight> _dictFlyweights = new Dictionary<string, Flyweight>();

        public FlyweightFactory()
        {
            _dictFlyweights.Add("A" , new ConcreteFlyweight("A"));
            _dictFlyweights.Add("B" ,  new ConcreteFlyweight("B"));
            _dictFlyweights.Add("C" , new ConcreteFlyweight("C"));
        }

        public Flyweight GetFlyweight(string key)
        {
            Flyweight temp;
            if (!_dictFlyweights.TryGetValue(key, out temp))
            {
                Console.WriteLine("驻留池中不存在字符串" + key);
                return null;
            }
            return temp;
        }
    }

    public class ConcreteFlyweight : Flyweight
    {
        private string _instrinsicstate;

        public ConcreteFlyweight(string innerstate)
        {
            _instrinsicstate = innerstate;
        }

        public override void Operation(int extrinsicstate)
        {
            Console.WriteLine($"具体的实现类： intrinsicstate: {_instrinsicstate}, extrinsicstate; {extrinsicstate}");
        }
    }
    # endregion 
}