using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;

namespace MyGame
{
    public class CharacterMovement
    {
        private Character player;
        private Character player2;

        private float movementTimer;
        private float currentTimer;
        private float speed;
        public float MovementTimer 
        {
            get { return movementTimer; }
            set { movementTimer = value; }
        }

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

            if (player.Id == 1)
            {
                if (currentTimer == movementTimer)
                {
                    if (Engine.KeyPress(Engine.KEY_LEFT) && !isCollidingLeft)
                    {
                        player.Transform.Translate(new Vector2(-1, 0), speed);
                        currentTimer = 0;
                        pickupObject();
                    }
                    if (Engine.KeyPress(Engine.KEY_RIGHT) && !isCollidingRight)
                    {
                        player.Transform.Translate(new Vector2(1, 0), speed);
                        currentTimer = 0;
                        pickupObject();
                    }
                    if (Engine.KeyPress(Engine.KEY_UP) && !isCollidingUp)
                    {
                        player.Transform.Translate(new Vector2(0, -1), speed);
                        currentTimer = 0;
                        pickupObject();
                    }
                    if (Engine.KeyPress(Engine.KEY_DOWN) && !isCollidingDown)
                    {
                        player.Transform.Translate(new Vector2(0, 1), speed);
                        currentTimer = 0;
                        pickupObject();
                    }
                };
            }

            if (player.Id == 2)
            {
                if (currentTimer == movementTimer)
                {
                    if (Engine.KeyPress(Engine.KEY_A) && !isCollidingLeft)
                    {
                        player.Transform.Translate(new Vector2(-1, 0), speed);
                        currentTimer = 0;
                        pickupObject();


                    }
                    if (Engine.KeyPress(Engine.KEY_D) && !isCollidingRight)
                    {
                        player.Transform.Translate(new Vector2(1, 0), speed);
                        currentTimer = 0;
                        pickupObject();
                    }
                    if (Engine.KeyPress(Engine.KEY_W) && !isCollidingUp)
                    {
                        player.Transform.Translate(new Vector2(0, -1), speed);
                        currentTimer = 0;
                        pickupObject();
                    }
                    if (Engine.KeyPress(Engine.KEY_S) && !isCollidingDown)
                    {
                        player.Transform.Translate(new Vector2(0, 1), speed);
                        currentTimer = 0;
                        pickupObject();
                    }
                }
            }

            if (currentTimer < movementTimer)
            {
                currentTimer++;
            };

        }

        private void pickupObject()
        {
            foreach (GameObject gameObject in GameManager.Instance.levelController.gameObjectList.ToArray())
            {
                if (gameObject is IPickupeable objPickup && gameObject.Transform.Position == player.Transform.Position)
                {
                    objPickup.Pickup(player);
                }
            }
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