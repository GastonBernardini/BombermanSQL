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
                    
        static IntPtr image = Engine.LoadImage("assets/fondo.png");
        private static DateTime _startTime;
        private static float _lastTimeFrame;
        public static float DeltaTime;
        public static Character player;
        public static List<GameObject> gameObjectList = new List<GameObject>();

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
            Engine.Initialize();
            player = (new Character(new Vector2(75, 75), 75, 15));
            //tileMap = (new TileMap());
            _startTime = DateTime.Now;
        }

        public static void Update()
        {

            float currentTime = (float)(DateTime.Now - _startTime).TotalSeconds;
            DeltaTime = currentTime - _lastTimeFrame;
            _lastTimeFrame = currentTime;

            player.Update();
            TileMap.Instance.Update();

            if (gameObjectList.Count > 0)
            {
                foreach (GameObject gameObject in gameObjectList.ToArray())
                {
                    gameObject.Update();
                }
            }
        }

        public static void Render()

        {
            Engine.Clear();
            Engine.Draw(image, 0, 0);
            TileMap.Instance.Render();
            if (gameObjectList.Count > 0)
            {
                foreach (GameObject gameObject in gameObjectList.ToArray())
                {
                    gameObject.Render();
                }
            }
            player.Render();
            Engine.Show();

        }
    }

}
