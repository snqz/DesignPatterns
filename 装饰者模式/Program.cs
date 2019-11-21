using System;

namespace 装饰者模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Beverage beverage = new HouseBlend();
            Console.WriteLine(beverage.GetDescription()+",$"+beverage.Cost());

            Beverage beverage1 = new DarkRoast();
            beverage1 = new Milk(beverage1);
            beverage1 = new Mocha(beverage1);
            Console.WriteLine(beverage1.GetDescription() + ",$" + beverage1.Cost());

            Beverage beverage2 = new HouseBlend();
            beverage2 = new Milk(beverage2);
            beverage2 = new Milk(beverage2);
            Console.WriteLine(beverage2.GetDescription() + ",$" + beverage2.Cost());
        }
    }

    abstract class Beverage
    {
        public string description = "Unknown Beverage";
        public string GetDescription()
        {
            return description;
        }
        public string GetSize()
        {
            return "大";
        }
        public abstract double Cost();

    }

    class HouseBlend : Beverage
    {
        public HouseBlend()
        {
            description = "housrBlend";
        }
        public override double Cost()
        {
            return 1.0;
        }
    }

    class DarkRoast : Beverage
    {
        public DarkRoast()
        {
            description = "darkRoast";
        }
        public override double Cost()
        {
            return 2.0;
        }
    }

    abstract class CondimentDecorator : Beverage
    {
        public abstract string GetDescription();
    }

    class Milk : CondimentDecorator
    {
        Beverage _beverage;
        public Milk(Beverage beverage)
        {
            _beverage = beverage;
        }
        public override double Cost()
        {
            double cost = _beverage.Cost();
            switch (GetSize())
            {
                case "大":
                    cost += .90;
                    break;
                case "中":
                    cost += .50;
                    break;
                case "小":
                    cost += .10;
                    break;
                default:
                    break;
            }
            return 0.4+ cost;
        }

        public string GetSizt()
        {
            return _beverage.GetSize();
        }
        public override string GetDescription()
        {
            return _beverage.GetDescription() + ",Milk";
        }
    }

    class Mocha : CondimentDecorator
    {
        Beverage _beverage;
        public Mocha(Beverage beverage)
        {
            _beverage = beverage;
        }
        public override double Cost()
        {
            return 0.5+ _beverage.Cost();
        }

        public override string GetDescription()
        {
            return _beverage.GetDescription() + ",Mocha";
        }
    }
}
