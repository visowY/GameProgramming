using System;

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