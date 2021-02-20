using System;

namespace D_DesignPattern
{

    public class CommandExam
    {
        public static void DoMain()
        {
            Receiver r =new Receiver();
            Command c = new ConcreteCommandA(r);
            Invoke i = new Invoke(c);
            
            i.ExecuteCommand();
        }
    }


    #region 命令模式


    public abstract class Command
    {
        protected Receiver _receiver;

        public Command(Receiver receiver)
        {
            _receiver = receiver;
        }

        public abstract void Action();
    }


    public class ConcreteCommandA : Command
    {
        public ConcreteCommandA(Receiver receiver) : base(receiver)
        {
        }

        public override void Action()
        {
            _receiver.Run1000Meters();
        }
    }


    public class Invoke
    {
        public Command _command;

        public Invoke(Command command)
        {
            _command = command;
        }

        public void ExecuteCommand()
        {
            _command.Action();
        }
    }

    public class Receiver
    {
        public void Run1000Meters()
        {
            Console.WriteLine("跑100m");
        }
    }
    
    #endregion 
}