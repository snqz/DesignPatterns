using System;
using System.Collections.Generic;
using System.Text;

namespace 观察者模式
{
    public interface ISubject
    {
        //注册观察者
        void registerObserver(IObservers o);
        //剔除观察者
        void removeObserver(IObservers o);
        //更新观察者
        void notifyObserver();
    }
}
