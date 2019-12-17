using System;

// 简单工厂模式
namespace GoF
{
    class Program
    {
        static void Main(string[] args)
        {
            Operation oper = new Operation();
            oper = OperationFactory.createOperation("+");
            oper.NumberA = 1;
            oper.NumberB = 255;
            double result = oper.GetResult();
            Console.WriteLine("{0}", result);
            Console.ReadLine();
        }
    }
    // 操作的父类
    public class Operation
    {
        protected double numberA = 0;
        protected double numberB = 0;
        public double NumberA
        {
            get { return numberA; }
            set { numberA = value; }
        }
        public double NumberB
        {
            get { return numberB; }
            set { numberB = value; }
        }
        public virtual double GetResult()
        {
            double result = 0;
            return result;
        }
    }

    // 具体操作类
    public class OperationAdd:Operation
    {
        public override double GetResult()
        {
            return numberA + numberB;
        }
    }

    public class OperationSub : Operation
    {
        public override double GetResult()
        {
            return numberA - numberB;
        }
    }
// 操作工厂
    class OperationFactory
    {
        public static Operation createOperation(string s)
        {
            switch (s)
            {
                case "+":
                    return new OperationAdd();
                case "-":
                    return new OperationSub();
                default:
                    return null;
            }
        }
    }

}
