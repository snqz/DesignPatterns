using System;

namespace 外观模式First
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
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
            Console.WriteLine("开始看电影");
            _popcornPopper.on();
        }
    }

    interface items
    {
        void on();
    }

    //放大
    class Amplifier : items
    {
        public void on()
        {
            throw new NotImplementedException();
        }
    }
    //调谐器
    class Tuner : items
    {
        public void on()
        {
            throw new NotImplementedException();
        }
    }
    //Dvd播放器
    class DvdPlayer : items
    {
        public void on()
        {
            throw new NotImplementedException();
        }
    }
    //Cd播放器
    class CdPlayer : items
    {
        public void on()
        {
            throw new NotImplementedException();
        }
    }
    //投影仪
    class Projector : items
    {
        public void on()
        {
            throw new NotImplementedException();
        }
    }
    //剧院的灯光
    class TheaterLights : items
    {
        public void on()
        {
            throw new NotImplementedException();
        }
    }
    //屏幕
    class Screen : items
    {
        public void on()
        {
            throw new NotImplementedException();
        }
    }
    //爆米花机
    class PopcornPopper : items
    {
        public void on()
        {
            throw new NotImplementedException();
        }
    }
}
