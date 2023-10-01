using System;
using System.Threading;
using System.Drawing;
using Tao.Sdl;
using System.Security.Cryptography.X509Certificates;

namespace MyGame
{
    public class Bomb
    {
        private Transform transform;
        public Transform Transform => transform;
        private IntPtr image;
        private bool exploded = false;
        private float timeElapsed;
        private float timer;
        private float explosionTimer = 10;
        private float explosionTimeElapsed = 0;

        public Bomb(Vector2 pos, float timer, string image)
        {
            transform = new Transform(pos, new Vector2(100, 100));
            this.timer = timer;
            this.image = Engine.LoadImage(image);
        }

        public void Render()
        {
            if (!exploded)
            {
                Engine.Draw(image, transform.Position.x, transform.Position.y);
            }

        }

        public void Update()
        {
            timeElapsed++;
            if (timeElapsed >= timer)
            {
                explosion();
            }
        }

        private void explosion()
        {
            int tilex = (int)Transform.Position.x / TileMap.Instance.TileSize;
            int tiley = (int)Transform.Position.y / TileMap.Instance.TileSize;
            exploded = true;
            explosionTimeElapsed++;
            if (explosionTimeElapsed < explosionTimer)
            {
                TileMap.Instance.Tiles1[tilex, tiley] = 3;

                if (TileMap.Instance.Tiles1[tilex + 1, tiley] != 2)
                {
                    TileMap.Instance.Tiles1[tilex + 1, tiley] = 3;
                }

                if (TileMap.Instance.Tiles1[tilex - 1, tiley] != 2)
                {
                    TileMap.Instance.Tiles1[tilex - 1, tiley] = 3;
                }

                if (TileMap.Instance.Tiles1[tilex, tiley + 1] != 2)
                {
                    TileMap.Instance.Tiles1[tilex, tiley + 1] = 3;
                }

                if (TileMap.Instance.Tiles1[tilex, tiley - 1] != 2)
                {
                    TileMap.Instance.Tiles1[tilex, tiley - 1] = 3;

                }
            }
            else if (explosionTimeElapsed > explosionTimer) { 
                TileMap.Instance.Tiles1[tilex, tiley] = 0;


                if (TileMap.Instance.Tiles1[tilex + 1, tiley] != 2)
                {
                    TileMap.Instance.Tiles1[tilex + 1, tiley] = 0;
                }

                if (TileMap.Instance.Tiles1[tilex - 1, tiley] != 2)
                {
                    TileMap.Instance.Tiles1[tilex - 1, tiley] = 0;
                }

                if (TileMap.Instance.Tiles1[tilex, tiley + 1] != 2)
                {
                    TileMap.Instance.Tiles1[tilex, tiley + 1] = 0;
                }

                if (TileMap.Instance.Tiles1[tilex, tiley - 1] != 2)
                {
                    TileMap.Instance.Tiles1[tilex, tiley - 1] = 0;

                }
            }
        }
    }
}