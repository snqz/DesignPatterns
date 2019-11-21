using System;
using System.Collections.Generic;

namespace 观察者模式Three
{
    class Program
    {
        static void Main(string[] args)
        {
            NewBoilWater newBoilWater = new NewBoilWater();
           
            newBoilWater.AddObserver(()=> {
                Console.WriteLine("水烧开了");
            });
            newBoilWater.AddObserver(()=> {
                Console.WriteLine("干其他事情");
            });
            newBoilWater.Boil();
        }
    }

    class BoilWater
    {
        public int wendu = 0;

        public IList<IObserver> observers = new List<IObserver>();

        public void Boil()
        {
            for (int i = 0; i < 100; i++)
            {
                wendu++;
                if (wendu==100)
                {
                    foreach (var item in observers)
                    {
                        item.Run();
                    }
                }
            }
        }

        public void Reg(IObserver o)
        {
            observers.Add(o);
        }
    }

    interface IObserver
    {
        void Run();
    }

    class FirstObserver : IObserver
    {
        private BoilWater subject { get; set; }
        public FirstObserver(BoilWater subject)
        {
            this.subject = subject;
            subject.Reg(this);
        }
        public void Run()
        {
            Console.WriteLine("第一个观察者");
        }
    }
}
