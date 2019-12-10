using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// 模版方法模式
namespace TemplateMethod
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

    abstract class AbstractClass
    {
        protected abstract void PrimitiveOperation1();// 一些抽象行为，放到子类去实现
        protected abstract void PrimitiveOperation2();
        public void TemplateMethod()
        {
            PrimitiveOperation1();
            PrimitiveOperation2();
            Console.WriteLine("");
        }
    }

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
