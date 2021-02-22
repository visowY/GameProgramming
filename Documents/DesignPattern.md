
## 1. 工厂模式

## 2. 组合模式

## 3. 代理模式

## 4. 装饰器模式

## 5. 职责链模式

## 6. 单例模式

## 7. 适配器模式

* 定义：把一个类的接口变换成客户端所期待的另一种接口，从而使得原本接口不匹配无法一起工作的两个类能够一起工作。

* 分类：
    1. 类适配器模式
    2. 对象适配器模式

* 使用场景
    1. 系统需要复用现有的类，而该类的接口不符合系统的需求。
    2. 想要建立一个可重复使用的类，用于一些彼此之间没有太大关联的类，包括一些可能在将来引进的类一起工作。
    3. 对象适配器模式，在设计里需要该比那多个已经有的子类的接口。使用类的适配器模式，需要针对每一个子类做适配器。

* 代码示例
```csharp

```

## 8. 桥接模式

* 结构型设计模式

* 定义：将抽象部分与实现部分脱耦，使他们可以独立变化（链接了2个维度的东西，而且两个维度又都有强烈的变化).将一个事物中多个维度变化分离。

* 结构：
    1. Abstraction : 定义抽象类的接口，维护一个只想Implementor类型对象的指针。
    2. RefinedAbstraction : 扩充由Abstranction定义的接口。
    3. Implementor : 定义实现类的接口（Implementor接口提供基本操作，Abstraction定义基于基本操作的较高层次操作）
    4. ConcreteImplementorA/B : 实现Implementor接口并定义它的具体实现。

* 理解
    1. 分离抽象&行为

* 代码示例

```csharp
```

## 9. 备忘录模式

* 定义： 在不破坏封装性的前提下，捕获一个对象的内部状态，并在该对象之外保存这个状态。这样以后就可以将该对象恢复到原先保存的状态。

* 结构：
    1. Memento:  为创建对象的各个部件指定抽象接口。
    2. Originator: 创建一个备忘录，记录当前时刻的内部状态。 使用备忘录恢复内部状态。
    3. Caretaker: 负责保存备忘录。 不能对备忘录的内容进行操作或者检查。

* 在备忘录模式中`Caretaker`负责把`Originator`创建的`Memento`进行备份，当需要的时候，`Originator`可以再使用`Caretaker`中保存的`Memento`进行恢复。`Originator`中的所有状态呗恢复到备份操作之前的状态。


* 示例代码
```csharp
namespace D_DesignPattern
{
    public class MementoPattern
    {
        public static void DoMain()
        {
            
            Originator o =new Originator();

            o.State = "On";
            
            Caretaker c = new Caretaker();
            c.Memento = o.CreateMemento();

            o.State = "Off";
            
            o.SetMemento(c.Memento);


        }
    }
    
    #region 备忘录模式
    public class Memento
    {
        private string _state;

        public Memento(string state)
        {
            _state = state;
        }

        public string State => _state;
    }

    public class Originator
    {
        private string _state;

        public string State
        {
            get => _state;
            set
            {
                _state = value;
                Console.WriteLine("State = " + _state);
            }
        }

        public Memento CreateMemento()
        {
            return new Memento(_state);
        }

        public void SetMemento(Memento memento)
        {
            Console.WriteLine("Restoring state...");
            State = memento.State;
        }
    }

    public class Caretaker
    {
        private Memento _memento;
        
        public Memento Memento
        {
            get => _memento;
            set => _memento = value;
        }
    }
    #endregion 
}
```

* 适用情形：
    1. 必须保存一个对象在某一个时刻的部分状态，这样以后需要时才能恢复到先前的状态。
    2. 适用于由原发器管理，却又必须存储在原发器之外的信息。
    3. 需要考虑对象状态的效率问题，如果对象开销比较大，采用某种增量模式来改进Memento模式。


## 10. 命令模式

* 定义：命令模式的目的是接触命令发出者和接受者之间的紧密耦合关系，使二者相对独立，有利于程序的并行开发和代码的维护。命令模式的核心思想是将请求封装为一个对象，将其作为命令发起者和接受者的中介，二抽象出来的命令对像又使得能够对一系列请求进行操作，如对请求进行排队，记录请求日志以及支持可撤销的操作等。

* 类型： 行为行模式

* 结构：
    1. Command: 命令抽象类，声明一个执行操作的接口Execute,该抽象类不实现这个接口，所有的具体命令都继承自命令抽象类。
    2. ConcreteCommand: 定义一个接受者对象对象&动作之间的绑定 //  调用Receiver的操作，实现Execute方法。
    3. Invoker: 命令的接受者，将命令请求传递给相应的命令对象，每个ConcreteCommand都是一个Invoker的成员。
    4. Receiver: 命令的接受者，知道如何实施&执行一个请求相关的操作
    5. Client: 客户单程序，创建一个具体的命令对象并设定它的接受者。
* 注意：
> `Command`对象作为`Invoker`的一个属性，当点击事件发生时，Invoker调用方法`Invoke()`将请求发送给`ConcreteComand`,再由`ConcreteCommand`调用`Execute()`将请求发送给`Receiver`,`Client`负责创建所有的角色，并设定`Command`与`Invoker`和`Receiverd`之间的绑定方式。

* 示例代码
```csharp
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
```

* 优点：
    1. 命令模式使得新的命令很容易被加入到系统中
    2. 可以设计一个命令队列来实现对请求的`Undo`和`Redo`操作。
    3. 可以较容易的将命令写入日志。
    4. 可以把命令聚合在一起，合成为合成命令。合成命令合成模式的应用。

