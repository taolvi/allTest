using System;

/*
 * 职责链模式
 * 使多个对象都有机会处理请求，从而避免请求的发送者和接收者之间的耦合关系。
 * 将这个对象连成一条链，并沿着这条链传递该请求，直到有一个对象处理它为止。
 * 
 * 请求层层上传。相当于职工只跟自己最近的上司提出请求。上司在层层上报直到处理为止。
 */
namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            Handler h1 = new ConcreteHandler1();
            Handler h2 = new ConcreteHandler2();
            Handler h3 = new ConcreteHandler3();

            h1.SetSuccessor(h2);
            h2.SetSuccessor(h3);

            int[] requests = { 1, 5, 14, 23, 30 };

            foreach (int request in requests)
            {
                h1.HandleRequest(request);
            }
            Console.Read();
        }
    }

    abstract class Handler
    {
        protected Handler successor;        // 继任者
        public void SetSuccessor(Handler successor) { this.successor = successor; }
        public abstract void HandleRequest(int request);
    }

    class ConcreteHandler1 : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request >= 0 && request <= 10)
            {
                Console.WriteLine("{0}处理请求{1}", this.GetType().Name, request);
            }
            else if (successor != null)
            {
                successor.HandleRequest(request);
            }
        }
    }

    class ConcreteHandler2 : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request > 10 && request <= 20)
            {
                Console.WriteLine("{0}处理请求{1}", this.GetType().Name, request);
            }
            else if (successor != null)
            {
                successor.HandleRequest(request);
            }
        }
    }

    class ConcreteHandler3 : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request > 20 && request <= 30)
            {
                Console.WriteLine("{0}处理请求{1}", this.GetType().Name, request);
            }
            else if (successor != null)
            {
                successor.HandleRequest(request);
            }
        }
    }
}
