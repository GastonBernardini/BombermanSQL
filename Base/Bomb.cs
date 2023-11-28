using System;
using System.Threading;
using System.Drawing;
using Tao.Sdl;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;

namespace MyGame
{
    public class Bomb : GameObject, IPoolable
    {
        //private IntPtr image;
        private bool exploded = false;
        private bool explosionFinished = false;
        private float explosionTimer = 12;
        private float explosionTimeElapsed = 0;
        private Animation bombAnimation;
        private int tilex;
        private int tiley;
        public event Action<IPoolable> OnDispose;
        

        public Bomb(Vector2 pos) : base(pos)
        {
            //CreateAnimations();
            currentAnimation = bombAnimation;
        }

        protected override void CreateAnimations()
        {
            List<IntPtr> bombTextures = new List<IntPtr>();
            for (int i = 0; i < 15; i++)
            {
                IntPtr frame = Engine.LoadImage($"assets/Bomb/Bomb_{i}.png");
                bombTextures.Add(frame);
            }
            bombAnimation = new Animation("Bomb", bombTextures, 0.2f, false);
        }

        public override void Render()
        {
            if (!exploded)
            {
                renderer.Render(transform, currentAnimation);
            }
        }

        public override void Update()
        {
            currentAnimation.Update();

            tilex = (int)Transform.Position.x / TileMap.Instance.TileSize;
            tiley = (int)Transform.Position.y / TileMap.Instance.TileSize;

            if (!exploded)
            {
                TileMap.Instance.Tiles1[tilex, tiley] = 4;
            }

            if (currentAnimation.CurrentFrameIndex == currentAnimation.FramesCount - 1)
            {
                explosion();
            }

            if (explosionFinished)
            {
                Dispose();
                //Program.player.bombPool.PrintBombs();
            }
        }

        public void Dispose()
        {
            OnDispose.Invoke(this);
            GameManager.Instance.levelController.gameObjectList.Remove(this);
        }

        private void explosion()
        {
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

                explosionFinished = true;
            }
        }

        public void ResetBomb()
        {
            exploded = false;
            explosionFinished = false;
            explosionTimeElapsed = 0;
            currentAnimation.ResetAnimation();
        }
    }
}