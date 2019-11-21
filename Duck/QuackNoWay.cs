using System;
using System.Collections.Generic;
using System.Text;

namespace Duck
{
    public class QuackNoWay : IQuackBehavior
    {
        public void Quack()
        {
            Console.WriteLine("不会叫");
        }
    }
}
