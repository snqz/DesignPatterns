using System;

namespace 命令模式First
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    //实现命令接口
    public interface Command 
    {
        void Execute();
    }

    //实现一个打开电灯命令
    public class LightOnCommand : Command
    {
        Light light;
        public LightOnCommand(Light light)
        {
            this.light = light;
        }
        public void Execute()
        {
            light.On();
        }
    }

    public class Light
    {
        public void On()
        {
            Console.WriteLine("灯开");
        }
        public void Off()
        {
            Console.WriteLine("灯关");
        }
    }

    public class SimpleRemoteControl
    {
        Command slot;
        public SimpleRemoteControl()
        {

        }
        public void SetCommand(Command command)
        {
            slot = command;
        }

    }
}
