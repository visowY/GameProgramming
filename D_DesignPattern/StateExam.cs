using System;

namespace D_DesignPattern
{
    public class StateExam
    {
        public static void DoMain()
        {
        }
    }


    # region 状态模式

    //抽象状态类
    public abstract class State
    {
        public Account Account { get; set; }
        public double Balance { get; set; }
        public double Interest { get; set; }
        public double LowerLimit { get; set; } //下限
        public double UpperLimit { get; set; }

        public abstract void Deposit(double amount);
        public abstract void Withdraw(double amount);
        public abstract void PayInterest(); //获取利息
    }


    //透支状态
    public class RedState : State
    {
        public RedState(State state)
        {
            Balance = state.Balance;
            Account = state.Account;
            Interest = 0.00;
            LowerLimit = -100.00;
            UpperLimit = 0.00;
        }

        public override void Deposit(double amount)
        {
            Balance += amount;
        }

        public override void Withdraw(double amount)
        {
            throw new System.NotImplementedException();
        }

        public override void PayInterest()
        {
            throw new System.NotImplementedException();
        }

        private void StateChangeCheck()
        {
            if (Balance > UpperLimit)
            {
                Account.State = new SilverState(this);
            }
        }
    }


    //标准账户
    public class SilverState : State
    {
        public SilverState(State state) : this(state.Balance, state.Account)
        {
        }

        public SilverState(double balance, Account account)
        {
            Balance = balance;
            Account = account;
            Interest = 0.00;
            LowerLimit = 0.00;
            UpperLimit = 1000.00;
        }


        public override void Deposit(double amount)
        {
            Balance += amount;
            StateChangeCheck();
        }

        public override void Withdraw(double amount)
        {
            Balance -= amount;
            StateChangeCheck();
        }

        public override void PayInterest()
        {
            Balance += Interest * Balance;
            StateChangeCheck();
        }

        private void StateChangeCheck()
        {
            if (Balance < LowerLimit)
            {
                Account.State = new RedState(this);
            }
            else if (Balance > UpperLimit)
            {
                Account.State = new GoldState(this);
            }
        }
    }


    public class GoldState : State
    {
        public GoldState(State state)
        {
            Balance = state.Balance;
            Account = state.Account;
            Interest = 0.05;
            LowerLimit = 1000.00;
            UpperLimit = 10000000.00;
        }

        public override void Deposit(double amount)
        {
            Balance += amount;
            StateChangeCheck();
        }

        public override void Withdraw(double amount)
        {
            Balance -= amount;
            StateChangeCheck();
        }

        public override void PayInterest()
        {
            Balance += Interest * Balance;
            StateChangeCheck();
        }

        private void StateChangeCheck()
        {
            if (Balance < 0.0)
            {
                Account.State = new RedState(this);
            }
            else if (Balance < LowerLimit)
            {
                Account.State = new SilverState(this);
            }
        }
    }


    public class Account
    {
        public State State { get ; set; }
        public string Owner { get ; set; }

        public Account(string owner)
        {
            Owner = owner;
            State = new SilverState(0.0, this);
        }

        public double Balance
        {
            get => State.Balance;
        }

        public void Deposit(double amount)
        {
            State.Deposit(amount);
            Console.WriteLine($"存款金额为 {amount:C}");
            Console.WriteLine($"账户余额为 {Balance:C}");
            Console.WriteLine($"账户状态为 {State.GetType().Name}");
            Console.WriteLine();
        }

        public void WithDraw(double amount)
        {
            State.Withdraw(amount);
            Console.WriteLine($"取款金额为 {amount:C}");
            Console.WriteLine($"账户余额为 {Balance:C}");
            Console.WriteLine($"账户状态为 {State.GetType().Name}");
        }

        public void PayInterest()
        {
            State.PayInterest();
            Console.WriteLine("Interest Paid --- ");
            Console.WriteLine("账户余额为 =:{0:C}", this.Balance);
            Console.WriteLine("账户状态为: {0}", this.State.GetType().Name);
            Console.WriteLine();
        }
    }

    # endregion
}