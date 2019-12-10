using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoF
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcreteSubject subject = new ConcreteSubject();

            ConcreteObserver observerTom = new ConcreteObserver(subject, "Tom");
            subject.Attach(observerTom);

            ConcreteObserver observerTim = new ConcreteObserver(subject, "Tim");
            subject.Attach(observerTim);

            subject.SubjectState = "XXXX";

            subject.Notify();
            Console.Read();

        }
    }

    // 抽象被观察者 
    abstract class Subject
    {
        private IList<Observer> observers = new List<Observer>();

        // 增加观察者
        public void Attach(Observer o)
        {
            observers.Add(o);
        }

        // 移除观察者
        public void Detach(Observer o)
        {
            observers.Remove(o);
        }

        // 通知
        public void Notify()
        {
            foreach (Observer o in observers)
            {
                o.Update();
            }
        }
        
    }

    abstract class Observer
    {
        public abstract void Update();
    }

    // 实际被观察者
    class ConcreteSubject : Subject
    {
        private string subjectState;
        public string SubjectState
        {
            get { return subjectState; }
            set { subjectState = value; }
        }
    }

    // 实际观察者
    class ConcreteObserver : Observer
    {
        private string name;
        private string observerState;
        private ConcreteSubject subject;

        public ConcreteObserver(ConcreteSubject subject, string name)
        {
            this.subject = subject;
            this.name = name;
        }

        public override void Update()
        {
            observerState = subject.SubjectState;
            Console.WriteLine("观察者{0}的新状态是{1}", name, observerState);
        }
    }
}
