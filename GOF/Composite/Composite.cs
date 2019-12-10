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
            Composite root = new Composite("root");
            root.Add(new Leaf("LeafA"));
            root.Add(new Leaf("LeafB"));

            Composite comp = new Composite("CompositeX");
            comp.Add(new Leaf("LeafXA"));
            comp.Add(new Leaf("LeafYB"));
            root.Add(comp);

            root.Display(1);

            Console.Read();
        }
    }

    // 
    abstract class Component
    {
        protected string name;
        public Component(string name)
        {
            this.name = name;
        }

        public abstract void Add(Component c);
        public abstract void Remove(Component c);
        public abstract void Display(int depth);
    }

    // 叶子节点
    class Leaf : Component
    {
        public Leaf(string name) : base(name) { }
        public override void Add(Component c)
        {
            Console.WriteLine("Cannot add to leaf");
        }
        public override void Remove(Component c)
        {
            Console.WriteLine("Cannot remove from leaf");
        }
        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth)+name);
        }
    }

    class Composite : Component
    {
        private List<Component> children = new List<Component>();
        public Composite(string name) :base(name){ }

        public override void Add(Component c)
        {
            children.Add(c);
        }
        public override void Remove(Component c)
        {
            children.Remove(c);
        }
        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth)+name);
            foreach (Component c in children)
            {
                c.Display(depth + 2);
            }
        }
    }
}
