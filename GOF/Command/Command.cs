using System;


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

    abstract class Command
    {
        protected Reciver reciver;
        public Command(Reciver reciver) { this.reciver = reciver; }
        public abstract void Execute();
    }

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
