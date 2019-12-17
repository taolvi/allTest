using System;
using System.Collections.Generic;

/*
 * 解释器模式
 * 给定一个语言，定义它的文法的一种表示，并定义一个解释器，
 * 这个解释器使用该表示来语言中的句子。
 */
namespace Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();
            IList <AbstractExpression> list = new List<AbstractExpression>();
            list.Add(new TerminalExpression());
            list.Add(new NontermalExpression());
            list.Add(new TerminalExpression());

            foreach (AbstractExpression ae in list)
            {
                ae.Interpret(context);
            }
            Console.Read();
        }
    }
    // 包含解释器之外的一些信息
    class Context
    {
        private string input;
        public string Input
        {
            get { return input; }
            set { input = value; }
        }

        private string output;
        public string Output
        {
            get { return output; }
            set { output = value; }
        }
    }

    // 抽象 表达式
    abstract class AbstractExpression
    {
        // 抽象解释
        public abstract void Interpret(Context context);
    }

    // 终结符表达式
    class TerminalExpression : AbstractExpression
    {
        public override void Interpret(Context context)
        {
            Console.WriteLine("终端解释器");
        }
    }

    // 非终结符表达式
    class NontermalExpression : AbstractExpression
    {
        public override void Interpret(Context context)
        {
            Console.WriteLine("非终端解释器");
        }
    }
}
