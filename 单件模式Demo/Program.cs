using System;

namespace 单件模式Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }


    class Singleton 
    {
        private static Singleton uniqueInstance;
        private Singleton()
        {

        }

        public static Singleton GetInstance()
        {
            if (uniqueInstance==null)
            {
                uniqueInstance = new Singleton();
            }
            return uniqueInstance;
        }
    }
}
