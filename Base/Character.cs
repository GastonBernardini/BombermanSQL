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
        private float movementTimer;
        private float currentTimer;
        private IntPtr image;

        public Character(Vector2 pos, float speed, float movementTimer, string image)
        {
            transform = new Transform(pos, new Vector2(100, 100));
            this.movementTimer = movementTimer;
            this.speed = speed;
            this.image = Engine.LoadImage(image);
        }

        public void Update()
        {
            int tilex = (int)Transform.Position.x / TileMap.Instance.TileSize;
            int tiley = (int)Transform.Position.y / TileMap.Instance.TileSize;

            if (currentTimer == movementTimer)
            {
                if (Engine.KeyPress(Engine.KEY_LEFT))
                {
                    transform.Translate(new Vector2(-1, 0), speed);
                    currentTimer = 0;
                }
                if (Engine.KeyPress(Engine.KEY_RIGHT))
                {
                    transform.Translate(new Vector2(1, 0), speed);
                    currentTimer = 0;
                }
                if (Engine.KeyPress(Engine.KEY_UP))
                {
                    transform.Translate(new Vector2(0, -1), speed);
                    currentTimer = 0;
                }
                if (Engine.KeyPress(Engine.KEY_DOWN))
                {
                    transform.Translate(new Vector2(0, 1), speed);
                    currentTimer = 0;
                }
            };

            if (currentTimer < movementTimer)
            {
                currentTimer++;
            };

            if (Engine.KeyPress(Engine.KEY_ESP)) 
            {
                Program.bombList.Add(new Bomb(transform.Position, 100, "assets/bomba.png"));
            };


            if (TileMap.Instance.Tiles1[tilex,tiley] == 3)
            {
                GameManager.Instance.ChangeGameStatus(3);
            }
        }

        public void Render()
        {
            Engine.Draw(image, transform.Position.x, transform.Position.y);
        }
    }
}