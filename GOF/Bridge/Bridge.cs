using System;

/* 桥接模式
 * 实现系统可能有多角度分类，每一种分类都有可能变化，
 * 将多角度分离出来独立变化
 * 
 * 早期的手机系统不同，但都有通讯录等功能。将手机品牌跟手机软件独立出来。
 * 手机品牌与手机软件是聚合关系
 * 通讯录的实现可能有多种方法，对应每个特定的手机品牌可以调用特定的通讯录实现方法。
 * 
 */
namespace GoF
{
    class Program
    {
        static void Main(string[] args)
        {
            RefinedAbstraction ra = new RefinedAbstraction();
            ra.SetImplementor(new ConcreteImplementorA());
            ra.Operation();

            ra.SetImplementor(new ConcreteImplementorB());
            ra.Operation();

            Console.Read();
        }
    }
    // 具体方法的实现（独立）
    abstract class Implementor
    {
        public abstract void Operation();
    }

    class ConcreteImplementorA : Implementor
    {
        public override void Operation()
        {
            Console.WriteLine("具体实现A的操作");
        }
    }
    class ConcreteImplementorB : Implementor
    {
        public override void Operation()
        {
            Console.WriteLine("具体实现B的操作");
        }
    }

    // 方法的调用
    // Abstract
    class Abstraction
    {
        protected Implementor implementer;

        public void SetImplementor(Implementor implementer)
        {
            this.implementer = implementer;
        }

        public virtual void Operation()
        {
            implementer.Operation();
        } 
    }

    class RefinedAbstraction : Abstraction
    {
        public override void Operation()
        {
            implementer.Operation();
        }
    }
}
