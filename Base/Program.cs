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
        public static TileMap tileMap;

        static void Main(string[] args)
        {
            Initialize();

            while (true)
            {
                Update();

                Render();

                Sdl.SDL_Delay(20);
            }
        }

        private static void Initialize()
        {
            Engine.Initialize();
            player = (new Character(new Vector2(0, 0), 100, 30, "assets/player.png"));
            tileMap = (new TileMap(75));
            _startTime = DateTime.Now;
        }

        private static void Update()
        {

            float currentTime = (float)(DateTime.Now - _startTime).TotalSeconds;
            DeltaTime = currentTime - _lastTimeFrame;
            _lastTimeFrame = currentTime;

            player.Update();

            //Console.Write(DeltaTime + Environment.NewLine);

            if (Engine.KeyPress(Engine.KEY_LEFT)) {  }

            if (Engine.KeyPress(Engine.KEY_RIGHT)) {  }

            if (Engine.KeyPress(Engine.KEY_UP)) { }

            if (Engine.KeyPress(Engine.KEY_DOWN)) {  }

            if (Engine.KeyPress(Engine.KEY_ESC)) { }
        }

        public static void Render()

        {
            Engine.Clear();
            Engine.Draw(image, 0, 0);
            player.Render();
            if (bombList.Count > 0)
            {
                foreach (Bomb bomb in bombList)
                {
                    bomb.Render();
                }
            }
            tileMap.update();
            Engine.Show();

        }
    }

}
