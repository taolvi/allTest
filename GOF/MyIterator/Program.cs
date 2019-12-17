using System;
using System.Collections.Generic;

/*
 * 迭代器模式
 * 提供一种方法顺序访问一个聚合对象中的各个元素，而又不
 * 暴露该对象的内部表示
 */
namespace GoF
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcreteAggregate agg = new ConcreteAggregate();
            agg[0] = "AA";
            agg[1] = "BB";
            agg[2] = "CC";
            agg[3] = "DD";

            Iterator i = agg.CreateIterator();
            object o = i.First();
            while (!i.IsDone())
            {
                Console.WriteLine((string)o);
                o = i.Next();
            }
            Console.Read();
        }
    }
    // 迭代器抽象类
    public abstract class Iterator
    {
        public abstract object First();
        public abstract object Next();
        public abstract bool IsDone();
        public abstract object CurrentItem();
    }

    // 聚集抽象类
    public abstract class Aggregate
    {
        public abstract Iterator CreateIterator();
    }

    /*
     * 具体迭代器
     * 包括：返回第一个元素，返回下一个元素，检查是否循环完，获取特定元素等方法
     */
    public class ConcreteIterator : Iterator
    {
        private ConcreteAggregate agg;
        private int Count = 0;
        public ConcreteIterator(ConcreteAggregate agg)
        {
            this.agg = agg;
        }
        public override object First()
        {
            return agg[0];
        }
        public override object Next()
        {
            object ret = null;
            Count++;
            if(Count<agg.Count)
            {
                ret = agg[Count];
            }
            return ret;
        }
        public override bool IsDone()
        {
            return Count >= agg.Count?true:false;
        }
        public override object CurrentItem()
        {
            return agg[Count];
        }
    }

    /*
     * 使用该迭代器的对象
     */
    public class ConcreteAggregate : Aggregate
    {
        private IList<object> items = new List<object>();
        public override Iterator CreateIterator()
        {
            return new ConcreteIterator(this);
        }
        public int Count
        {
            get { return items.Count; }
        }
        public object this[int index]
        {
            get { return items[index]; }
            set { items.Insert(index, value); }
        }
    }

}
