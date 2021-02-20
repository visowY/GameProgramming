using System;

namespace D_DesignPattern
{
    public class Adapter
    {
        // 类的适配器模式 示例
        public static void DoMian()
        {
            IThreeHole threeHole = new PowerAdapter();
            threeHole.Request();
        }
    }
    
    # region 类的适配器模式实现

    public interface IThreeHole
    {
        void Request();
    }

    public abstract class TwoHole
    {
        public void SpecificRequest()
        {
            Console.WriteLine("两孔插口调用方法");
        }
    }
    
    //适配器类
    public class PowerAdapter : TwoHole, IThreeHole
    {
        
        public void Request()
        {
            this.SpecificRequest();
        }
    }
    # endregion 
    
    # region 对象适配器模式

    public class ThreeHole2
    {
        public virtual void Request()
        {
        }
    }

    public class TwoHole2
    {
        public void SpecificRequest()
        {
            Console.WriteLine("两孔插座调用");
        }
    }

    public class PowerAdapter2 : ThreeHole2
    {
        public TwoHole2 twoHoleAdapter = new TwoHole2();

        public override void Request()
        {
            twoHoleAdapter.SpecificRequest();
        }
    }

    # endregion 
}