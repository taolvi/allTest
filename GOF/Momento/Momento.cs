using System;

/*
 * 备忘录模式
 * 在不破坏封装性的前提下，捕获一个对象的内部状态，并在该对象之外保存这个状态。
 * 这样就可以将该对象恢复到原先保存的状态。
 */
namespace GoF
{
    class Program
    {
        static void Main(string[] args)
        {
            Originator o = new Originator();
            o.State = "On";
            o.Show();
            // 创建备忘录并保存结果
            Caretaker c = new Caretaker();
            c.Momento = o.CreateMomento();
            // 修改
            o.State = "Off";
            o.Show();
            // 恢复
            o.SetMomento(c.Momento);
            o.Show();

            Console.Read();
        }
    }

    /*
     * 发起人 Qriginator
     * 需要保存状态，返回一个保存当前状态的备忘录对象
     * 也可以加载一个备忘录对象，从备忘录对象中恢复保存的状态
     */
    class Originator
    {
        private string state; // 要记录的信息（可多个）
        public string State
        {
            get { return state; }
            set { state = value; }
        }
        public Momento CreateMomento()
        {
            return (new Momento(state));
        }
        public void SetMomento(Momento m)
        {
            this.state = m.State;
        }
        public void Show()
        {
            Console.WriteLine(this.state);
        }

    }

    // 备忘录 Momento，记录发起人的状态
    class Momento
    {
        private string state;
        public string State
        {
            get { return state; }
        }
        public Momento(string state)
        {
            this.state = state;
        }
    }

    // 管理者 Caretaker，负责管理备忘录
    class Caretaker
    {
        private Momento momento;
        public Momento Momento
        {
            get { return momento; }
            set { momento = value; }
        }
    }
}
