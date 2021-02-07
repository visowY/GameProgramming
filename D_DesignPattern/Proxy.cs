using System;

namespace D_DesignPattern
{
 
    /*代理模式：
     *     定义： 为客户端提供一种中间层以控制对这个对象的访问。
     *            
     *    Proxy:
     *    Subject:
     *    ConcreteSubject:
     *    Client:
     */


    public abstract class Subject
    {
        public abstract void Request();
    }

    public class ConcreteSubject : Subject{
        
        public override void Request()
        {
            Console.WriteLine("called ConcreteSubject.Request();");
        }
    }


    public class Proxy:Subject
    {
        private ConcreteSubject _concreteSubject;
        
        public override void Request()
        {
            if (_concreteSubject == null)
            {
                _concreteSubject = new ConcreteSubject();
            }
            _concreteSubject.Request();
        }
    }
}