using System;

namespace 外观模式First
{
    class Program
    {
        static void Main(string[] args)
        {
            Amplifier amp = new Amplifier();
            Tuner tuner = new Tuner();
            DvdPlayer dvdPlayer = new DvdPlayer();
            CdPlayer cdPlayer = new CdPlayer();
            Projector projector = new Projector();
            TheaterLights theaterLights = new TheaterLights();
            Screen screen = new Screen();
            PopcornPopper popcornPopper = new PopcornPopper();
            HomeTheaterFacade homeTheaterFacade = new HomeTheaterFacade(amp,tuner,dvdPlayer,cdPlayer,projector,theaterLights,screen,popcornPopper);
            homeTheaterFacade.WatchMovie("复仇者联盟");
            homeTheaterFacade.EndMovie();
        }
    }

    class HomeTheaterFacade
    {
        Amplifier _amp;
        Tuner _tuner;
        DvdPlayer _dvdPlayer;
        CdPlayer _cdPlayer;
        Projector _projector;
        TheaterLights _theaterLights;
        Screen _screen;
        PopcornPopper _popcornPopper;

        public HomeTheaterFacade(Amplifier amp,Tuner tuner,DvdPlayer dvdPlayer,CdPlayer cdPlayer,
            Projector projector,TheaterLights theaterLights,Screen screen,PopcornPopper popcornPopper)
        {
            _amp= amp;
            _tuner= tuner;
            _dvdPlayer= dvdPlayer;
            _cdPlayer= cdPlayer;
            _projector= projector;
            _theaterLights= theaterLights;
            _screen= screen;
            _popcornPopper= popcornPopper;
        }

        public void WatchMovie(string movie)
        {
            Console.WriteLine($"开始看电影{movie}");
            _popcornPopper.on();
            _theaterLights.on();
            _theaterLights.Dim(10);
            _dvdPlayer.on();
        }
        public void EndMovie()
        {
            Console.WriteLine("结束看电影");
            _popcornPopper.Off();
            _theaterLights.Off();
            _dvdPlayer.Off();
        }
    }

    //放大
    class Amplifier
    {
        public void on()
        {
            throw new NotImplementedException();
        }
    }
    //调谐器
    class Tuner 
    {
        public void on()
        {
            Console.WriteLine("打开调谐器");
        }
        public void Off()
        {
            Console.WriteLine("关闭调谐器");
        }
    }
    //Dvd播放器
    class DvdPlayer
    {
        public void on()
        {
            Console.WriteLine("打开DVD播放器");
        }
        public void Off()
        {
            Console.WriteLine("关闭调谐器");
        }
    }
    //Cd播放器
    class CdPlayer
    {
        public void on()
        {
            Console.WriteLine("打开CD播放器");
        }
        public void Off()
        {
            Console.WriteLine("关闭CD播放器");
        }
    }
    //投影仪
    class Projector 
    {
        public void on()
        {
            Console.WriteLine("打开投影仪");
        }
        public void Off()
        {
            Console.WriteLine("关闭投影仪");
        }
    }
    //剧院的灯光
    class TheaterLights
    {
        public void on()
        {
            Console.WriteLine("打开剧场的灯光");
        }
        public void Off()
        {
            Console.WriteLine("关闭剧场的灯光");
        }
        public void Dim(int num)
        {
            Console.WriteLine($"调节灯关到{num}档");
        }
    }
    //屏幕
    class Screen
    {
        public void on()
        {
            Console.WriteLine("打开屏幕");
        }
        public void Off()
        {
            Console.WriteLine("关闭屏幕");
        }
    }
    //爆米花机
    class PopcornPopper 
    {
        public void on()
        {
            Console.WriteLine("打开爆米花机");
        }
        public void Off()
        {
            Console.WriteLine("关闭爆米花机");
        }
    }
}
