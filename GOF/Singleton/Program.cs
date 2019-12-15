
/*
 * 单例模式
 * 懒汉式：需要时才会创建（注意线程安全）
 * 饿汉式：程序启动便创建，无论是否需要。
 */
namespace GoF
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    #region Lazy
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
    #endregion

    #region Hungry
    public sealed class SingletonHungry // 阻止派生
    {
        private static readonly SingletonHungry instance = new SingletonHungry();
        private SingletonHungry() { }
        public static SingletonHungry GetInstance()
        {
            return instance;
        }
    }
    #endregion
}
