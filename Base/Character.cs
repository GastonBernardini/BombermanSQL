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
        public int TileX => tilex;
        public int TileY => tiley;
        private bool isCollidingRight = false;
        private bool isCollidingLeft = false;
        private bool isCollidingUp = false;
        private bool isCollidingDown = false;
        private Animation currentAnimation;
        private Animation idleAnimation;
        private Animation rightAnimation;
        private Animation leftAnimation;
        private Animation upAnimation;
        private Animation downAnimation;


        public Character(Vector2 pos, float speed, float movementTimer, string image)
        {
            transform = new Transform(pos, new Vector2(100, 100));
            this.movementTimer = movementTimer;
            this.speed = speed;
            this.image = Engine.LoadImage(image);
            createAnimations();
            currentAnimation = idleAnimation;
        }

        public void Update()
        {
            AnimationCharacter();
            tilex = (int)Transform.Position.x / TileMap.Instance.TileSize;
            tiley = (int)Transform.Position.y / TileMap.Instance.TileSize;
            isColliding();           
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
                Program.bombList.Add(new Bomb(transform.Position, "assets/bomba.png"));
            };


            if (TileMap.Instance.Tiles1[tilex,tiley] == 3)
            {
                GameManager.Instance.ChangeGameStatus(3);
            }
        }

        public void Render()
        {
            Engine.Draw(currentAnimation.CurrentFrame, transform.Position.x, transform.Position.y);
        }
        private void isColliding()
        {
            if (TileMap.Instance.Tiles1[tilex +1,tiley] != 0)
            {
                isCollidingRight = true;
                //Console.WriteLine("colisiona derecha");
            }
            else
            {
                isCollidingRight = false;
            }
            if (TileMap.Instance.Tiles1[tilex - 1, tiley] != 0)
            {
                isCollidingLeft = true;
                //Console.WriteLine("colisiona izquierda");
            }
            else
            {
                isCollidingLeft = false;
            }
            if (TileMap.Instance.Tiles1[tilex , tiley +1 ] != 0)
            {
                isCollidingDown = true;
                //Console.WriteLine("colisiona abajo");
            }
            else
            {
                isCollidingDown = false;
            }
            if (TileMap.Instance.Tiles1[tilex , tiley - 1] != 0)
            {
                isCollidingUp = true;
                //Console.WriteLine("colisiona arriba");
            }
            else
            {
                isCollidingUp = false;
            }
        }

        private void createAnimations()
        {
            List<IntPtr> PlayerRightTextures = new List<IntPtr>();
            for (int i = 0; i < 4; i++)
            {
                IntPtr frame = Engine.LoadImage($"assets/Player/B_Right/B_Right{i}.png");
                PlayerRightTextures.Add(frame);
            }
            rightAnimation = new Animation("WalkRight", PlayerRightTextures, 0.2f, true);
            
            List<IntPtr> PlayerLeftTextures = new List<IntPtr>();
            for (int i = 0; i < 4; i++)
            {
                IntPtr frame = Engine.LoadImage($"assets/Player/B_Left/B_Left{i}.png");
                PlayerLeftTextures.Add(frame);
            }
            leftAnimation = new Animation("WalkLeft", PlayerLeftTextures, 0.2f, true);

            List<IntPtr> PlayerUpTextures = new List<IntPtr>();
            for (int i = 0; i < 5; i++)
            {
                IntPtr frame = Engine.LoadImage($"assets/Player/B_Up/B_Up{i}.png");
                PlayerUpTextures.Add(frame);
            }
            upAnimation = new Animation("WalkUp", PlayerUpTextures, 0.2f, true);

            List<IntPtr> PlayerDownTextures = new List<IntPtr>();
            for (int i = 0; i < 4; i++)
            {
                IntPtr frame = Engine.LoadImage($"assets/Player/B_Down/B_Down{i}.png");
                PlayerDownTextures.Add(frame);
            }
            downAnimation = new Animation("WalkDown", PlayerDownTextures, 0.2f, true);

            List<IntPtr> PlayerIdleTextures = new List<IntPtr>();
            for (int i = 0; i < 1; i++)
            {
                IntPtr frame = Engine.LoadImage($"assets/Player/B_Idle/B_Idle{i}.png");
                PlayerIdleTextures.Add(frame);
            }
            idleAnimation = new Animation("WalkLeft", PlayerIdleTextures, 0.2f, true);
        }
        private void AnimationCharacter()
        {
            currentAnimation.Update();
            currentAnimation = idleAnimation;
            
            if (Engine.KeyPress(Engine.KEY_LEFT) && !isCollidingLeft)   
            {
                currentAnimation = leftAnimation;
            }
            if (Engine.KeyPress(Engine.KEY_RIGHT) && !isCollidingRight)
            {
                currentAnimation = rightAnimation;
            }
            if (Engine.KeyPress(Engine.KEY_UP) && !isCollidingUp)
            {
                currentAnimation = upAnimation;
            }
            if (Engine.KeyPress(Engine.KEY_DOWN) && !isCollidingDown)
            {
                currentAnimation = downAnimation;
            }

        }
    }
}