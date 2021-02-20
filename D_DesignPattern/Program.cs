using System;
using D_DesignPattern.Example;

namespace D_DesignPattern
{
    internal class Program
    {
        public static void Main(string[] args)
        {
//            #region Proxy 代理模式
//                Proxy proxy = new Proxy();
//                proxy.Request();
//            #endregion
//            
//            #region Decorator 装饰器模式
//                ConcreteComponent component = new ConcreteComponent();
//                ConcreteDecoratorA ca = new ConcreteDecoratorA();
//                ConcreteDecoratorB cb =new ConcreteDecoratorB();
//                
//                ca.SetComponent(component);
//                ca.Print();
//
//                Console.WriteLine("=============");
//                
//                cb.SetComponent(ca);
//                cb.Print();            
//            #endregion 

//            #region Emit的调用
//            
//
//            TypeCreator tp = new TypeCreator();
//            tp.Do();
//            #endregion

            


//             ProxyExample.DoMain();

                // 适配器模式
                Adapter.DoMian();
            
        }
    }
}