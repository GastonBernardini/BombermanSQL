using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class LevelController
    {
        static IntPtr image = Engine.LoadImage("assets/fondo.png");
        private static DateTime _startTime;
        private static float _lastTimeFrame;
        public float DeltaTime;
        public static Character player;
        public static Character player2;
        public List<GameObject> gameObjectList = new List<GameObject>();

        public void Initialization()
        {
            player = (new Character(new Vector2(75, 75), 75, 15, 1));
            player2 = (new Character(new Vector2(825,825),75,15,2));
            _startTime = DateTime.Now;
        }

        public void Update()
        {
            float currentTime = (float)(DateTime.Now - _startTime).TotalSeconds;
            DeltaTime = currentTime - _lastTimeFrame;
            _lastTimeFrame = currentTime;
            
            player.Update();
            player2.Update();

            if (gameObjectList.Count > 0)
            {
                foreach (GameObject gameObject in gameObjectList.ToArray())
                {
                    gameObject.Update();
                }
            }
        }

        public void Render()
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
            player2.Render();
            Engine.Show();
        }

    }
}
