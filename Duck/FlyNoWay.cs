using System;
using System.Collections.Generic;
using System.Text;

namespace Duck
{
    public class FlyNoWay : IFlyBehavior
    {
        public void Fly()
        {
            Console.WriteLine("不会飞");
        }
    }
}
