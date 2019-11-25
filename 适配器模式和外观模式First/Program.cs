using System;

namespace 适配器模式和外观模式First
{
    class Program
    {
        static void Main(string[] args)
        {
            Turkey turkey = new WildTurkey();
            Duck duck =new TurkeyAdapter(turkey);
            duck.Quack();
            duck.Fly();
        }
    }

    #region 鸭子
    interface Duck
    {
        void Quack();
        void Fly();
    }

    class MallardDuck : Duck
    {
        public void Fly()
        {
            Console.WriteLine("飞行");
        }

        public void Quack()
        {
            Console.WriteLine("呱呱");
        }
    }
    #endregion

    #region 火鸡
    interface Turkey
    {
        void Gobble();
        void Fly();
    }

    class WildTurkey : Turkey
    {
        public void Fly()
        {
            Console.WriteLine("飞行很短的时间");
        }

        public void Gobble()
        {
            Console.WriteLine("咯咯");
        }
    }
    #endregion

    #region 适配器
    //火鸡适配器
    class TurkeyAdapter : Duck
    {
        Turkey turkey;
        public TurkeyAdapter(Turkey turkey)
        {
            this.turkey = turkey;
        }
        public void Fly()
        {
            for (int i = 0; i < 5; i++)
            {
                turkey.Fly();
            }
        }

        public void Quack()
        {
            turkey.Gobble();
        }
    }
    //鸭子适配器
    class DuckAdapter:Turkey
    {
        Duck duck;
        public DuckAdapter(Duck duck)
        {
            this.duck = duck;
        }
        public void Fly()
        {
            duck.Fly();
        }

        public void Gobble()
        {
            duck.Quack();
        }
    }
    #endregion
}
