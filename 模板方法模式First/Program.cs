using System;

namespace 模板方法模式First
{
    class Program
    {
        static void Main(string[] args)
        {
            Tea tea = new Tea();
            tea.prepareRecipe();
            Console.WriteLine("------------------------");
            Coffee coffee = new Coffee();
            coffee.prepareRecipe();
        }
    }
    abstract class CaffeineBeverage
    {
        //模板方法
        public void prepareRecipe()
        {
            BoilWater();
            Brew();
            PourInCup();

            if (CustomerWantsCondiments())
            {
                AddCondiments();
            }

        }

        public void BoilWater()
        {
            Console.WriteLine("水煮开");
        }
        public abstract void Brew();
        public void PourInCup()
        {
            Console.WriteLine("倒入杯中");
        }
        public abstract void AddCondiments();
        //钩子
        public virtual bool CustomerWantsCondiments() 
        {
            return true;
        }
    }


    class Coffee: CaffeineBeverage
    {
        public override void Brew()
        {
            Console.WriteLine("沸水冲泡咖啡");
        }
        public override void AddCondiments()
        {
            Console.WriteLine("加入糖和牛奶");
        }
        public override bool CustomerWantsCondiments()
        {
            Console.WriteLine("是否要加调料？");
            int num = Convert.ToInt32(Console.ReadLine());
            return num == 1;
        }
    }
    class Tea : CaffeineBeverage
    {
        public override void Brew()
        {
            Console.WriteLine("沸水冲泡茶");
        }
        public override void AddCondiments()
        {
            Console.WriteLine("加入柠檬");
        }
        public override bool CustomerWantsCondiments()
        {
            Console.WriteLine("是否要加调料？");
            int num =Convert.ToInt32(Console.ReadLine());
            return num==1;
        }
    }
}
