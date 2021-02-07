using System;

namespace D_DesignPattern.Example
{
    public class ProxyExample
    {
        var _target =  new Proxy();
        
        
    }





    public abstract class ProxyTarget
    {
        public abstract void DoMain();
    }


    public class ReadBook:ProxyTarget
    {
        public override void DoMain()
        {
            Console.WriteLine("I'm reading book!");
        }
    }


    public class Proxy:ProxyTarget
    {
        public Proxy()
        {
            if(_target == null)
            _target = new ReadBook();
        }

        private ProxyTarget _target;
        public override void DoMain()
        {
            _target?.DoMain();
        }
    }
}