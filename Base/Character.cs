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
        private int tilex;
        private int tiley;
        private bool isCollidingRight = false;
        private bool isCollidingLeft = false;
        private bool isCollidingUp = false;
        private bool isCollidingDown = false;
        public int TileX => tilex;
        public int TileY => tiley;

        public Character(Vector2 pos, float speed, float movementTimer, string image)
        {
            transform = new Transform(pos, new Vector2(100, 100));
            this.movementTimer = movementTimer;
            this.speed = speed;
            this.image = Engine.LoadImage(image);
        }

        public void Update()
        {
            
             tilex = (int)Transform.Position.x / TileMap.Instance.TileSize;
             tiley = (int)Transform.Position.y / TileMap.Instance.TileSize;
             IsColliding();
            if (currentTimer == movementTimer)
            {
                if (Engine.KeyPress(Engine.KEY_LEFT)&& !isCollidingLeft)
                {
                    transform.Translate(new Vector2(-1, 0), speed);
                    currentTimer = 0;
                }
                if (Engine.KeyPress(Engine.KEY_RIGHT)&& !isCollidingRight)
                {
                    transform.Translate(new Vector2(1, 0), speed);
                    currentTimer = 0;
                }
                if (Engine.KeyPress(Engine.KEY_UP)&& !isCollidingUp)
                {
                    transform.Translate(new Vector2(0, -1), speed);
                    currentTimer = 0;
                }
                if (Engine.KeyPress(Engine.KEY_DOWN)&& !isCollidingDown)
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
        private void IsColliding()
        {
            if (TileMap.Instance.Tiles1[tilex +1,tiley] != 0)
            {
                isCollidingRight = true;
                Console.WriteLine("colisiona derecha");
            }
            else
            {
                isCollidingRight = false;
            }
            if (TileMap.Instance.Tiles1[tilex - 1, tiley] != 0)
            {
                isCollidingLeft = true;
                Console.WriteLine("colisiona izquierda");
            }
            else
            {
                isCollidingLeft = false;
            }
            if (TileMap.Instance.Tiles1[tilex , tiley +1 ] != 0)
            {
                isCollidingDown = true;
                Console.WriteLine("colisiona abajo");
            }
            else
            {
                isCollidingDown = false;
            }
            if (TileMap.Instance.Tiles1[tilex , tiley - 1] != 0)
            {
                isCollidingUp = true;
                Console.WriteLine("colisiona arriba");
            }
            else
            {
                isCollidingUp = false;
            }
        }
    }
}