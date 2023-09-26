using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;

namespace MyGame
{
    public class Character
    {
        private Transform transform;
        public Transform Transform => transform;
        private float speed;
        private IntPtr image;
        //private Animation currentAnimation;
        //private Animation idleAnimation;

        public Character(Vector2 pos, float speed, string image)
        {
            transform = new Transform(pos, new Vector2(100, 100));
            this.speed = speed;
            this.image = Engine.LoadImage(image);
        }

        public void Update()
        {
            if (Engine.KeyPress(Engine.KEY_LEFT))
            {
                transform.Translate(new Vector2(-1, 0), speed);
            }
            if (Engine.KeyPress(Engine.KEY_RIGHT))
            {
                transform.Translate(new Vector2(1, 0), speed);
            }
            if (Engine.KeyPress(Engine.KEY_UP))
            {
                transform.Translate(new Vector2(0, -1), speed);
            }
            if (Engine.KeyPress(Engine.KEY_DOWN))
            {
                transform.Translate(new Vector2(0, 1), speed);
            }
            if (Engine.KeyPress(Engine.KEY_ESP)) 
            {
                Program.bombList.Add(new Bomb(transform.Position, 100, "assets/player.png"));
            };


        }

        public void Render()
        {
            Engine.Draw(image, transform.Position.x, transform.Position.y);
        }
    }
}