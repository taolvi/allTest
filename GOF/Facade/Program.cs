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
