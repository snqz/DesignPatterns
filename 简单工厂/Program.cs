using System;

namespace 简单工厂
{
    class Program
    {
        static void Main(string[] args)
        {
            SimplePizzaFactory simplePizzaFactory = new SimplePizzaFactory();
            PizzaStore pizzaStore = new PizzaStore(simplePizzaFactory);
            pizzaStore.OrderPizza("cheese");
        }
    }

    class SimplePizzaFactory
    {
        public Pizza CreatePizza(string type)
        {
            Pizza pizza = null;

            switch (type)
            {
                case "cheese":
                    pizza = new CheesePizza();
                    break;
                case "Veggie":
                    pizza = new VeggiePizza();
                    break;
                default:
                    break;
            }
            return pizza;
        }
    }
    class PizzaStore
    {
        SimplePizzaFactory _factory;
        public PizzaStore(SimplePizzaFactory factory)
        {
            _factory = factory;
        }

        public Pizza OrderPizza(string type)
        {
            Pizza pizza = _factory.CreatePizza(type);

            pizza.Prepare();
            pizza.Bake();
            pizza.Cut();
            pizza.Box();
            return pizza;
        }
    }
    class Pizza
    { 
        public void Prepare()
        {
            Console.WriteLine("Prepare");
        }
        public void Bake()
        {
            Console.WriteLine("Bake");
        }
        public void Cut()
        {
            Console.WriteLine("Cut");
        }
        public void Box()
        {
            Console.WriteLine("Box");
        }
    }
    class CheesePizza : Pizza 
    {
    
    }
    class VeggiePizza : Pizza
    {

    }
}
