using System;
using System.Collections.Generic;

/*
 * 观察者模式
 * 定义一种一对多的依赖关系，让多个观察者对象同时监听某一个主题对象，
 * 这个主题对象在状态发生变化时，会通知所有观察者对象，使他们能够更新自己
 * 
 * 缺点：通知者与观察者需要知道彼此
 * 在C#中可以利用事件与委托机制来实现
 */

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

    // 抽象通知者 
    abstract class Subject
    {
        private IList<Observer> observers = new List<Observer>();
        // 增加观察者
        public void Attach(Observer o) { observers.Add(o); }
        // 移除观察者
        public void Detach(Observer o) { observers.Remove(o); }
        // 通知每一个观察者
        public void Notify()
        {
            foreach (Observer o in observers)
            {
                o.Update();
            }
        }  
    }

    // 实际通知者
    class ConcreteSubject : Subject
    {
        private string subjectState;
        public string SubjectState
        {
            get { return subjectState; }
            set { subjectState = value; }
        }
    }

    // 抽象观察者，每一个观察者都要实现Update方法
    abstract class Observer
    {
        public abstract void Update();
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
