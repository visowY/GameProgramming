
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

```
