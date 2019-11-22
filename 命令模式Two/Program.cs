using System;

namespace 命令模式Two
{
    class Program
    {
        static void Main(string[] args)
        {
            RemoteControl remoteControl = new RemoteControl();

            //创建所有的装置
            Light kitChenlight = new Light("厨房灯");
            Light liveRoomlight = new Light("卧室灯");
            Stereo stereo = new Stereo();

            //为装置创建命令对象
            LightOnCommand kitChenlightOnCommand = new LightOnCommand(kitChenlight);
            LightOffCommand kitChenlightOffCommand = new LightOffCommand(kitChenlight);

            LightOnCommand liveRoomlightOnCommand = new LightOnCommand(liveRoomlight);
            LightOffCommand liveRoomlightOffCommand = new LightOffCommand(liveRoomlight);

            StereoOnCommand stereoOnCommand = new StereoOnCommand(stereo);
            StereoOffCommand stereoOffCommand = new StereoOffCommand(stereo);

            //将命令对象加载到遥控器中
            remoteControl.SetCommand(0, kitChenlightOnCommand, kitChenlightOffCommand);
            remoteControl.SetCommand(1, liveRoomlightOnCommand, liveRoomlightOffCommand);
            remoteControl.SetCommand(2, stereoOnCommand, stereoOffCommand);

            //按下遥控器每个插槽的开关
            remoteControl.OnButtonWasPushed(0);
            remoteControl.OnButtonWasPushed(1);

            //remoteControl.UndoButtonWasPushed();

            remoteControl.OnButtonWasPushed(2);
            remoteControl.OffButtonWasPushed(0);
            remoteControl.OffButtonWasPushed(1);
            remoteControl.OffButtonWasPushed(2);

            Console.WriteLine("------------------------------");
            remoteControl.OnButtonWasPushed(3);
            remoteControl.OffButtonWasPushed(3);
            remoteControl.OnButtonWasPushed(4);
            remoteControl.OffButtonWasPushed(4);
        }
    }

    class RemoteControl
    {
        Command[] onCommands;
        Command[] offCommands;
        Command undoCommand;

        public RemoteControl()
        {
            onCommands = new Command[5];
            offCommands = new Command[5];

            //NoCommand空对象
            Command noCommand = new NoCommand();
            for (int i = 0; i < 5; i++)
            {
                onCommands[i] = noCommand;
                offCommands[i] = noCommand;
            }
            undoCommand = noCommand;
        }

        public void SetCommand(int slot,Command onCommand,Command offCommand)
        {
            onCommands[slot] = onCommand;
            offCommands[slot] = offCommand;
        }

        public void OnButtonWasPushed(int slot)
        {
            onCommands[slot].Execute();
            undoCommand = onCommands[slot];
        }
        public void OffButtonWasPushed(int slot)
        {
            offCommands[slot].Execute();
            undoCommand = offCommands[slot];
        }
        public void UndoButtonWasPushed()
        {
            undoCommand.Undo();
        }
    }

    class NoCommand : Command
    {
        public void Execute()
        {
            Console.WriteLine("空的命令插槽");
        }

        public void Undo()
        {
        }
    }

    interface Command
    {
        void Execute();
        //撤销
        void Undo();
    }
    #region 灯
    class Light
    {
        public string name;
        public Light(string name)
        {
            this.name = name;
        }
        public void On()
        {
            Console.WriteLine($"{name}灯开");
        }
        public void Off()
        {
            Console.WriteLine($"{name}灯关");
        }
    }
    //开灯命令
    class LightOnCommand : Command
    {
        private Light light;
        public LightOnCommand(Light light)
        {
            this.light = light;
        }
        public void Execute()
        {
            light.On();
        }

        public void Undo()
        {
            light.Off();
        }
    }
    //关灯命令
    class LightOffCommand : Command
    {
        private Light light;
        public LightOffCommand(Light light)
        {
            this.light = light;
        }
        public void Execute()
        {
            light.Off();
        }

        public void Undo()
        {
            light.On();
        }
    }
    #endregion
    #region 音响
    class Stereo
    {
        public void On()
        {
            Console.WriteLine("音响打开");
        }
        public void SetCD()
        {
            Console.WriteLine("设为播放CD");
        }
        public void SetVolume(int num)
        {
            Console.WriteLine($"调节音量为{num}");
        }
        public void Off()
        {
            Console.WriteLine("音响关闭");
        }
    }
    class StereoOnCommand : Command
    {
        private Stereo stereo;
        public StereoOnCommand(Stereo stereo)
        {
            this.stereo = stereo;
        }
        public void Execute()
        {
            stereo.On();
            stereo.SetCD();
            stereo.SetVolume(11);
        }

