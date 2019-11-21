using System;
using System.Collections.Generic;
using System.Text;

namespace Duck
{

    #region v1
    /* 
    public abstract class Duck
    {
        //public void Quack()
        //{
        //    Console.WriteLine("呱呱");
        //}

        public void Swim()
        {
            Console.WriteLine("游泳");
        }

        //public void Fly()
        //{
        //    Console.WriteLine("飞行");
        //}

        public abstract void Display();
    }
    
    //绿头鸭子
    public class MallardDuck : Duck, IQuackable, IFlyable
    {
        public override void Display()
        {
            Console.WriteLine("我是绿头的");
        }

        public void Fly()
        {
            Console.WriteLine("飞行");
        }

        public void Quack()
        {
            Console.WriteLine("呱呱");
        }
    }

    //红头鸭子
    public class RedheadDuck : Duck, IQuackable, IFlyable
    {
        public override void Display()
        {
            Console.WriteLine("我是红头的");
        }

        public void Fly()
        {
            Console.WriteLine("飞行");
        }

        public void Quack()
        {
            Console.WriteLine("呱呱");
        }
    }

    //橡皮鸭
    public class RubberDuck : Duck, IQuackable
    {
        public void Quack()
        {
            Console.WriteLine("吱吱");
        }

        public override void Display()
        {
            Console.WriteLine("我是橡皮鸭");
        }
    }

    //诱饵鸭
    public class DecoyDuck : Duck
    {
        public override void Display()
        {
            Console.WriteLine("我是诱饵鸭");
        }

        //public void Quack()
        //{ 
        //}

        //public void Fly()
        //{
        //}

    }*/
    #endregion

    #region v2
    public abstract class Duck
    {
        public IFlyBehavior flyBehavior;
        public IQuackBehavior quackBehavior;
        public void PerformQuack()
        {
            quackBehavior.Quack();
        }

        public void PerformFly()
        {
            flyBehavior.Fly();
        }

        public void Swim()
        {
            Console.WriteLine("游泳");
        }

        public abstract void Display();

        public void setFlyBehavior(IFlyBehavior fb)
        {
            flyBehavior = fb;
        }

        public void setQuackBehavior(IQuackBehavior qb)
        {
            quackBehavior = qb;
        }
    }


    //绿头鸭子
    public class MallardDuck : Duck
    {
        public MallardDuck()
        {
            quackBehavior = new QuackWithWings();
            flyBehavior = new FlyWithWings();
        }

        public override void Display()
        {
            Console.WriteLine("我是绿头的");
        }
    }

    //红头鸭子
    public class RedheadDuck : Duck
    {
        public RedheadDuck()
        {
            quackBehavior = new QuackWithWings();
            flyBehavior = new FlyWithWings();
        }
        public override void Display()
        {
            Console.WriteLine("我是红头的");
        }
    }

    //橡皮鸭
    public class RubberDuck : Duck
    {
        public RubberDuck()
        {
            quackBehavior = new QuackWithWings();
            flyBehavior = new FlyNoWay();
        }
        public override void Display()
        {
            Console.WriteLine("我是橡皮鸭");
        }
    }

    //诱饵鸭
    public class DecoyDuck : Duck
    {
        public DecoyDuck()
        {
            quackBehavior = new QuackNoWay();
            flyBehavior = new FlyNoWay();
        }
        public override void Display()
        {
            Console.WriteLine("我是诱饵鸭");
        }
    }
    #endregion
}
