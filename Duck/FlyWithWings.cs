using System;
using System.Collections.Generic;
using System.Text;

namespace Duck
{
    public class FlyWithWings : IFlyBehavior
    {
        public void Fly()
        {
            Console.WriteLine("飞行");
        }
    }
}
