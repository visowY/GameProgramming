using System;
using System.Collections;

namespace D_DesignPattern
{
    public class VistorExam
    {
        public static void DoMain()
        {
            ObjectStructure objectStructure = new ObjectStructure();

            foreach (Element element in objectStructure.Elements)
            {
                element.Accept(new ConcreteViator());
            }
        }
    }
    
    # region 访问者模式
    
    // 抽象访问者
    public interface IViator
    {
        void Visit(ElementA a);
        void Visit(ElementB b);
    }
    
    // 具体访问者
    public class ConcreteViator:IViator
    {
        public void Visit(ElementA a)
        {
            a.Print();
        }

        public void Visit(ElementB b)
        {
            b.Print();
        }
    }


    public abstract class Element
    {
        public abstract void Print();
        public abstract void Accept(IViator viator);
    }

    public class ElementA : Element
    {
        public override void Print()
        {
            Console.WriteLine("AAAAAAA");
        }

        public override void Accept(IViator viator)
        {
            viator.Visit(this);
        }
    }
    
    public class ElementB : Element
    {
        public override void Print()
        {
            Console.WriteLine("BBBBBBB");
        }

        public override void Accept(IViator viator)
        {
            viator.Visit(this);
        }
    }

    public class ObjectStructure
    {
        private ArrayList elements = new ArrayList();

        public ArrayList Elements => elements;

        public ObjectStructure()
        {
            Random ran = new Random();
            for (int i = 0; i < 6; i++)
            {
                int ranNum = ran.Next(10);
                if (ranNum > 5)
                {
                    elements.Add(new ElementA());
                }
                else
                {
                    elements.Add(new ElementB());
                }
            }
        }
    }

    # endregion 
}