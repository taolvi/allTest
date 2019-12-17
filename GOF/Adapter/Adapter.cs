using System;

/*
 * 适配器模式
 * 将一个类的接口转换为客户希望的另外一个接口。Adapter模式使得
 * 原本由于接口不兼容而不能一起工作的那些类可以一起工作。
 */

namespace GoF
{
    class Progrom
    {
        static void Main(string[] args)
        {
            Target t = new Adapter();
            t.Request();

            Console.ReadLine();
        }
    }
    // Target
    class Target
    {
        public virtual void Request()
        {
            Console.WriteLine("期望的实现方式");
        }
    }

    // Adaptee
    class Adaptee
    {
        public void SpecialRequest()
        {
            Console.WriteLine("特殊请求");
        }
    }

    // Adapter
    class Adapter:Target
    {
        private Adaptee adaptee = new Adaptee();

        public override void Request()
        {
            adaptee.SpecialRequest();
        }
    }
}
