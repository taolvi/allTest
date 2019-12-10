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
        }
    }
    // lazy
    class SingletonLazy
    {
        private static SingletonLazy instance;
        private static readonly object synRoot = new object();
        private SingletonLazy() { }
        
        public static SingletonLazy GetInstance()
        {
            if (instance == null)
            {
                lock (synRoot)
                {
                    if (instance == null)
                    {
                        instance = new SingletonLazy();
                    }
                }
            }
            return instance;
        } 
    }

    public sealed class SingletonHungry // 阻值派生
    {
        private static readonly SingletonHungry instance = new SingletonHungry();
        private SingletonHungry() { }
        public static SingletonHungry GetInstance()
        {
            return instance;
        }
    }
}
