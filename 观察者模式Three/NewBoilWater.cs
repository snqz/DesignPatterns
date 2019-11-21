using System;
using System.Collections.Generic;
using System.Text;

namespace 观察者模式Three
{
    public class NewBoilWater
    {
        public int waterTemperature = 0;

        private event Action actions;
        public void Boil()
        {
            for (int i = 0; i <= 100; i++)
            {
                waterTemperature = i;
                if (waterTemperature==100)
                {
                    actions();
                }
            }
        }

        public void AddObserver(Action runner)
        {
            actions += runner;
        }

        public void RemoveObserver(Action runner)
        {
            actions -= runner;
        }
    }
}
