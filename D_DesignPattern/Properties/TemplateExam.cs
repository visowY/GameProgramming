using System;

namespace D_DesignPattern.Properties
{
    public class TemplateExam
    {
        public static void DoMain()
        {
            Spinach spinach = new Spinach();
            spinach.CookVegetable();
            
        }
    }
    
    #region 模版方法模式

    public abstract class Vegetable
    {
        public void CookVegetable()
        {
            Console.WriteLine("炒菜一般做法");
            PourOil();
            HeatOil();
            PourVegetable();
            StirFry();
        }

        public void PourOil()
        {
            Console.WriteLine("倒油");
        }

        public void HeatOil()
        {
            Console.WriteLine("热油");
        }

        public abstract void PourVegetable();

        public void StirFry()
        {
            Console.WriteLine("翻炒");
        }
    }

    public class Spinach : Vegetable
    {
        public override void PourVegetable()
        {
            Console.WriteLine("倒菠菜");
        }
    }
    
    public class ChineseCabbage : Vegetable
    {
        public override void PourVegetable()
        {
            Console.WriteLine("倒白菜");
        }
    }
    #endregion 
}