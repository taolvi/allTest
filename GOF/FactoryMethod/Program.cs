using System;

// 工厂方法模式
/*
 * 定义一个用于创建对象的接口，让子类决定实例化哪一个类。
 * 工厂方法使一个类的实例化延迟到子类
 * 
 * 对于简单工厂模式：工厂类中必须包含必要的判断逻辑，客户端减少了依赖
 */
namespace GoF
{
    class Program
    {
        static void Main(string[] args)
        {
            IFactory f = new UnderGraduateFactory();
            LeiFeng student = f.CreateLeiFeng();

            student.Sweep();
            student.Wash();
            student.BuyRice();

            Console.ReadLine();
        }
    }

    // 雷锋
    class LeiFeng
    {
        public void Sweep()
        {
            Console.WriteLine("扫地");
        }
        public void Wash()
        {
            Console.WriteLine("洗衣");
        }
        public void BuyRice()
        {
            Console.WriteLine("买米");
        }
    }
   

    // 学雷锋的学生
    class UnderGraduate : LeiFeng { }

    // 学雷锋的志愿者
    class Volunteer : LeiFeng { }

    // 雷锋工厂
    interface IFactory
    {
        LeiFeng CreateLeiFeng();
    }

    // 学雷锋的学生工厂
    class UnderGraduateFactory : IFactory
    {
        public LeiFeng CreateLeiFeng()
        {
            return new UnderGraduate();
        }
    }

    // 学雷锋的志愿者工厂
    class VolunteerFactory : IFactory
    {
        public LeiFeng CreateLeiFeng()
        {
            return new Volunteer();
        }
    }
}
