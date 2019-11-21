using System;
using System.Collections.Generic;
using System.Text;

namespace 观察者模式Two
{
    public interface ISubject
    {
        void Reg(IObserver o);
        void Update(int tem,int hum);
    }
}
