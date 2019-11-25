using System;

namespace 适配器模式和外观模式Two
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    interface Iterator
    {
        void hasNext();
        void next();
        void remove();
    }

    interface Enumeration
    {
        void hasMoreElements();
        void nextElement();
    }
    class Enumerationiterator : Iterator
    {
        Enumeration _enum;
        public Enumerationiterator(Enumeration _enum)
        {
            this._enum = _enum;
        }
        public void hasNext()
        {
            _enum.hasMoreElements();
        }

        public void next()
        {

            _enum.nextElement();
        }

        public void remove()
        {
            throw new NotImplementedException();
        }
    }   
}
