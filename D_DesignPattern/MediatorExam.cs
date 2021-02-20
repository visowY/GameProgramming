using System;

namespace D_DesignPattern
{
    public class MediatorExam
    {
        public static void DoMain()
        {
            AbstractCardPartner A = new PartnerA();
            AbstractCardPartner B = new PartnerB();

            A.MoneyCount = 20;
            B.MoneyCount = 20;
            AbstractMediator mediator = new MediatorPartner(A,B);
            
            A.ChangeCount(5,mediator);

            Console.WriteLine($"A 现在的钱是：{A.MoneyCount}");
            Console.WriteLine($"B 现在的钱是: {B.MoneyCount}");

            Console.WriteLine("=====================");
            
            B.ChangeCount(10,mediator);
            Console.WriteLine($"A 现在的钱是：{A.MoneyCount}");
            Console.WriteLine($"B 现在的钱是: {B.MoneyCount}");
        }
    }

    # region 中介者模式

    public abstract class AbstractCardPartner
    {
        public int MoneyCount { get; set; }

        public AbstractCardPartner()
        {
            MoneyCount = 0;
        }

        public abstract void ChangeCount(int count, AbstractMediator mediator);
    }

    public class PartnerA : AbstractCardPartner
    {
        public override void ChangeCount(int count, AbstractMediator mediator)
        {
            mediator.AWin(count);
        }
    }

    public class PartnerB : AbstractCardPartner
    {
        public override void ChangeCount(int count, AbstractMediator mediator)
        {
            mediator.BWin(count);
        }
    }

    public abstract class AbstractMediator
    {
        protected AbstractCardPartner A;
        protected AbstractCardPartner B;

        public AbstractMediator(AbstractCardPartner a, AbstractCardPartner b)
        {
            A = a;
            B = b;
        }

        public abstract void AWin(int count);
        public abstract void BWin(int count);
    }

    public class MediatorPartner : AbstractMediator
    {
        public MediatorPartner(AbstractCardPartner a, AbstractCardPartner b) : base(a, b)
        {
        }

        public override void AWin(int count)
        {
            A.MoneyCount += count;
            B.MoneyCount -= count;
        }

        public override void BWin(int count)
        {
            A.MoneyCount -= count;
            B.MoneyCount += count;
        }
    }

    # endregion
}