using System;

/*
 * 命令模式
 * 将一个请求封装为一个对象，从而使你可用不同的请求对客户进行参数化；
 * 对请求排队或记录请求日志，以及支持可撤销的操作
 */
namespace GoF
{
    class Program
    {
        static void Main(string[] args)
        {
            Invoker invoker = new Invoker();
            Reciver reciver = new Reciver();
            invoker.SetCommand(new ConcreteCommand(reciver));

            invoker.ExxcuteCommand();

            Console.Read();
        }
    }

    // 命令父类
    abstract class Command
    {
        protected Reciver reciver;
        public Command(Reciver reciver) { this.reciver = reciver; }
        public abstract void Execute();
    }

    // 具体的命令， 每个命令都有一个具体的执行者
    class ConcreteCommand : Command
    {
        public ConcreteCommand(Reciver reciver) : base(reciver) { }
        public override void Execute() { reciver.Action(); }
    }

    // 命令接收（执行）
    class Reciver
    {
        public void Action() { Console.WriteLine("执行命令"); }
    }

    // 命令发起者
    class Invoker
    {
        private Command command;
        public void SetCommand(Command command) { this.command = command; }
        public void ExxcuteCommand() { command.Execute(); }
    }
}
