using System;
using System.Collections;

namespace D_DesignPattern
{
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
    }

    public class Picture : Graphics()
    {
        protected  ArrayList picList = new ArrayList();
        
        public Picture(string name) : base(name)
        {
        }

        public override void Draw()
        {
            
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
    }
}