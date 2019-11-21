using System;
using System.Collections.Generic;
using System.Text;

namespace 观察者模式
{
    public class WeatherData
    {
        public float GetTemperature()
        {
            return 1;
        }

        public float GetHumidity()
        {
            return 2;
        }

        public float GetPressure()
        {
            return 3;
        }

        /*
         * 一旦气象测量更新，此方法会被调用
         */
        public void measurementsChanged()
        {
            float temp = GetTemperature();
            float humidity = GetHumidity();
            float pressure = GetPressure();


        }
    }
}
