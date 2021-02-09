using System;

namespace D_DesignPattern
{
    
   /*责任链模式
    *    　责任链模式（Chain of Responsibility Pattern）。属于行为型模式。它使多个对象都有机会处理请求，
    * 从而避免发送者和接受者之间的耦合关系。将这个对象连成一条链，并沿着这条链传递该请求，直到有一个对象处理它为止。
    *      常用来重构 if 语句
    *
    * 
    */ 
    public class ChainResponsibility
    {

        public static void DoMain()
        {
            Response direct = new Director();
            direct.Handle(5);
        }

    }


    public abstract class Response
    {
        protected Response NextResponse;
        public abstract void Handle(int dayNum);
    }

    public class Chief:Response
    {
        public Chief()
        {
            NextResponse = new TopManager();
        }

        public override void Handle(int dayNum)
        {
            Console.WriteLine("总监审批同意");
            if (dayNum > 7)
            {
                NextResponse.Handle(dayNum);
            }
        }
    }

    public class TopManager : Response
    {
        public override void Handle(int dayNum)
        {
            Console.WriteLine("总经理审批同意");
        }
    }

    public class Director : Response
    {
        public Director()
        {
            NextResponse = new Chief();
        }

        public override void Handle(int dayNum)
        {
            Console.WriteLine("主管审批同意");
            if (dayNum > 3)
            {
                NextResponse.Handle(dayNum);
            }
        }
    }

}