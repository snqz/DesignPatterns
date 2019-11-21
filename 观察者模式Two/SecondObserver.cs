using System;
using System.Collections.Generic;
using System.Text;

namespace 观察者模式Two
{
    public class SecondObserver : IObserver
    {
        private ISubject _subject { get; set; }
        public SecondObserver(ISubject subject)
        {
            _subject = subject;
            _subject.Reg(this);
        }
        public void Update(int tem, int hum)
        {
            Console.WriteLine($"第二个观察者,预测晚上温度:{tem+10},湿度：{hum+20}");
        }
    }
}
