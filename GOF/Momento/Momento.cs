using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// don't fogert me
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
    // 发起人 Qriginator
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
    // 备忘录 Momento
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

    // 管理者 Caretaker
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
