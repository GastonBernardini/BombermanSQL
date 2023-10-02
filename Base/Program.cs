using System;
using System.Collections.Generic;
using System.Data;
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
        public static List<Bomb> bombList = new List<Bomb>();
        //public static TileMap tileMap;

        static void Main(string[] args)
        {
            Initialize();

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
            player = (new Character(new Vector2(75, 75), 75, 15, "assets/player.png"));
            //tileMap = (new TileMap());
            _startTime = DateTime.Now;
        }

        public static void Update()
        {

            float currentTime = (float)(DateTime.Now - _startTime).TotalSeconds;
            DeltaTime = currentTime - _lastTimeFrame;
            _lastTimeFrame = currentTime;

            player.Update();

            if (bombList.Count > 0)
            {
                foreach (Bomb bomb in bombList)
                {
                    bomb.Update();
                }
            }
        }

        public static void Render()

        {
            Engine.Clear();
            Engine.Draw("tile0", 0, 0);
            TileMap.Instance.Render();
            player.Render();
            if (bombList.Count > 0)
            {
                foreach (Bomb bomb in bombList)
                {
                    bomb.Render();
                }
            }
            Engine.Show();

        }
    }

}
