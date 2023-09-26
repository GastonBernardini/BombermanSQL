using System;
using System.Threading;
using System.Drawing;
using Tao.Sdl;

namespace MyGame
{
    public class Bomb
    {
        private Transform transform;
        public Transform Transform => transform;
        private IntPtr image;
        private float timeElapsed;
        private float timer;

        public Bomb(Vector2 pos, float timer, string image)
        {
            transform = new Transform(pos, new Vector2(100, 100));
            this.timer = timer;
            this.image = Engine.LoadImage(image);
        }

        public void Render()
        {
            Engine.Draw(image, transform.Position.x, transform.Position.y);
        }

    }
}