using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    internal class SpeedUp : GameObject, IPickupeable
    {
        private Animation speedAnimation;
        public SpeedUp(Vector2 pos) : base(pos)
        {
            CreateAnimations();
            currentAnimation = speedAnimation;
        }
        protected override void CreateAnimations()
        {
            List<IntPtr> speedTextures = new List<IntPtr>();
            for (int i = 0; i < 1; i++)
            {
                IntPtr frame = Engine.LoadImage($"assets/speed_{i}.png");
                speedTextures.Add(frame);
            }
            speedAnimation = new Animation("Morespeed", speedTextures, 0.2f, false);
        }
        public override void Update()
        {

        }

        public override void Render()
        {
            renderer.Render(transform, currentAnimation);
        }

        public void Pickup(Character player)
        {
            Engine.Debug("¡Tienes mas velocidad de movimiento!");
            player.characterMovement.MovementTimer -= 2;
            GameManager.Instance.levelController.gameObjectList.Remove(this);
        }
    }






}

