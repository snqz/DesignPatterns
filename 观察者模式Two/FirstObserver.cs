using System;
using System.Collections.Generic;
using System.Text;

namespace 观察者模式Two
{
    public class FirstObserver:IObserver
    {
        private ISubject subject { get; set; }
        public FirstObserver(ISubject subject)
        {
            this.subject = subject;
            subject.Reg(this);
        }

        public void Update(int tem, int hum)
        {
            Console.WriteLine($"第一个观察者,温度：{tem},湿度：{hum}");
        }
    }
}
