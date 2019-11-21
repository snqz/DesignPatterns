using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace 观察者模式
{
    public class CreateSubject : ISubject
    {
        private List<IObservers> observers { get; set; }
        private float tem { get; set; }
        private float hum { get; set; }
        private float pre { get; set; }
        public CreateSubject()
        {
            observers = new List<IObservers>();
        }

        public void notifyObserver()
        {
            for (int i = 0; i < observers.Count; i++)
            {
                IObservers observer = observers[i];
                observer.Update(tem,hum,pre);
            }
            Console.WriteLine("更新观察者");
        }

        public void registerObserver(IObservers o)
        {
            observers.Add(o);
            Console.WriteLine("注册观察者");
        }

        public void removeObserver(IObservers o)
        {
            int i = observers.IndexOf(o);
            if (i>=0)
            {
                observers.Remove(o);
            }
            Console.WriteLine("删除观察者");
        }

        public void getTemperature()
        {
            Console.WriteLine("温度");
        }
        public void getHumidity()
        {
            Console.WriteLine("湿度");
        }
        public void getPressure()
        {
            Console.WriteLine("压力");
        }

        public void measurementsChanged()
        {
            notifyObserver();
            Console.WriteLine("测量值变动");
        }

        public void setMeasurements(float temperature,float humidity,float pressure)
        {
            tem = temperature;
            hum = humidity;
            pre = pressure;
            measurementsChanged();
        }
    }
}
