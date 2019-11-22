using System;

namespace 命令模式First
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleRemoteControl remote = new SimpleRemoteControl();
            Light light = new Light();
            LightOnCommand lightOn = new LightOnCommand(light);

            remote.SetCommand(lightOn);
            remote.ButtonWasPressed();


            TV tv = new TV();
            TVOnCommand tvOn = new TVOnCommand(tv);

            remote.SetCommand(tvOn);
            remote.ButtonWasPressed();

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

    public class TVOnCommand : Command
    {
        TV tv;
        public TVOnCommand(TV tv)
        {
            this.tv = tv;
        }
        public void Execute()
        {
            tv.On();
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

    public class TV
    {
        public void On()
        {
            Console.WriteLine("电视开");
        }
        public void Off()
        {
            Console.WriteLine("电视关");
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
        public void ButtonWasPressed()
        {
            slot.Execute();
        }
    }

}