        public void Undo()
        {
            stereo.Off();
        }
    }
    class StereoOffCommand : Command
    {
        private Stereo stereo;
        public StereoOffCommand(Stereo stereo)
        {
            this.stereo = stereo;
        }
        public void Execute()
        {
            stereo.Off();
        }

        public void Undo()
        {
            stereo.On();
        }
    }
    #endregion
    #region 吊扇
    class CeilingFan
    {
        public static int High = 3;
        public static int Medium = 2;
        public static int Low = 1;
        public static int Off = 0;

        string location;
        int speed;

        public CeilingFan(string location)
        {
            this.location = location;
            speed = Off;
        }

        public void high()
        {
            speed = High;
        }
        public void medium()
        {
            speed = Medium;
        }
        public void low()
        {
            speed = Low;
        }
        public void off()
        {
            speed = Off;
        }
        public int GetSpeed()
        {
            return speed;
        }
    }
    class CeilingFanHighCommand : Command
    {
        CeilingFan ceilingFan;
        int prevSpeed;
        public CeilingFanHighCommand(CeilingFan ceilingFan)
        {
            this.ceilingFan = ceilingFan;
        }
        public void Execute()
        {
            //执行前先记录速度，方便撤销
            prevSpeed = ceilingFan.GetSpeed();
            ceilingFan.high();
        }

        public void Undo()
        {
            if (prevSpeed== CeilingFan.High)
            {
                ceilingFan.high();
            }
            if (prevSpeed == CeilingFan.Medium)
            {
                ceilingFan.medium();
            }
            if (prevSpeed == CeilingFan.Low)
            {
                ceilingFan.low();
            }
            if (prevSpeed == CeilingFan.Off)
            {
                ceilingFan.off();
            }
        }
    }
    class CeilingFanMediumCommand : Command
    {
        CeilingFan ceilingFan;
        int prevSpeed;
        public CeilingFanMediumCommand(CeilingFan ceilingFan)
        {
            this.ceilingFan = ceilingFan;
        }
        public void Execute()
        {
            //执行前先记录速度，方便撤销
            prevSpeed = ceilingFan.GetSpeed();
            ceilingFan.medium();
        }

        public void Undo()
        {
            if (prevSpeed == CeilingFan.High)
            {
                ceilingFan.high();
            }
            if (prevSpeed == CeilingFan.Medium)
            {
                ceilingFan.medium();
            }
            if (prevSpeed == CeilingFan.Low)
            {
                ceilingFan.low();
            }
            if (prevSpeed == CeilingFan.Off)
            {
                ceilingFan.off();
            }
        }
    }
    class CeilingFanLowCommand : Command
    {
        CeilingFan ceilingFan;
        int prevSpeed;
        public CeilingFanLowCommand(CeilingFan ceilingFan)
        {
            this.ceilingFan = ceilingFan;
        }
        public void Execute()
        {
            //执行前先记录速度，方便撤销
            prevSpeed = ceilingFan.GetSpeed();
            ceilingFan.low();
        }

        public void Undo()
        {
            if (prevSpeed == CeilingFan.High)
            {
                ceilingFan.high();
            }
            if (prevSpeed == CeilingFan.Medium)
            {
                ceilingFan.medium();
            }
            if (prevSpeed == CeilingFan.Low)
            {
                ceilingFan.low();
            }
            if (prevSpeed == CeilingFan.Off)
            {
                ceilingFan.off();
            }
        }
    }
    class CeilingFanOffCommand : Command
    {
        CeilingFan ceilingFan;
        int prevSpeed;
        public CeilingFanOffCommand(CeilingFan ceilingFan)
        {
            this.ceilingFan = ceilingFan;
        }
        public void Execute()
        {
            //执行前先记录速度，方便撤销
            prevSpeed = ceilingFan.GetSpeed();
            ceilingFan.off();
        }

        public void Undo()
        {
            if (prevSpeed == CeilingFan.High)
            {
                ceilingFan.high();
            }
            if (prevSpeed == CeilingFan.Medium)
            {
                ceilingFan.medium();
            }
            if (prevSpeed == CeilingFan.Low)
            {
                ceilingFan.low();
            }
            if (prevSpeed == CeilingFan.Off)
            {
                ceilingFan.off();
            }
        }
    }
    #endregion

    #region 命令组合
    class MacroCommand : Command
    {
        Command[] commands;
        public MacroCommand(Command[] commands)
        {
            //传入一堆命令
            this.commands = commands;
        }
        public void Execute()
        {
            for (int i = 0; i < commands.Length; i++)
            {
                commands[i].Execute();
            }
        }

        public void Undo()
        {
            for (int i = commands.Length-1; i >=0; i--)
            {
                commands[i].Undo();
            }
        }
    }
    #endregion
}