## 11. 享元模式

* 定义：运用共享技术有效地支持大量细粒度的对象。享元模式可以避免大量相似类的开销，在软件开发过程中如果需要生成大量细粒度的类实例来表示数据，如果这些实例除了几个参数外基本上都是相同的，这时候就可以使用享元模式来大幅度减少需要实例化类的数量。如果能把这些参数（指的是这些类实例不同的参数）移到实例类外面，在方法调用时将他们传递进来，这样就可以通过共享大幅度减少单个实例的数目（这也是享元模式实现的要领），然而我们把类实例外面的参数称为享元对象的外部状态，把在享元对象内部状态与外部状态的定义为：

    1. 内部状态：在享元对象的内部并且不会随着环境改变而改变的共享部分

    2. 外部状态：随着环境改变而改变，不可以共享的状态。

* 代码示例：
```csharp
namespace D_DesignPattern
{
    public class FlyweightExam
    {
        
    }
    
    # region 享元模式

    public abstract class Flyweight
    {
        public abstract void Operation(int extrinsicstate);
    }


    public class FlyweightFactory
    {
        public Dictionary<string , Flyweight> _dictFlyweights = new Dictionary<string, Flyweight>();

        public FlyweightFactory()
        {
            _dictFlyweights.Add("A" , new ConcreteFlyweight("A"));
            _dictFlyweights.Add("B" ,  new ConcreteFlyweight("B"));
            _dictFlyweights.Add("C" , new ConcreteFlyweight("C"));
        }

        public Flyweight GetFlyweight(string key)
        {
            Flyweight temp;
            if (!_dictFlyweights.TryGetValue(key, out temp))
            {
                Console.WriteLine("驻留池中不存在字符串" + key);
                return null;
            }
            return temp;
        }
    }

    public class ConcreteFlyweight : Flyweight
    {
        public string _instrinsicstate;

        public ConcreteFlyweight(string innerstate)
        {
            _instrinsicstate = innerstate;
        }

        public override void Operation(int extrinsicstate)
        {
            Console.WriteLine($"具体的实现类： intrinsicstate: {_instrinsicstate}, extrinsicstate; {extrinsicstate}");
        }
    }
    # endregion 
}
```
* 在下面所有条件都满足时，可以考虑使用享元模式：

    1. 一个系统中有大量的对象；
    2. 这些对象耗费大量的内存；
    3. 这些对象中的状态大部分都可以被外部化
    4. 这些对象可以按照内部状态分成很多的组，当把外部对象从对象中剔除时，每一个组都可以仅用一个对象代替
    5. 软件系统不依赖这些对象的身份，

* 注意：
    满足上面的条件的系统可以使用享元模式。但是使用享元模式需要额外维护一个记录子系统记录已有的所有享元的表，而这也需要耗费资源，所以，应当在有足够多的享元实例可共享时才值得使用享元模式。

* 总结：
    享元模式主要是用来解决由于大量的细粒度对象所造成的内存开销问题，它在实际开发中并不常用，可以作为底层的提升性能的一种手段。

## 12.中介者模式

* 定义：中介者模式，定义了一个中介对象来封装一系列对象之间的交互关系。中介者使各个对象之间不需要显式地相互引用，从而是耦合性降低，而且可以独立改变它们之间的交互行为。

* 代码示例：

```csharp
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
```

* 总结
> 中介者模式，定义了一个中介对象来封装系列对象之间的交互。中介者使各个对象不需要显式地相互引用，从而使其耦合性降低，而且可以独立地改变它们之间的交互。中介者模式一般应用于一组定义良好的对象之间需要进行通信的场合以及想定制一个分布在多个类中的行为，而又不想生成太多的子类的情形下。

> 新增加一个相同类时，不得不去修改抽象中介者类和具体中介者类，此时可以使用观察者模式和状态模式来解决这个问题。

## 13. 观察者模式

* 定义：观察者模式定义了一种一对多的依赖关系，让多个观察者对象同时监听一个主题对象，这个主题对象在状态发生改变时，会通知所有观察者对象，使它们能够自动更新自己的行为。

* 角色分类
    1. Subject: 抽象主题角色，把所有观察者对象的引用保存在一个列表中，并提供增加和删除观察者对象的操作，（抽象类/接口）
    2. Observer: 抽象观察者角色， 为所有具体观察者定义接口，在得到主题通知时更新自己（抽象类/接口）
    3. ConcreteSubject: 具体主题角色，实现抽象主题
    4. ConcreteObserver: 实现抽象观察者角色所要求的接口。

* 代码示例1
```csharp
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
```
* 代码示例2 
```csharp
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
```

* 总结：
>到这里，观察者模式的分享就介绍了。观察者模式定义了一种一对多的依赖关系，让多个观察者对象可以同时监听某一个主题对象，这个主题对象在发生状态变化时，会通知所有观察者对象，使它们能够自动更新自己，解决的是“当一个对象的改变需要同时改变多个其他对象”的问题

## 14.状态模式

* 定义：
    1. 状态模式将每种状态对应的行为抽象出来成为单独新的对象，这样状态的变化不再依赖于对象内部的行为。
    2. 状态模式——允许一个对象在其内部状态改变时自动改变其行为，对象看起来就像是改变了它的类。
* 示例代码：

```csharp
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
        public State State { get; set; }
        public string Owner { get; set; }

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
```