using System;
using System.Collections.Generic;

namespace D_DesignPattern
{
    public class BuilderExam
    {
        public static void DoMain()
        {
            Direct direct = new Direct();
            Builder b1 = new ConcreteBuilder1();
            Builder b2 = new ConcreteBuilder2();
            
            direct.Construct(b1);

            Computer c1 = b1.GetComputer();
            c1.Show();
            
            direct.Construct(b2);
            Computer c2 = b2.GetComputer();
            c2.Show();
        }
    }
    
    # region 建造者模式


    public class Direct
    {

        public void Construct(Builder builder)
        {
            builder.BuildPartCPU();
            builder.BuildPartMainBoard();
        }
    }


    //抽象建造者
    public abstract class Builder
    {
        public abstract void BuildPartCPU();

        public abstract void BuildPartMainBoard();

        public abstract Computer GetComputer();

    }

    public class ConcreteBuilder1 : Builder
    {
        Computer _computer = new Computer();
        
        public override void BuildPartCPU()
        {
            _computer.Add("CPU1");
        }

        public override void BuildPartMainBoard()
        {
            _computer.Add("Main Board 1");
        }

        public override Computer GetComputer()
        {
            return _computer;
        }
    }
    
    public class ConcreteBuilder2 : Builder
    {
        Computer _computer = new Computer();
        
        public override void BuildPartCPU()
        {
            _computer.Add("CPU2");
        }

        public override void BuildPartMainBoard()
        {
            _computer.Add("Main Board 2");
        }

        public override Computer GetComputer()
        {
            return _computer;
        }
    }


    public class Computer
    {
        private IList<string> parts = new List<string>();

        public void Add(string part)
        {
            parts.Add(part);
        }

        public void Show()
        {
            Console.WriteLine("组装开始");
            foreach (var part in parts)
            {
                Console.WriteLine($"组件 {part} 已经组装好了");
            }

            Console.WriteLine("组装完成");
        }
    }




    # endregion 
}