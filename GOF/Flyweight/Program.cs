using System;
using System.Collections;

/*
 * 享元模式
 * 运用共享技术有效的支持大量细粒度的对象。
 */
namespace GoF
{
    class Program
    {
        static void Main(string[] args)
        {
            int extrinsicstate = 22;
            FlyweightFactory ff = new FlyweightFactory();

            Flyweight fx = ff.GetFlyweight("X");
            fx.Operation(extrinsicstate--);

            Flyweight fy = ff.GetFlyweight("Y");
            fy.Operation(extrinsicstate--);

            Flyweight fz = ff.GetFlyweight("Z");
            fz.Operation(extrinsicstate--);

            Flyweight uf = new UnsharedConcreteFlyweight();
            uf.Operation(extrinsicstate--);

            Console.Read();
        }
    }
    abstract class Flyweight
    {
        public abstract void Operation(int extrinsicstate);
    }
    class ConcreteFlyweight : Flyweight
    {
        public override void Operation(int extrinsicstate)
        {
            Console.WriteLine("具体Flyweight:"+extrinsicstate);
        }
    }

    class UnsharedConcreteFlyweight : Flyweight
    {
        public override void Operation(int extrinsicstate)
        {
            Console.WriteLine("不共享的具体Flyweight:" + extrinsicstate);
        }
    }

    class FlyweightFactory
    {
        private Hashtable flyweights = new Hashtable();

        public FlyweightFactory()
        {
            flyweights.Add("X", new ConcreteFlyweight());   // 初始化工厂类时先加入三个类
            flyweights.Add("Y", new ConcreteFlyweight());   // 这三个类可以不同的需要共享的类
            flyweights.Add("Z", new ConcreteFlyweight());
        }

        public Flyweight GetFlyweight(string key)
        {
            return ((Flyweight)flyweights[key]);
        }
    }
}
