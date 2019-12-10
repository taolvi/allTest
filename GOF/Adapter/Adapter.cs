using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
