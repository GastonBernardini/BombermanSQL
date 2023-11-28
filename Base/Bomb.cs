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
        private Animation bombAnimation;
        private int tilex;
        private int tiley;
        public int Tilex => tilex;
        public int Tiley => tiley;

        public event Action<IPoolable> OnDispose;
        private BombExplosion bombExplosion;
        

        public Bomb(Vector2 pos) : base(pos)
        {
            currentAnimation = bombAnimation;
            bombExplosion = new BombExplosion(this);
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
            if (!bombExplosion.Exploded)
            {
                renderer.Render(transform, currentAnimation);
            }
        }

        public override void Update()
        {
            currentAnimation.Update();

            tilex = (int)Transform.Position.x / TileMap.Instance.TileSize;
            tiley = (int)Transform.Position.y / TileMap.Instance.TileSize;

            if (!bombExplosion.Exploded)
            {
                TileMap.Instance.Tiles1[tilex, tiley] = 4;
            }

            if (currentAnimation.CurrentFrameIndex == currentAnimation.FramesCount - 1)
            {
                bombExplosion.explosion();
            }

            if (bombExplosion.ExplosionFinished)
            {
                Dispose();
            }
        }

        public void Dispose()
        {
            OnDispose.Invoke(this);
            GameManager.Instance.levelController.gameObjectList.Remove(this);
        }

        public void ResetBomb()
        {
            bombExplosion.ResetBomb();
            currentAnimation.ResetAnimation();
        }
    }
}