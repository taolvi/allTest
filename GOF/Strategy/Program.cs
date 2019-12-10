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
            Context context = new Context(new ConcreteStrategyA());
            context.ContextInterface();

            context = new Context(new ConcreteStrategyB());
            context.ContextInterface();

            Console.ReadLine();
        }
    }
    // 抽象算法
    abstract class Strategy
    {
        // 算法
        public abstract void AlgorithmInterface();
    }

    // 具体的算法或行为
    class ConcreteStrategyA : Strategy
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine("具体算法A实现");
        }
    }
    class ConcreteStrategyB : Strategy
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine("具体算法B实现");
        }
    }

    // 上下文
    class Context
    {
        Strategy strategy;
        public Context(Strategy strategy)
        {
            this.strategy = strategy;
        }
        // 上下文接口
        public void ContextInterface()
        {
            // 这里调用的是具体子类的实现方法
            strategy.AlgorithmInterface();
        }

    }


}
