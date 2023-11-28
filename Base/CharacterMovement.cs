using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;

namespace MyGame
{
    public class CharacterMovement
    {
        private Character player;

        private float movementTimer;
        private float currentTimer;
        private float speed;

        private bool isCollidingRight = false;
        private bool isCollidingLeft = false;
        private bool isCollidingUp = false;
        private bool isCollidingDown = false;

        public bool IsCollidingRight => isCollidingRight;
        public bool IsCollidingLeft => isCollidingLeft;
        public bool IsCollidingUp => isCollidingUp;
        public bool IsCollidingDown => isCollidingDown;

        public CharacterMovement(Character player, float movementTimer, float speed)
        {
            this.player = player;
            this.movementTimer = movementTimer;
                this.speed = speed;
        }


        public void Update()
        {
            isColliding();
            if (currentTimer == movementTimer)
            {
                if (Engine.KeyPress(Engine.KEY_LEFT) && !isCollidingLeft)
                {
                    player.Transform.Translate(new Vector2(-1, 0), speed);
                    currentTimer = 0;
                }
                if (Engine.KeyPress(Engine.KEY_RIGHT) && !isCollidingRight)
                {
                    player.Transform.Translate(new Vector2(1, 0), speed);
                    currentTimer = 0;
                }
                if (Engine.KeyPress(Engine.KEY_UP) && !isCollidingUp)
                {
                    player.Transform.Translate(new Vector2(0, -1), speed);
                    currentTimer = 0;
                }
                if (Engine.KeyPress(Engine.KEY_DOWN) && !isCollidingDown)
                {
                    player.Transform.Translate(new Vector2(0, 1), speed);
                    currentTimer = 0;
                }
            };

            if (currentTimer < movementTimer)
            {
                currentTimer++;
            };

        }

        private void isColliding()
        {
            if (TileMap.Instance.Tiles1[player.TileX + 1, player.TileY] != 0)
            {
                isCollidingRight = true;
            }
            else
            {
                isCollidingRight = false;
            }
            if (TileMap.Instance.Tiles1[player.TileX - 1, player.TileY] != 0)
            {
                isCollidingLeft = true;
            }
            else
            {
                isCollidingLeft = false;
            }
            if (TileMap.Instance.Tiles1[player.TileX, player.TileY + 1] != 0)
            {
                isCollidingDown = true;
            }
            else
            {
                isCollidingDown = false;
            }
            if (TileMap.Instance.Tiles1[player.TileX, player.TileY - 1] != 0)
            {
                isCollidingUp = true;
            }
            else
            {
                isCollidingUp = false;
            }
        }
    }
}