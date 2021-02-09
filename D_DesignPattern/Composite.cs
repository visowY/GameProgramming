using System;
using System.Collections;
using System.Collections.Generic;

namespace D_DesignPattern
{
    
    /*    组合模式：使用同等方法统一处理复杂&简答方法
     * 
     *     解耦了客户端程序&复杂原色内部结构，从而使客户程序可以像处理简单元素一样来处理复杂元素。
     *
     *     透明式组合模式
     *
     *     安全式组合模式
     *
     * 
     */
    public class Composite
    {
        
    }

    public abstract class Graphics
    {
        protected string _name;

        public Graphics(string name)
        {
            _name = name;
        }

        public abstract void Draw();

        public abstract void Add(Graphics g);
        public abstract void Remove(Graphics g);
    }

    public class Picture : Graphics
    {
        private List<Graphics> _listGrahpics = new List<Graphics>();         
        public Picture(string name) : base(name)
        {
        }

        public override void Draw()
        {
            _listGrahpics.ForEach(_=>_.Draw());
        }

        public override void Add(Graphics g)
        {
            _listGrahpics.Add(g);
        }

        public override void Remove(Graphics g)
        {
            _listGrahpics.Remove(g);
        }

        public ArrayList GetChilds()
        {
            return null;
        }
    }

    public class Line : Graphics
    {
        public Line(string name) : base(name)
        {
        }

        public override void Draw()
        {
            Console.WriteLine("Draw a "+ _name);
        }

        public override void Add(Graphics g)
        {
            throw new Exception("不能向简单图形line添加其它图像");
        }

        public override void Remove(Graphics g)
        {
            throw new Exception("不能向简单图形line移除其它图像");
        }
    }

    public class Circle : Graphics
    {
        public Circle(string name) : base(name)
        {
        }

        public override void Draw()
        {
            Console.WriteLine("Draw a "+ _name);
        }

        public override void Add(Graphics g)
        {
            throw new Exception("不能向简单图形Circle添加其它图像");
        }

        public override void Remove(Graphics g)
        {
            throw new Exception("不能向简单图形Circle移除其它图像");
        }
    }

    public class Recttangle : Graphics
    {
        public Recttangle(string name) : base(name)
        {
        }

        public override void Draw()
        {
            Console.WriteLine("Draw a "+ _name);
        }

        public override void Add(Graphics g)
        {
            throw new Exception("不能向简单图形Recttangle添加其它图像");
        }

        public override void Remove(Graphics g)
        {
            throw new Exception("不能向简单图形Recttangle移除其它图像");
        }
    }
}