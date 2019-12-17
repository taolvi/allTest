using System;
using System.Collections.Generic;

/*
 * 建造者模式
 * 将一个复杂对象的构建与它的表示分离，使得同样的构建过程可以创建不同的表示。
 * 
 * 指挥者负责整体的把控，传给指挥者的builder负责具体细节的实现。builder不同，结果也不同。
 */

namespace GOF
{
    class Program
    {
        static void Main(string[] args)
        {
            Director director = new Director();
            Builder builder1 = new ConcreteBuilder1();
            Builder builder2 = new ConcreteBuilder2();

            director.Construct(builder1);
            Product p1 = builder1.GetResult();
            p1.Show();

            director.Construct(builder2);
            Product p2 = builder2.GetResult();
            p2.Show();

            Console.Read();
        }
    }

    class Product
    {
        IList<string> parts = new List<string>();
        public void Add(string part)
        {
            parts.Add(part);
        }
        public void Show()
        {
            Console.WriteLine("\n产品 创建-----");
            foreach (string part in parts)
            {
                Console.WriteLine(part);
            }
        }
    }

    // 抽象建造者类
    abstract class Builder
    {
        public abstract void BuildPartA();
        public abstract void BuildPartB();
        public abstract Product GetResult();
    }

    // 具体建造者类 1
    class ConcreteBuilder1 : Builder
    {
        private Product product = new Product();

        public override void BuildPartA()
        {
            product.Add("part---A");
        }
        public override void BuildPartB()
        {
            product.Add("part---B");
        }
        public override Product GetResult()
        {
            return product;
        }
    }

    // 具体建造者类 2
    class ConcreteBuilder2 : Builder
    {
        private Product product = new Product();

        public override void BuildPartA()
        {
            product.Add("part---X");
        }
        public override void BuildPartB()
        {
            product.Add("part---Y");
        }
        public override Product GetResult()
        {
            return product;
        }
    }

    // 指挥者类
    class Director
    {
        public void Construct(Builder b)
        {
            b.BuildPartA();
            b.BuildPartB();
        }
    }

}
