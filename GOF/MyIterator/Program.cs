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
