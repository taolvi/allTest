using System;

/*
 * 中介者模式
 * 用一个中介对象来封装一些列的对象交互。中介者使各个对象不需要显示的
 * 相互引用，从而使其耦合松散，而可以独立的改变它们之间的交互。
 */
namespace GoF
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcreteUN cUN = new ConcreteUN();
            Iraq iraq = new Iraq(cUN);
            USA usa = new USA(cUN);
            cUN.CountryIraq = iraq;
            cUN.CountryUSA = usa;

            iraq.Declare("Iraq: HAHAHAHA", usa);
            usa.Declare("USA: HEHEHEHE", iraq);

            Console.Read();       
        }
    }

    // 联合国作为中介者（抽象父类，具体的部门作为子类）
    abstract class UN
    {
        public abstract void Declare(string message, Country colleague);
    }
    // 国家类，国家需要知道联合国（中介者）
    abstract class Country
    {
        protected UN midiator;
        public Country(UN midiator) { this.midiator = midiator; }
    }

    class USA : Country
    {
        public USA(UN midiator) : base(midiator) { }
        public void Declare(string message, Country colleague)
        {
            midiator.Declare(message, colleague);
        }
        public void GetMessage(string message)
        {
            Console.WriteLine("USA获得消息" + message);
        }
    }

    class Iraq : Country
    {
        public Iraq(UN midiator) : base(midiator) { }
        public void Declare(string message, Country colleague)
        {
            midiator.Declare(message, colleague);
        }
        public void GetMessage(string message)
        {
            Console.WriteLine("Iraq获得消息" + message);
        }
    }

    // 联合国的具体部门（需要知道有那些国家）
    class ConcreteUN : UN
    {
        private USA countryUSA;
        private Iraq countryIraq;
        public USA CountryUSA { set { countryUSA = value; } }
        public Iraq CountryIraq { set { countryIraq = value; } }

        public override void Declare(string message, Country colleague)
        {
            if (colleague == countryUSA)
            {
                countryUSA.GetMessage(message);
            }
            else if (colleague == countryIraq)
            {
                countryIraq.GetMessage(message);
            }
        }
    }
}
