using System;

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

    // 联合国作为中介者
    abstract class UN
    {
        public abstract void Declare(string message, Country colleague);
    }

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
