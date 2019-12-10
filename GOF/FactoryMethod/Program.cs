using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// 工厂方法模式
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
    // 雷锋工厂
    interface IFactory
    {
        LeiFeng CreateLeiFeng();
    }
    // 学雷锋的学生
    class UnderGraduate : LeiFeng
    { }
    // 学雷锋的志愿者
    class Volunteer : LeiFeng
    { }

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
