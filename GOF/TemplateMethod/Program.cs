using System;

/*
 * 模版方法模式
 * 定义一个操作中的算法的骨架，而将一些步骤延迟到子类中。模板方法使得子类
 * 可以不改变一个算法的结构即可重定义该算法的某些特定步骤
 */
namespace GoF
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractClass c;
            c = new ConcreteClassA();
            c.TemplateMethod();

            c = new ConcreteClassB();
            c.TemplateMethod();

            Console.Read();
        }
    }

    // 抽象模板，定义一个算法实现的骨架，具体实现方法由子类决定
    abstract class AbstractClass
    {
        // 具体算法的内部细节，放到子类去实现
        protected abstract void PrimitiveOperation1();
        protected abstract void PrimitiveOperation2();
       
        // 算法骨架
        public void TemplateMethod()
        {
            PrimitiveOperation1();
            PrimitiveOperation2();
            Console.WriteLine("");
        }
    }

    // 具体子类的实现方法
    class ConcreteClassA : AbstractClass
    {
        protected override void PrimitiveOperation1()
        {
            Console.WriteLine("具体类A方法1实现");
        }
        protected override void PrimitiveOperation2()
        {
            Console.WriteLine("具体类A方法2实现");
        }
    }
    class ConcreteClassB : AbstractClass
    {
        protected override void PrimitiveOperation1()
        {
            Console.WriteLine("具体类B方法1的实现");
        }
        protected override void PrimitiveOperation2()
        {
            Console.WriteLine("具体类B方法2的实现");
        }
    }
}
