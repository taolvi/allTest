using System;
using System.Collections.Generic;

/*
 * 访问者模式
 * 表示一个作用于某对象数据结构中的各个元素的操作，它使你可以在
 * 不会改变各个元素的类的前提下定义作用于这些元素的新操作
 * 缺点：需要维护ObjectStructure类
 */

namespace GoF
{
    class Program
    {
        static void Main(string[] args)
        {
            ObjectStructure o = new ObjectStructure();
            o.Attach(new ConcreteElementA());
            o.Attach(new ConcreteElementB());
            ConcreteVisitor1 v1 = new ConcreteVisitor1();
            o.Accept(v1);

            Console.Read();
        }
    }
    // 访问者父类， 为需要被访问的所有元素提供visit方法
    abstract class Visitor
    {
        public abstract void VisitConcreteElementA(ConcreteElementA ceA);
        public abstract void VisitConcreteElementB(ConcreteElementB ceB);
    }

    // 具体的访问者，对被访问者实现一些操作
    // 具体的访问者可以有多个，从而实现不同的算法
    class ConcreteVisitor1 : Visitor
    {
        public override void VisitConcreteElementA(ConcreteElementA ceA)
        {
            Console.WriteLine("{0}被{1}访问", ceA.GetType().Name, this.GetType().Name);
        }

        public override void VisitConcreteElementB(ConcreteElementB ceB)
        {
            Console.WriteLine("{0}被{1}访问", ceB.GetType().Name, this.GetType().Name);
        }
    }

    // 可被访问的元素父类，提供Accept方法，接受访问者
    abstract class Element
    {
        public abstract void Accept(Visitor visitor);
    }
    class ConcreteElementA : Element
    {
        public override void Accept(Visitor visitor)
        {
            visitor.VisitConcreteElementA(this);
        }
    }
    class ConcreteElementB : Element
    {
        public override void Accept(Visitor visitor)
        {
            visitor.VisitConcreteElementB(this);
        }
    }
    // 可以枚举元素（Element），提供接口供外部的访问者访问
    class ObjectStructure
    {
        private IList<Element> elements = new List<Element>();
        public void Attach(Element element)
        {
            elements.Add(element);
        }
        public void Detach(Element element)
        {
            elements.Remove(element);
        }
        public void Accept(Visitor visitor)
        {
            foreach (Element element in elements)
            {
                element.Accept(visitor);
            }
        }
    }
}
