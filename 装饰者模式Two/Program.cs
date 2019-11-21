using System;
using System.IO;

namespace 装饰者模式Two
{
    class Program
    {
        static void Main(string[] args)
        {
            //在当前目录创建按一个 test.txt文件
            using (Stream s = new FileStream("test.txt",FileMode.Create))
            {
                Console.WriteLine(s.CanRead);
                Console.WriteLine(s.CanWrite);
                Console.WriteLine(s.CanSeek);
                s.WriteByte(101);
                s.WriteByte(102);
                byte[] block = { 1,2,3,4,5};
                s.Write(block,0,block.Length);
                Console.WriteLine(s.Length);
                Console.WriteLine(s.Position);
                s.Position = 0;//回到开头位置
                Console.WriteLine(s.ReadByte());
                Console.WriteLine(s.ReadByte());
                Console.WriteLine(s.Read(block,0,block.Length));
                Console.WriteLine(s.Read(block,0,block.Length));
            }


        }
    }
}
