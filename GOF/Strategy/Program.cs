using System;

/*
 * 策略模式
 * 定义算法家族，分别封装，可以相互替换，不影响客户使用
 * 策略模式可以与简单工厂模式组合使用
 */
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
        // 选择具体使用的算法
        public Context(Strategy strategy) { this.strategy = strategy; }
        // 客户调用该函数而无需知道算法的细节
        public void ContextInterface()
        {
            // 这里调用的是具体子类的实现方法
            strategy.AlgorithmInterface();
        }

    }
}
