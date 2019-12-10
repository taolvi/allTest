using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// 原型模式
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
    // 原型类
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
