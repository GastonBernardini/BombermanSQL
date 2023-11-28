using System;
using System.Collections.Generic;
using System.Data;
using System.Media;
using System.Threading;
using Tao.Sdl;

namespace MyGame
{

    class Program
    {
                    
        //static IntPtr image = Engine.LoadImage("assets/fondo.png");
        //private static DateTime _startTime;
        //private static float _lastTimeFrame;
        //public static float DeltaTime;
        //public static Character player;
        //public static List<GameObject> gameObjectList = new List<GameObject>();

        static void Main(string[] args)
        {
            Initialize();
            SoundPlayer musicplayer = new SoundPlayer("assets/BackgroundTheme.wav");
            musicplayer.Play();

            while (true)
            {
                GameManager.Instance.Update();

                GameManager.Instance.Render();

                Sdl.SDL_Delay(20);
            }
        }

        private static void Initialize()
        {
            //SoundPlayer musicPlayer = new SoundPlayer("assets/BackgroundTheme.wav");
            GameManager.Instance.Initialize();
        }

        public static void Update()
        {
            GameManager.Instance.Update();
        }

        public static void Render()

        {
            GameManager.Instance.Render();

        }
    }

}
