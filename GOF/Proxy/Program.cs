using System;

/*
 * 代理模式
 * 为其他对象提供一个代理以控制这个对象的访问
 */
namespace Gof
{
    class Program
    {
        static void Main(string[] args)
        {
            Proxy p = new Proxy();
            p.Request();

            Console.ReadLine();
        }
    }

    abstract class Subject
    {
        public abstract void Request();
    }
    // 真实的请求
    class RealSubject : Subject
    {
        public override void Request()
        {
            Console.WriteLine("真实的请求");
        }
    }

    // 代理
    class Proxy : Subject
    {
        private RealSubject realSubject;
        public override void Request()
        {
            if (realSubject == null)
            {
                realSubject = new RealSubject();
            }
            realSubject.Request();  
        }
    }
}
