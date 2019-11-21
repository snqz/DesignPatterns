using System;

namespace 单件模式Two
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class ChocolateBoiler
    {
        private bool empty;
        private bool boiled;
        private static ChocolateBoiler chocolateBoiler;

        private ChocolateBoiler()
        {
            empty = true;
            boiled = false;
        }

        public static ChocolateBoiler GetSingle()
        {
            lock (chocolateBoiler)
            {
                if (chocolateBoiler == null)
                {
                    lock (chocolateBoiler)
                    {
                        chocolateBoiler = new ChocolateBoiler();
                    }
                }
            }
            return chocolateBoiler;
        }
        public void fill()
        {
            if (isEmpty())
            {
                empty = false;
                boiled = false;
                //在锅炉内填满巧克力和牛奶的混合物
            }
        }

        public void drain()
        {
            if (!isEmpty()&&isBoiled())
            {
                //排出煮沸的巧克力和牛奶
                empty = true;
            }
        }

        public void boil()
        {
            if (!isEmpty()&&!isBoiled())
            {
                //将炉内物煮沸
                boiled = true;
            }
        }

        public bool isEmpty()
        {
            return empty;
        }
        public bool isBoiled()
        {
            return boiled;
        }

    }
}
