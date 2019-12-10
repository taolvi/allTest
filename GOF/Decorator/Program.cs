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
            ConcreteComponent component = new ConcreteComponent();
            ConcreteDecoratorA d1 = new ConcreteDecoratorA();
            ConcreteDecoratorB d2 = new ConcreteDecoratorB();

            d1.SetComponent(component);
            d2.SetComponent(d1);
            d2.Operation();
            Console.ReadLine();
        }
    }

    abstract class Component
    {
        public abstract void Operation();
    }
    // 具体的对象，可以给他添加职责
    class ConcreteComponent:Component
    {
        public override void Operation()
        {
            Console.WriteLine("具体对象的操作");
        }
    }
    // 装饰类
    abstract class Decorator : Component
    {
        protected Component component;
        public void SetComponent(Component component)
        {
            this.component = component;
        }

        public override void Operation()
        {
            if(component != null)
            {
                component.Operation();
            }
        }
    }
    // 具体的装饰类
    class ConcreteDecoratorA : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            // 子类的操作
            Console.WriteLine("装饰器A的操作");
        }
    }

    class ConcreteDecoratorB : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            // 子类操作
            Console.WriteLine("装饰器B的操作");
        }
    }

}
