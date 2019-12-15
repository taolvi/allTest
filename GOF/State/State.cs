using System;

/*
 * 状态模式
 * 当一个对象的内在状态改变时允许改变其行为，
 * 这个对象看起来像是改变了其类。
 * 
 * 例子中调用Request则设置为下一状态
 */

namespace GOF
{
    class Program
    {
        static void Main(string[] args)
        {
            Context c = new Context(new ConcreteStateA());

            c.Request();
            c.Request();
            c.Request();
            c.Request();

            Console.ReadLine();
        }
    }

    // 抽象状态类
    abstract class State
    {
        public abstract void Handle(Context context);
    }
    // 具体状态类
    class ConcreteStateA : State
    {
        public override void Handle(Context context)
        {
            context.State = new ConcreteStateB();
        }
    }
    class ConcreteStateB : State
    {
        public override void Handle(Context context)
        {
            context.State = new ConcreteStateA();
        }
    }
    // 维护一个 具体状态类，通过改变它内部的状态类改变它的行为
    class Context
    {
        private State state;
        public Context(State state)
        {
            this.state = state;
        }
        public State State
        {
            get { return state; }
            set { state = value; Console.WriteLine("当前状态：" + state.GetType().Name); }
        }
        public void Request()
        {
            state.Handle(this);
        }
    }
}
