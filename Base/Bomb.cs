using System;
using System.Threading;
using System.Drawing;
using Tao.Sdl;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;

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
        private float explosionTimer = 12;
        private float explosionTimeElapsed = 0;
        private Animation currentAnimation;
        private Animation bombAnimation;

        public Bomb(Vector2 pos, float timer, string image)
        {
            transform = new Transform(pos, new Vector2(100, 100));
            this.timer = timer;
            this.image = Engine.LoadImage(image);
            CreateAnimations();
            currentAnimation = bombAnimation;
        }

        private void CreateAnimations()
        {
            List<IntPtr> bombTextures = new List<IntPtr>();
            for (int i = 0; i < 15; i++)
            {
                IntPtr frame = Engine.LoadImage($"assets/Bomb/Bomb_{i}.png");
                bombTextures.Add(frame);
            }
            bombAnimation = new Animation("Bomb", bombTextures, 0.2f, false);
        }

        public void Render()
        {
            if (!exploded)
            {
                Engine.Draw(currentAnimation.CurrentFrame, transform.Position.x, transform.Position.y);
            }

        }

        public void Update()
        {
            currentAnimation.Update();
            if (currentAnimation.CurrentFrameIndex == currentAnimation.FramesCount - 1)
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