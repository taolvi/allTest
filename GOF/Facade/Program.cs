using System;

/*
 * 外观模式
 * 为子系统中的一组接口提供一个一致的界面，此模式定义了一个高层接口，
 * 这个接口使得这一子系统更加容易实现
 * 
 * 将一些具体的实现细节隐藏起来
 */
namespace GoF
{
    class Program
    {
        static void Main(string[] args)
        {
            Facade facade = new Facade();

            facade.MethodA();
            facade.MethodB();

            Console.Read();
        }
    }
    
    // 外观类
    class Facade
    {
        SubSystemOne one;
        SubSystemTwo two;
        SubsystemThree three;

        public Facade()
        {
            one = new SubSystemOne();
            two = new SubSystemTwo();
            three = new SubsystemThree();
        }

        public void MethodA()
        {
            Console.WriteLine("\n方法组A() ---");
            one.MethodOne();
            two.MethodTwo();
        }
        public void MethodB()
        {
            Console.WriteLine("\n方法组B() --- ");
            two.MethodTwo();
            three.MethodThree();
        }
    }
    // 三个子系统
    class SubSystemOne
    {
        public void MethodOne()
        {
            Console.WriteLine("子系统方法一");
        }
    }
    class SubSystemTwo
    {
        public void MethodTwo()
        {
            Console.WriteLine("子系统方法二");
        }
    }
    class SubsystemThree
    {
        public void MethodThree()
        {
            Console.WriteLine("子系统方法三");
        }
    }
}
