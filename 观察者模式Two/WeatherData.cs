using System;
using System.Collections.Generic;
using System.Text;

namespace 观察者模式Two
{
    public class WeatherData : ISubject
    {
        private List<IObserver> _observers { get; set; }
        public WeatherData()
        {
            _observers = new List<IObserver>();
        }

        public void Update(int tem, int hum)
        {
            for (int i = 0; i < _observers.Count; i++)
            {
                IObserver observer = _observers[i];
                observer.Update(tem, hum);
            }
        }

        public void Reg(IObserver o)
        {
            _observers.Add(o);
        }
    }
}
