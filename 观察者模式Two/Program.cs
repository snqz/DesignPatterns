using System;

namespace 观察者模式Two
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherData weatherData = new WeatherData();

            FirstObserver firstObserver = new FirstObserver(weatherData);

            SecondObserver secondObserver = new SecondObserver(weatherData);

            weatherData.Update(1,2);
        }
    }
}
