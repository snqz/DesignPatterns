using System;
using System.Collections.Generic;
using System.Text;

namespace 观察者模式
{
    public class CreateObserver :  IObservers,IDisplayElement
    {
        private float tem { get; set; }
        private float hum { get; set; }
        private CreateSubject createSubject { get; set; }

        public CreateObserver(CreateSubject createSubject)
        {
            this.createSubject = createSubject;
            createSubject.registerObserver(this);
        }

        public void display()
        {
            Console.WriteLine($"温度:{tem};湿度:{hum}");
        }

        public void Update(float tem, float hum, float pre)
        {
            this.tem = tem;
            this.hum = hum;
            display();
            Console.WriteLine("更新主题数据");
        }
    }
}
