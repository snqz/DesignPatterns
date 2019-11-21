using System;
using System.Collections.Generic;
using System.Text;

namespace Duck
{
    public class QuackWithWings : IQuackBehavior
    {
        public void Quack()
        {
            Console.WriteLine("呱呱");
        }
    }
}
