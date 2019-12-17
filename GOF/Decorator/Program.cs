using System;

/*
 * 装饰模式
 * 动态的给一个对象添加一些额外的职责，就增加功能来说，装饰模式比
 * 生成子类更灵活
 * 
 * 大家都实现Operation方法，外层装饰器保存内层的类，在外层Operation
 * 方法合适的位置调用内层的Operation方法，实现增加新功能（装饰）
 */

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
