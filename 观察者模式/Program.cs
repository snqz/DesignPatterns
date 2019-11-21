using System;

namespace 观察者模式
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateSubject createSubject = new CreateSubject();

            CreateObserver createObserver = new CreateObserver(createSubject);


            createSubject.setMeasurements(2,3,4) ;


           
        }
    }
}
