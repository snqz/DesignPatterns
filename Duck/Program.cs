using System;

namespace Duck
{
    class Program
    {
        static void Main(string[] args)
        {

            var rubber = new MallardDuck();
            rubber.PerformQuack();
            rubber.PerformFly();

            rubber.setFlyBehavior(new FlyNoWay());

            rubber.setQuackBehavior(new QuackNoWay());

            rubber.PerformQuack();
            rubber.PerformFly();


            //var decoyDuck = new DecoyDuck();
            //decoyDuck.PerformQuack();
            //decoyDuck.PerformFly();

            Console.ReadKey();
        }
    }
}