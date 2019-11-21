using System;
using System.Collections.Generic;

namespace 工厂模式Three
{
    class Program
    {
        static void Main(string[] args)
        {
            PizzaStore NY = new NYPizzaStore();
            NY.OrderPizza("cheese");
            Console.WriteLine("---------------------------");
            PizzaStore Chicago = new ChicagoPizzaStore();
            Chicago.OrderPizza("clam");
        }
    }

    interface PizzaIngredientFactory
    {
        Dough createDough();
        Sauce createSauce();
        Cheese createCheese();
        Veggies[] createVeggies();
        Pepperoni createPepperoni();
        Clams createClam();
    }
    class NYIngredientFactory : PizzaIngredientFactory
    {
        public Cheese createCheese()
        {
            return new ReggianoCheese();
        }

        public Clams createClam()
        {
            return new FreshClams();
        }

        public Dough createDough()
        {
            return new ThinCrustDough();
        }

        public Pepperoni createPepperoni()
        {
            return new SlicedPepperoni();
        }

        public Sauce createSauce()
        {
            return new MarinaraSauce();
        }

        public Veggies[] createVeggies()
        {
            Veggies[] veggies = {new Garlic(),new Onion(),new Mushroom(),new RedPepper() };
            return veggies;
        }
    }
    class ChicagoIngredientFactory : PizzaIngredientFactory
    {
        public Cheese createCheese()
        {
            return new MozzarellaCheese();
        }

        public Clams createClam()
        {
            return new FrozenClams();
        }

        public Dough createDough()
        {
            return new ThickCrustDough();
        }

        public Pepperoni createPepperoni()
        {
            return new SlicedPepperoni();
        }

        public Sauce createSauce()
        {
            return new PlumTomatoSauce();
        }

        public Veggies[] createVeggies()
        {
            Veggies[] veggies = { new EggPlant(), new Spinach(), new BlackOlives()};
            return veggies;
        }
    }
    #region 面团
    class Dough
    {
    }
    class ThinCrustDough:Dough
    {
        public ThinCrustDough()
        {
            Console.WriteLine("薄饼");
        }
    }
    class ThickCrustDough : Dough 
    {
        public ThickCrustDough()
        {
            Console.WriteLine("厚饼");
        }
    }
    #endregion
    #region 酱汁
    class Sauce
    {
    }
    class MarinaraSauce :Sauce
    {
        public MarinaraSauce()
        {
            Console.WriteLine("番茄酱");
        }
    }
    class PlumTomatoSauce : Sauce 
    {
        public PlumTomatoSauce()
        {
            Console.WriteLine("李子番茄酱");
        }
    }
    #endregion
    #region 芝士
    class Cheese
    {
    }
    class ReggianoCheese:Cheese
    {
        public ReggianoCheese()
        {
            Console.WriteLine("雷奇亚干酪奶酪");
        }
    }
    class MozzarellaCheese : Cheese
    {
        public MozzarellaCheese()
        {
            Console.WriteLine("马苏里拉奶酪");
        }
    }
    #endregion
    #region 蔬菜
    class Veggies
    {
    }
    class Garlic : Veggies
    {
        public Garlic()
        {
            Console.WriteLine("大蒜");
        }
    }
    class Onion : Veggies
    {
        public Onion()
        {
            Console.WriteLine("洋葱");
        }
    }
    class Mushroom : Veggies
    {
        public Mushroom()
        {
            Console.WriteLine("蘑菇");
        }
    }
    class RedPepper : Veggies
    {
        public RedPepper()
        {
            Console.WriteLine("红辣椒");
        }
    }
    class EggPlant : Veggies
    {
        public EggPlant()
        {
            Console.WriteLine("茄子");
        }
    }
    class Spinach : Veggies
    {
        public Spinach()
        {
            Console.WriteLine("菠菜");
        }
    }
    class BlackOlives : Veggies
    {
        public BlackOlives()
        {
            Console.WriteLine("黑橄榄");
        }
    }
    #endregion
    #region 意大利辣香肠
    class Pepperoni
    {
    }
    class SlicedPepperoni : Pepperoni
    {
        public SlicedPepperoni()
        {
            Console.WriteLine("意大利辣香肠");
        }
    }
    #endregion
    #region 蛤
    class Clams
    {
    }
    class FreshClams : Clams
    {
        public FreshClams()
        {
            Console.WriteLine("新鲜蛤蜊");
        }
    }
    class FrozenClams : Clams
    {
        public FrozenClams()
        {
            Console.WriteLine("冷冻蛤蜊");
        }
    }
    #endregion
    abstract class Pizza
    {
        public string name { get; set; }
        public Dough dough { get; set; }
        public Sauce sauce { get; set; }
        public List<Veggies> veggies { get; set; }
        public Cheese cheese { get; set; }
        public Pepperoni pepperoni { get; set; }
        public Clams clam { get; set; }
        public abstract void Prepare();
       
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
        public void SetName(string name)
        {
            this.name=name;
        }
    }
    class CheesePizza : Pizza
    {
        PizzaIngredientFactory _pizzaIngredientFactory;
        public CheesePizza(PizzaIngredientFactory pizzaIngredientFactory)
        {
            _pizzaIngredientFactory = pizzaIngredientFactory;
        }
        public override void Prepare()
        {
            Console.WriteLine("准备:"+name);
            dough = _pizzaIngredientFactory.createDough();
            sauce = _pizzaIngredientFactory.createSauce();
            cheese = _pizzaIngredientFactory.createCheese();
        }
    }
    class ClamPizza : Pizza
    {
        PizzaIngredientFactory _pizzaIngredientFactory;
        public ClamPizza(PizzaIngredientFactory pizzaIngredientFactory)
        {
            _pizzaIngredientFactory = pizzaIngredientFactory;
        }

        public override void Prepare()
        {
            Console.WriteLine("准备："+name);
            dough = _pizzaIngredientFactory.createDough();
            sauce = _pizzaIngredientFactory.createSauce();
            cheese = _pizzaIngredientFactory.createCheese();
            clam = _pizzaIngredientFactory.createClam();//纽约工厂就会使用新鲜的蛤蜊，芝加哥工厂就会用冷冻的蛤蜊。
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

            PizzaIngredientFactory pizzaIngredientFactory = new NYIngredientFactory();

            switch (type)
            {
                case "cheese":
                    pizza = new CheesePizza(pizzaIngredientFactory);
                    pizza.SetName("纽约芝士披萨");
                    break;
                case "clam":
                    pizza = new ClamPizza(pizzaIngredientFactory);
                    pizza.SetName("纽约蛤蜊披萨");
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

            PizzaIngredientFactory pizzaIngredientFactory = new ChicagoIngredientFactory();

            switch (type)
            {
                case "cheese":
                    pizza = new CheesePizza(pizzaIngredientFactory);
                    pizza.SetName("芝加哥芝士披萨");
                    break;
                case "clam":
                    pizza = new ClamPizza(pizzaIngredientFactory);
                    pizza.SetName("芝加哥蛤蜊披萨");
                    break;
                default:
                    break;
            }
            return pizza;
        }
    }
}
