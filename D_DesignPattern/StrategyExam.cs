using System;

namespace D_DesignPattern
{
    public class StrategyExam
    {
        public static void DoMain()
        {
            // 个人所得税方式
            InterestOperation operation = new InterestOperation(new PersonalTaxStrategy());
            Console.WriteLine("个人支付的税为：{0}", operation.GetTax(5000.00));

            // 企业所得税
            operation = new InterestOperation(new EnterpriseTaxStrategy());
            Console.WriteLine("企业支付的税为：{0}", operation.GetTax(50000.00));
        }
    }

    #region 策略模式
    public interface ITaxStrategy
    {
        double CalculateTax(double income);
    }

    public class PersonalTaxStrategy : ITaxStrategy
    {
        public double CalculateTax(double income)
        {
            return income * 0.12;
        }
    }

    public class EnterpriseTaxStrategy : ITaxStrategy
    {
        public double CalculateTax(double income)
        {
            return (income - 3500) > 0 ? (income - 3500) * 0.045 : 0.0;
        }
    }

    public class InterestOperation
    {
        private ITaxStrategy _strategy;

        public InterestOperation(ITaxStrategy strategy)
        {
            _strategy = strategy;
        }

        public double GetTax(double income)
        {
            return _strategy.CalculateTax(income);
        }
    }
    #endregion
}