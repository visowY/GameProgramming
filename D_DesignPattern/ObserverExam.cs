using System;
using System.Collections.Generic;

namespace D_DesignPattern
{
    public class ObserverExam
    {
        public static void DoMain()
        {
            // 普通示例1：
            Game game = new TenGame("TenGame", "have a new game published ... ");

            game.AddObserver(new Subscriber("Learning Hard"));
            game.AddObserver(new Subscriber("Tommy"));

            game.Update();

            Console.WriteLine("================");
            // 普通示例2：
            
            Game2 tengame = new TenGame2("TenGame2" , "have a new game published ...");
            Subscriber2 s1 = new Subscriber2("Learning Hard");
            Subscriber2 s2 = new Subscriber2("Tom");
            
            
            tengame.AddObserver(s1.ReceiveAndPrint);
            tengame.AddObserver(s2.ReceiveAndPrint);
            
            tengame.Update();


        }
    }


    #region 观察者模式示例1：


    //订阅号抽象类
    public abstract class Game
    {
        private List<IObserver> observers = new List<IObserver>();

        public string Symbol { get; set; }
        public string Info { get; set; }

        public Game(string symbol, string info)
        {
            Symbol = symbol;
            Info = info;
        }

        # region 新增对订阅号列表的维护操作

        public void AddObserver(IObserver ob)
        {
            observers.Add(ob);
        }

        public void RemoveObserver(IObserver ob)
        {
            observers.Remove(ob);
        }

        #endregion

        public void Update()
        {
            observers.ForEach(_ => _.ReceiveAndPrint(this));
        }
    }

    // 订阅者接口
    public interface IObserver
    {
        void ReceiveAndPrint(Game game);
    }


    public class TenGame : Game
    {
        public TenGame(string symbol, string info) : base(symbol, info)
        {
        }
    }

    //订阅者类
    public class Subscriber : IObserver
    {
        public string Name { get; set; }

        public Subscriber(string name)
        {
            Name = name;
        }

        public void ReceiveAndPrint(Game game)
        {
            Console.WriteLine($"Notified {Name} of {game.Symbol}'s Info is {game.Info} ");
        }
    }



    #endregion

    # region csharp 中使用事件&委托简化观察者模式

    // 委托充当订阅者接口类
    public delegate void NotifyEventHandler(object sender);


    // 抽象订阅号类
    public class Game2
    {
        public NotifyEventHandler NotifyEvent;

        public string Symbol { get; set; }
        public string Info { get; set; }

        public Game2(string symbol, string info)
        {
            Symbol = symbol;
            Info = info;
        }

        # region 对订阅号列表的维护

        public void AddObserver(NotifyEventHandler ob)
        {
            NotifyEvent += ob;
        }

        public void RemoveObserver(NotifyEventHandler ob)
        {
            NotifyEvent -= ob;
        }

        # endregion

        public void Update()
        {
            NotifyEvent?.Invoke(this);
        }
    }

    //具体订阅号
    public class TenGame2 : Game2
    {
        public TenGame2(string symbol, string info) : base(symbol, info)
        {
            
        }
    }

    //具体订阅者类
    public class Subscriber2
    {
        public string Name { get; set; }

        public Subscriber2(string name)
        {
            this.Name = name;
        }

        public void ReceiveAndPrint(object obj)
        {
            var game = obj as TenGame2;
            if (game != null)
            {
                Console.WriteLine($"Notified {Name} of {game.Symbol}'s info is {game.Info}");
            }
        }
    }
    # endregion
}