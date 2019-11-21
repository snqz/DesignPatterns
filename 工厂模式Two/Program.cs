using System;
using System.Collections.Generic;

namespace 工厂模式Two
{
    class Program
    {
        static void Main(string[] args)
        {
            NYPizzaStore nYPizzaStore = new NYPizzaStore();
            Pizza nyPizza = nYPizzaStore.OrderPizza("cheese");
            Console.WriteLine(nyPizza.GetName());
            Console.WriteLine("-----------------------");
            ChicagoPizzaStore chicagoPizzaStore = new ChicagoPizzaStore();
            Pizza chicgaoPizza = chicagoPizzaStore.OrderPizza("cheese");
            Console.WriteLine(chicgaoPizza.GetName());

        }
    }

    abstract class PizzaStore
    {
        public abstract Pizza CreatePizza(string type);

        public Pizza OrderPizza(string type)
        {
            Pizza pizza = CreatePizza(type);

            pizza.Prepare();
            pizza.Bake();
            pizza.Cut();
            pizza.Box();
            return pizza;
        }
    }
    //纽约pizza店
    class NYPizzaStore : PizzaStore
    {
        public override Pizza CreatePizza(string type)
        {
            Pizza pizza = null;

            switch (type)
            {
                case "cheese":
                    pizza = new NYCheesePizza();
                    break;
                case "Veggie":
                    pizza = new NYVeggiePizza();
                    break;
                default:
                    break;
            }
            return pizza;
        }
    }
    //芝加哥pizza店
    class ChicagoPizzaStore : PizzaStore
    {
        public override Pizza CreatePizza(string type)
        {
            Pizza pizza = null;

            switch (type)
            {
                case "cheese":
                    pizza = new ChicagoCheesePizza();
                    break;
                case "Veggie":
                    pizza = new ChicagoVeggiePizza();
                    break;
                default:
                    break;
            }
            return pizza;
        }
    }

    abstract class Pizza
    {
        public string name { get; set; }
        public string dough { get; set; }
        public string sauce { get; set; }
        public List<string> toppings = new List<string>();
        public void Prepare()
        {
            Console.WriteLine("准备:"+name);
            Console.WriteLine("面饼:"+dough);
            Console.WriteLine("酱料:"+sauce);
            Console.WriteLine("配料:");
            for (int i = 0; i < toppings.Count; i++)
            {
                Console.WriteLine(toppings[i]);
            }
        }
        public void Bake()
        {
            Console.WriteLine("加热25分钟");
        }
        public virtual void Cut()
        {
            Console.WriteLine("把披萨切成对角");
        }
        public void Box()
        {
            Console.WriteLine("把披萨放在官方的披萨店盒子里");
        }

        public string GetName() 
        {
            return name;
        }
    }
    class NYCheesePizza : Pizza
    {
        public NYCheesePizza()
        {
            name = "纽约风味芝士披萨";
            dough = "薄饼";
            sauce = "大蒜番茄酱";

            toppings.Add("意大利高级干酪");
        }
    }
    class NYVeggiePizza : Pizza
    {
        public NYVeggiePizza()
        {
            name = "纽约风味素食披萨";
            dough = "薄饼";
            sauce = "大蒜番茄酱";

            toppings.Add("意大利高级干酪");
        }
    }
    class ChicagoCheesePizza : Pizza
    {
        public ChicagoCheesePizza()
        {
            name = "芝加哥风味芝士披萨";
            dough = "厚饼";
            sauce = "小番茄酱";

            toppings.Add("意大利白干酪");
        }
        public override void Cut()
        {
            Console.WriteLine("将披萨切成正方形");
        }
    }
    class ChicagoVeggiePizza : Pizza
    {
        public ChicagoVeggiePizza()
        {
            name = "芝加哥风味素食披萨";
            dough = "厚饼";
            sauce = "小番茄酱";

            toppings.Add("意大利白干酪");
        }
        public override void Cut()
        {
            Console.WriteLine("将披萨切成正方形");
        }
    }
}
