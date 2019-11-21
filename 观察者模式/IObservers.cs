using System;
using System.Collections.Generic;
using System.Text;

namespace 观察者模式
{
    public interface IObservers
    {
        void Update(float tem,float hum,float pre);
    }
}
