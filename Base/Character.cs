using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Xml;

namespace MyGame
{
    public class Character : GameObject
    {
        private Animation idleAnimation;
        private Animation rightAnimation;
        private Animation leftAnimation;
        private Animation upAnimation;
        private Animation downAnimation;

        private int tilex;
        private int tiley;
        public int TileX => tilex;
        public int TileY => tiley;

        public StaticPool<Bomb> bombPool;

        private CharacterMovement characterMovement;
        private CharacterAnimations charAnim;

        public Character(Vector2 pos, float speed, float movementTimer) :base(pos)
        {
            charAnim = new CharacterAnimations();
            CreateAnimations();
            currentAnimation = charAnim.idleAnimation;
            characterMovement = new CharacterMovement(this, movementTimer, speed);
            bombPool = new StaticPool<Bomb>(1, new Bomb(Vector2.Zero));
            
        }

        public override void Update()
        {
            AnimationCharacter();
            tilex = (int)Transform.Position.x / TileMap.Instance.TileSize;
            tiley = (int)Transform.Position.y / TileMap.Instance.TileSize;
            characterMovement.Update();

            if (Engine.KeyPress(Engine.KEY_ESP)) 
            {
                
                Bomb bomb = bombPool.GetObj();
                if (bomb != null) {
                    bomb.ResetBomb();
                    GameManager.Instance.levelController.gameObjectList.Add(bomb);
                    bomb.Transform.SetNewPosition(new Vector2(transform.Position.x, transform.Position.y));
                }
                bombPool.PrintObj();
            };

            if (TileMap.Instance.Tiles1[tilex,tiley] == 3)
            {
                GameManager.Instance.ChangeGameStatus(3);
            }
        }

        public override void Render()
        {
            renderer.Render(transform, currentAnimation);
        }

        

        protected override void CreateAnimations()
        {
            charAnim.CreateAnimations();
        }

        private void AnimationCharacter()
        {
            currentAnimation.Update();
            currentAnimation = idleAnimation;
            
            if (Engine.KeyPress(Engine.KEY_LEFT) && !characterMovement.IsCollidingLeft)   
            {
                currentAnimation = leftAnimation;
            }
            if (Engine.KeyPress(Engine.KEY_RIGHT) && !characterMovement.IsCollidingRight)
            {
                currentAnimation = rightAnimation;
            }
            if (Engine.KeyPress(Engine.KEY_UP) && !characterMovement.IsCollidingUp)
            {
                currentAnimation = upAnimation;
            }
            if (Engine.KeyPress(Engine.KEY_DOWN) && !characterMovement.IsCollidingDown)
            {
                currentAnimation = downAnimation;
            }

        }
    }
}