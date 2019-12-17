using System;

/*
 * 原型模式
 * 用原型实例指定创建对象的种类，并且通过拷贝这些原型创建新的对象。
 * 重点：实现Clone方法
 */
namespace GoF
{
    class Program
    {        
        static void Main(string[] args)
        {
            ConcretePrototype1 p1 = new ConcretePrototype1("I");
            ConcretePrototype1 c1 = (ConcretePrototype1)p1.Clone();

            Console.WriteLine("p1 Id is {0}, c1 Id is {1} .",p1.Id, c1.Id);

            Console.Read();
        }
    }
    // 抽象原型类
    abstract class Prototype
    {
        private string id;
        public string Id
        {
            get { return this.id; }
        }
        public Prototype(string id)
        {
            this.id = id;
        }
        public abstract Prototype Clone();
    }
    // 具体原型类
    class ConcretePrototype1 : Prototype
    {
        public ConcretePrototype1(string id) : base(id)
        { }

        public override Prototype Clone()
        {
            return (Prototype)this.MemberwiseClone();
        }
    }
}
