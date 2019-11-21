using System;
using System.Collections.Generic;
using System.Text;

namespace 观察者模式Two
{
    public interface IObserver
    {
        void Update(int tem,int hum);
    }
}
